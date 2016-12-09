﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Compilation;
using log4net;
using Maxikioscos.Comun.Extensions;
using Maxikioscos.Comun.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Sync.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Services.Contracts;

namespace MaxiKioscos.Services
{
    public class SincronizacionService : BaseService, ISincronizacionService
    {
        private ISincronizacionNegocio _sincronizacionNegocio { get; set; }

        public SincronizacionService(IMaxiKioscosUow uow, ISincronizacionNegocio sincronizacionNegocio)
        {
            Uow = uow;
            _sincronizacionNegocio = sincronizacionNegocio;
        }

        public ObtenerDatosResponse ObtenerDatos(ObtenerDatosRequest request)
        {
            var maxiKioscoIdentifier = request.MaxiKioscoIdentifier;
            var usuario = Uow.Usuarios.Obtener(u => u.Identifier == request.UsuarioIdentifier);

            if (usuario == null)
                throw new ApplicationException("No se encontro el usuario");


            var response = new ObtenerDatosResponse();
            _sincronizacionNegocio.ExportarPrincipal(usuario.UsuarioId);

            //Actualizo el estado de kiosco
            var syncRepo = new SyncSimpleRepository<SyncMaxiKiosco>();
            var kiosco = syncRepo.Obtener(m => m.Identifier == maxiKioscoIdentifier);
            kiosco.UltimaSecuenciaExportacion = request.UltimaSecuenciaExportacion;
            syncRepo.Commit();

            //Obtenemos las exportacion generadas
            var exportaciones = _sincronizacionNegocio.ListadoExportaciones(e => e.ExportacionArchivo)
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

        public ActualizarDatosResponse ActualizarDatos(ActualizarDatosRequest request)
        {
            try
            {
                var syncRepo = new SyncSimpleRepository<SyncMaxiKiosco>();
                var maxi = syncRepo.Obtener(m => m.Identifier == request.MaxiKioscoIdentifier);
                var actualizo = false;

                if (request.Exportacion != null)
                {
                    var secuenciaActual = request.Exportacion.Secuencia;
                    var ultimaAcusada = maxi.UltimaSecuenciaAcusada.GetValueOrDefault();
                    if (secuenciaActual > ultimaAcusada)
                    {
                        actualizo = _sincronizacionNegocio.ActualizarPrincipal(request.Exportacion.Archivo, request.MaxiKioscoIdentifier, request.Exportacion.Secuencia, null);
                    }
                }
                return new ActualizarDatosResponse()
                       {
                           Exito = actualizo,
                           MensageError =
                               !actualizo
                                   ? "Ha ocurrido un error no se pudo actualizar el servidor. Intente más tarde."
                                   : null
                       };
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
        }

        public void AcusarExportacion(AcusarExportacionRequest request)
        {
            //Actualizo el estado de kiosco
            var syncRepo = new SyncSimpleRepository<SyncMaxiKiosco>();
            var kiosco = syncRepo.Obtener(m => m.Identifier == request.MaxiKioscoIdentifier);

            kiosco.UltimaSecuenciaExportacion = request.UltimaSecuenciaExportacion;
            kiosco.UltimaSincronizacionExitosa = DateTime.UtcNow;
            syncRepo.Commit();

            Task.Run(() =>
            {
                Uow.Stocks.Actualizar(request.MaxiKioscoIdentifier);
            });
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
            var syncRepo = new SyncSimpleRepository<SyncMaxiKiosco>();
            var kiosco = syncRepo.Obtener(m => m.Identifier == maxiKioscoIdentifier);
            kiosco.UltimaSecuenciaExportacion = request.UltimaSecuenciaExportacion;
            syncRepo.Commit();

            //Controlo si es la última
            var cantidadPorExportar = _sincronizacionNegocio.ListadoExportaciones()
                .Count(e => e.CuentaId == usuario.CuentaId
                            && (!request.UltimaSecuenciaExportacion.HasValue)
                            || e.Secuencia > request.UltimaSecuenciaExportacion);

            if (cantidadPorExportar > 0)
            {
                var exportacion = _sincronizacionNegocio.ListadoExportaciones(e => e.ExportacionArchivo)
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
            var syncRepo = new SyncSimpleRepository<SyncMaxiKiosco>();
            var maxi = syncRepo.Obtener(m => m.Identifier == id);
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

            _sincronizacionNegocio.ExportarPrincipal(usuario.UsuarioId);
        }

        public bool AcusarEstadoConexion(Guid maxikioscoIdentifier, string dateISO)
        {
            var syncRepo = new SyncSimpleRepository<SyncMaxiKiosco>();
            var kiosco = syncRepo.Obtener(m => m.Identifier == maxikioscoIdentifier);
            kiosco.UltimaConexion = DateTime.UtcNow;
            try
            {
                syncRepo.Commit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
