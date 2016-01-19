using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using log4net;
using MaxiKioscos.Datos;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Sync.Repositorio;
using MaxiKioscos.Entidades;


namespace MaxiKioscos.Negocio
{
    public class SincronizacionNegocio : ISincronizacionNegocio
    {
        readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IMaxiKioscosUow Uow { get; set; }

        public SincronizacionNegocio(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public bool ExportarPrincipal(int usuarioId)
        {
            var exito = Uow.Exportaciones.PuedeExportarPrincipal();

            if (exito)
            {
                var archivo = Uow.Exportaciones.ExportarPrincipal(usuarioId);
                exito = !string.IsNullOrEmpty(archivo);

                if (exito)
                {
                    try
                    {
                        var syncRepo = new SyncSimpleRepository<SyncExportacion>();
                        var maxSeq = syncRepo.Listado().Max(s => s.Secuencia);
                        var exportacion = new SyncExportacion()
                        {
                            Acusada = true,
                            ExportacionArchivo = new SyncExportacionArchivo()
                            {
                                Archivo = archivo
                            },
                            CreadorId = usuarioId,
                            CuentaId = 1,
                            Desincronizado = true,
                            Eliminado = false,
                            Fecha = DateTime.Now,
                            Secuencia = maxSeq + 1
                        };
                        syncRepo.Agregar(exportacion);
                        syncRepo.Commit();
                    }
                    catch (Exception)
                    {
                        exito = false;
                    }

                }
            }
            return exito;
        }




        public IQueryable<SyncExportacion> ListadoExportaciones(params Expression<Func<SyncExportacion, object>>[] includes)
        {
            var syncRepo = new SyncSimpleRepository<SyncExportacion>();
            return syncRepo.Listado(includes);
        }


        public bool ActualizarPrincipal(string archivo, Guid maxiKioscoIdentifier, int secuencia, string nombreArchivo)
        {
            using (var dbContextTransaction = Uow.DbContext.Database.BeginTransaction())
            {
                try
                {
                    Uow.Exportaciones.ActualizarPrincipal(archivo, maxiKioscoIdentifier, secuencia, nombreArchivo);

                    var repo = new SyncSimpleRepository<SyncMaxiKiosco>();

                    repo.SincronizacionEntities.Database.UseTransaction(dbContextTransaction.UnderlyingTransaction);

                    var maxi = repo.Obtener(m => m.Identifier == maxiKioscoIdentifier);

                    maxi.UltimaSecuenciaAcusada = secuencia;

                    repo.Commit();

                    dbContextTransaction.Commit();

                    return true;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();

                    _logger.Error(ex);

                    return false;
                }
            }
        }
    }
}
