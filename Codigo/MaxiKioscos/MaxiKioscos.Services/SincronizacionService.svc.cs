using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Compilation;
using log4net;
using Maxikioscos.Comun.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Services.Contracts;

namespace MaxiKioscos.Services
{
    public class SincronizacionService : BaseService, ISincronizacionService
    {
        public SincronizacionService(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        /// <summary>
        /// Obtiene todos los datos de desincronizados desde la base de datos principal
        /// </summary>
        /// <param name="request">Request parametros</param>
        /// <returns>Datos a sincronizar en el maxikiosco</returns>
        public ObtenerDatosResponse ObtenerDatos(ObtenerDatosRequest request)
        {
            var maxiKioscoIdentifier = request.MaxiKioscoIdentifier;
            var usuario = Uow.Usuarios.Obtener(u => u.Identifier == request.UsuarioIdentifier);

            if (usuario == null)
                throw new ApplicationException("No se encontro el usuario");


            var response = new ObtenerDatosResponse();
            var puedeExportar = Uow.Exportaciones.PuedeExportarPrincipal();
            if (puedeExportar)
            {
                Uow.Exportaciones.ExportarPrincipal(usuario.UsuarioId);
            }

            //Actualizo el estado de kiosco
            var kiosco = Uow.MaxiKioscos.Obtener(m => m.Identifier == maxiKioscoIdentifier);
            kiosco.UltimaSecuenciaExportacion = request.UltimaSecuenciaExportacion;
            Uow.Commit();

            //Obtenemos las exportacion generadas
            var exportaciones = Uow.Exportaciones.Listado(e => e.ExportacionArchivo)
                .Where(e => e.CuentaId == usuario.CuentaId
                            && (!request.UltimaSecuenciaExportacion.HasValue)
                            || e.Secuencia > request.UltimaSecuenciaExportacion)
                .Select(e =>
                        new ExportacionData()
                            {
                                Secuencia = e.Secuencia,
                                Archivo = e.ExportacionArchivo.Archivo
                            })
                .ToArray();

            //Creamos la respuesta
            response.Exportaciones = exportaciones;
            return response;
        }

        /// <summary>
        /// Actualiza la base de datos principal con datos de un maxikiosco
        /// </summary>
        /// <param name="request"></param>
        public ActualizarDatosResponse ActualizarDatos(ActualizarDatosRequest request)
        {
            LogManager.GetLogger("errors").Error("Entra " + DateTime.Now);

            int ultimaSecuenciaExitosa = 0;
            try
            {
                var maxi = Uow.MaxiKioscos.Obtener(m => m.Identifier == request.MaxiKioscoIdentifier);
                var actualizo = false;

                foreach (var exportacion in request.Exportaciones)
                {
                    ultimaSecuenciaExitosa = exportacion.Secuencia - 1;
                    if (exportacion.Secuencia > maxi.UltimaSecuenciaAcusada.GetValueOrDefault())
                    {
                        Uow.Exportaciones.ActualizarPrincipal(exportacion.Archivo, request.MaxiKioscoIdentifier, exportacion.Secuencia, null);
                        
                        actualizo = true;
                    }
                }

                if (request.Exportaciones.Any() && actualizo)
                {
                    Task.Run(() =>
                                 {
                                     Uow.Stocks.Actualizar(null,request.MaxiKioscoIdentifier);
                                 });

                }
                return new ActualizarDatosResponse() { Exito = true, UltimaSecuenciaExitosa = actualizo ? ultimaSecuenciaExitosa + 1 : -1 };
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("errors").Error(ex);
                return new ActualizarDatosResponse
                       {
                           MensageError = ExceptionHelper.GetInnerException(ex).Message,
                           Exito = false,
                           UltimaSecuenciaExitosa = ultimaSecuenciaExitosa
                       };
            }
            //Actualizamos la base de datos principal con los datos del kiosco
            
        }


        /// <summary>
        /// Actualiza la base de datos principal con la ultima secuencia de exportacion del kiosco
        /// </summary>
        /// <param name="request"></param>
        public void AcusarExportacion(AcusarExportacionRequest request)
        {
            //Actualizo el estado de kiosco
            var kiosco = Uow.MaxiKioscos.Obtener(m => m.Identifier == request.MaxiKioscoIdentifier);
            kiosco.UltimaSecuenciaExportacion = request.UltimaSecuenciaExportacion;
            var fecha = DateHelper.ISOToDate(request.HoraLocalISO);
            kiosco.UltimaSincronizacionExitosa = fecha;
            Uow.Commit();
        }

        public InicializarKioscoResponse InicializarKiosco()
        {
            var kioscos = Uow.MaxiKioscos.Listado().OrderBy(m => m.Nombre).Where(m => !m.Eliminado)
                                                    .Select(k => new MaxiKioscoData()
                                                                    {
                                                                        Asignado = k.Asignado,
                                                                        Guid = k.Identifier,
                                                                        Nombre = k.Nombre
                                                                    }).ToArray();
            return new InicializarKioscoResponse { Kioscos = kioscos };
        }

        public KioscoAsignadoResponse MarcarKioscoComoAsignado(string identifier)
        {
            var guid = Guid.Parse(identifier);
            var kiosco = Uow.MaxiKioscos.Listado().FirstOrDefault(k => k.Identifier == guid);
            kiosco.Asignado = true;
            kiosco.Desincronizado = true;
            try
            {
                Uow.Commit();

                return new KioscoAsignadoResponse()
                       {
                           Abreviacion = kiosco.Abreviacion,
                           Direccion = kiosco.Direccion,
                           Identifier = kiosco.Identifier,
                           Nombre = kiosco.Nombre,
                           Telefono = kiosco.Telefono
                       };
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ObtenerDatosSecuencialResponse ObtenerDatosSecuencial(ObtenerDatosRequest request)
        {
            var maxiKioscoIdentifier = request.MaxiKioscoIdentifier;
            var usuario = Uow.Usuarios.Obtener(u => u.Identifier == request.UsuarioIdentifier);

            if (usuario == null)
                throw new ApplicationException("No se encontro el usuario");


            var response = new ObtenerDatosSecuencialResponse();
            
            //Actualizo el estado de kiosco
            var kiosco = Uow.MaxiKioscos.Obtener(m => m.Identifier == maxiKioscoIdentifier);
            kiosco.UltimaSecuenciaExportacion = request.UltimaSecuenciaExportacion;
            Uow.Commit();

            //Controlo si es la última
            var cantidadPorExportar = Uow.Exportaciones.Listado()
                .Count(e => e.CuentaId == usuario.CuentaId
                            && (!request.UltimaSecuenciaExportacion.HasValue)
                            || e.Secuencia > request.UltimaSecuenciaExportacion);

            if (cantidadPorExportar > 0)
            {
                var exportacion = Uow.Exportaciones.Listado(e => e.ExportacionArchivo)
                    .FirstOrDefault(e => e.CuentaId == usuario.CuentaId
                                && (!request.UltimaSecuenciaExportacion.HasValue)
                                || e.Secuencia > request.UltimaSecuenciaExportacion);

                var data = new ExportacionData()
                                {
                                    Secuencia = exportacion.Secuencia,
                                    Archivo = exportacion.ExportacionArchivo.Archivo
                                };

                //Creamos la respuesta
                response.Exportacion = data;
                response.ArchivosRestantes = cantidadPorExportar - 1;
                return response;
            }
            return response;
        }


        public int ObtenerUltimaSecuenciaAcusada(string identifier)
        {
            var id = Guid.Parse(identifier);
            var maxi = Uow.MaxiKioscos.Listado().FirstOrDefault(m => m.Identifier == id);
            return maxi.UltimaSecuenciaAcusada.GetValueOrDefault();
        }
    }
}
