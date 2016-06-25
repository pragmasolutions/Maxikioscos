using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Ionic.Zip;
using MaxiKiosco.Win.Util.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Datos.Sync.Repositorio;
using MaxiKioscos.Entidades;
using MaxiKioscos.Negocio;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using MaxiKioscos.Web.Models;
using MaxiKioscos.Web.Models.DTO;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    public class SincronizacionController : BaseController
    {
        private ISincronizacionNegocio _sincronizacionNegocio { get; set; }

        public SincronizacionController(IMaxiKioscosUow uow, ISincronizacionNegocio sincronizacionNegocio)
        {
            Uow = uow;
            _sincronizacionNegocio = sincronizacionNegocio;
        }

        [Authorize]
        public ActionResult EstadoKioscos()
        {
            var kioscoRepo = new SyncSimpleRepository<SyncMaxiKiosco>();
            var syncKioscos = kioscoRepo.Listado().ToList();
            var kioscos = Uow.MaxiKioscos.Listado().ToList();

            var estadoKioscos = new List<EstadoKiosco>();
            var exportacionRepo = new SyncSimpleRepository<SyncExportacion>();
            foreach (var kiosco in kioscos)
            {
                var sync = syncKioscos.FirstOrDefault(x => x.Identifier == kiosco.Identifier);
                var exp = exportacionRepo.Obtener(x => x.Secuencia == sync.UltimaSecuenciaExportacion);
                estadoKioscos.Add(new EstadoKiosco
                {
                    ExportacionId = exp == null ? (int?)null : kiosco.MaxiKioscoId,
                    Fecha = sync == null ? (DateTime?)null : sync.UltimaSincronizacionExitosa,
                    Identifier = sync.Identifier,
                    MaxiKioscoId = kiosco.MaxiKioscoId,
                    Nombre = kiosco.Nombre,
                    UltimaConexion = sync.UltimaConexion,
                    UltimaSecuenciaExportacion = sync.UltimaSecuenciaExportacion
                });
            }
            
            var exportacion = exportacionRepo.Listado().OrderByDescending(e => e.Fecha).Take(1).FirstOrDefault();
            var secuencia = exportacion != null ? exportacion.Secuencia : 0;

            var model = new EstadoKioscosModel()
            {
                Estados = estadoKioscos.OrderBy(x => x.UltimaSecuenciaExportacion).ToList(),
                UltimaSecuenciaPrincipal = secuencia
            };

            if (Request.IsAjaxRequest())
                return PartialView(model);

            return PartialOrView(model);
        }

        [ActivityAuthorize(Actions = MaxikioscoPermisos.SINCRONIZACION)] 
        public ActionResult Index(int? page)
        {
            var exportaciones = Uow.Exportaciones.ListadoPorCuenta(UsuarioActual.CuentaId).OrderByDescending(e => e.Fecha);
            var lista = exportaciones.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);
            return PartialOrView(lista);
        }

        [ActivityAuthorize(Actions = MaxikioscoPermisos.SINCRONIZACION)] 
        public ActionResult LogImportacion(LogImportacionesFiltrosModel filtros,int? page)
        {
            var importaciones = Uow.Importaciones.Listado(i => i.MaxiKiosco)
                                                 .Where(filtros.GetFilterExpression())
                                                 .OrderByDescending(e => e.Fecha);

            var lista = importaciones.ToPagedList(page ?? 1, AppSettings.DefaultPageSize);

            LogImportacionesListadoModel logImportacionesListadoModel = new LogImportacionesListadoModel();
            logImportacionesListadoModel.PagedList = lista;
            logImportacionesListadoModel.Filtros = filtros;

            return PartialOrView(logImportacionesListadoModel);
        }

        [ActivityAuthorize(Actions = MaxikioscoPermisos.SINCRONIZACION)] 
        public ActionResult Importar()
        {
            return PartialView(new ImportacionModel());
        }

        [HttpPost]
        [ActivityAuthorize(Actions = MaxikioscoPermisos.SINCRONIZACION)] 
        public ActionResult ZipUpload(HttpPostedFileBase files)
        {

            var pathCompleto = Path.Combine(AppSettings.UploadTempPath, files.FileName);
            DirectoryHelper.LimpiarDirectorio(AppSettings.UploadTempPath);
            files.SaveAs(pathCompleto);

            return Json(new { name = files.FileName });
        }


        [ActivityAuthorize(Actions = MaxikioscoPermisos.SINCRONIZACION)] 
        [HttpPost]
        public ActionResult Exportar()
        {
            var exito = _sincronizacionNegocio.ExportarPrincipal(UsuarioActual.Usuario.UsuarioId);
                
            return new JsonResult() { Data = new { exito }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [ActivityAuthorize(Actions = MaxikioscoPermisos.SINCRONIZACION)] 
        public ActionResult Detalle(int secuencia)
        {
            var exportacion = Uow.Exportaciones.Obtener(e => e.Secuencia == secuencia && e.CuentaId == UsuarioActual.CuentaId, e => e.ExportacionArchivo);
            return this.Content(exportacion.ExportacionArchivo.Archivo, "text/xml");
        }

        [ActivityAuthorize(Actions = MaxikioscoPermisos.SINCRONIZACION)] 
        public ActionResult Descargar()
        {
            var model = new ExportacionDescargaModel() { DescargaTipo = 1 };
            return PartialView(model);
        }

    }
}
