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
            try
            {
                var maxi = Uow.MaxiKioscos.Obtener(m => m.Identifier == request.MaxiKioscoIdentifier);
                var actualizo = false;

                if (request.Exportacion != null)
                {
                    var secuenciaActual = request.Exportacion.Secuencia;
                    var ultimaAcusada = maxi.UltimaSecuenciaAcusada.GetValueOrDefault();
                    if (secuenciaActual > ultimaAcusada)
                    {
                        if (secuenciaActual - ultimaAcusada > 1)
                        {
                            return new ActualizarDatosResponse()
                            {
                                Exito = false,
                                MensageError = "SECUENCIA DESFASADA"
                            };
                        }
                        Uow.Exportaciones.ActualizarPrincipal(request.Exportacion.Archivo, request.MaxiKioscoIdentifier, request.Exportacion.Secuencia, null);
                        actualizo = true;
                    }
                }
                return new ActualizarDatosResponse() { Exito = true };
            }
            catch (Exception ex)
            {
                LogManager.GetLogger("errors").Error(ex);
                return new ActualizarDatosResponse
                       {
                           MensageError = ExceptionHelper.GetInnerException(ex).Message,
                           Exito = false
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

            Task.Run(() =>
            {
                Uow.Stocks.Actualizar(request.MaxiKioscoIdentifier);
            });

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


        public ObtenerSecuenciasResponse ObtenerSecuencias(string identifier)
        {
            var id = Guid.Parse(identifier);
            var maxi = Uow.MaxiKioscos.Listado().FirstOrDefault(m => m.Identifier == id);
            return new ObtenerSecuenciasResponse()
            {
                UltimaSecuenciaAcusada = maxi.UltimaSecuenciaAcusada.GetValueOrDefault(),
                UltimaSecuenciaExportacion = maxi.UltimaSecuenciaExportacion.GetValueOrDefault()
            };
        }
        
        public void ForzarArmadoDeArchivoExportacion(Guid usuarioIdentifier)
        {
            var usuario = Uow.Usuarios.Obtener(u => u.Identifier == usuarioIdentifier);

            if (usuario == null)
                throw new ApplicationException("No se encontro el usuario");

            var puedeExportar = Uow.Exportaciones.PuedeExportarPrincipal();
            if (puedeExportar)
            {
                Uow.Exportaciones.ExportarPrincipal(usuario.UsuarioId);
            }
        }

        public bool AcusarEstadoConexion(Guid maxikioscoIdentifier, string dateISO)
        {
            //Actualizo el estado de kiosco
            var kiosco = Uow.MaxiKioscos.Obtener(m => m.Identifier == maxikioscoIdentifier);
            kiosco.UltimaConexion = DateHelper.ISOToDate(dateISO);
            try
            {
                Uow.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
