using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Ionic.Zip;
using MaxiKiosco.Win.Util.Helpers;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Models;
using MaxiKioscos.Web.Models.DTO;

namespace MaxiKioscos.Web.Controllers
{
    public class SincronizacionController : BaseController
    {
        public SincronizacionController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Index(int? page)
        {
            var exportaciones = Uow.Exportaciones.ListadoPorCuenta(UsuarioActual.CuentaId).OrderByDescending(e => e.Fecha).ToList();
            var lista = PagedListHelper<Exportacion>.Crear(exportaciones, AppSettings.DefaultPageSize, page);
            return PartialOrView(lista);
        }

        public ActionResult LogImportacion(LogImportacionesFiltrosModel filtros,int? page)
        {
            var importaciones = Uow.Importaciones.Listado(i => i.MaxiKiosco)
                                                 .Where(filtros.GetFilterExpression())
                                                 .OrderByDescending(e => e.Fecha).ToList();

            var lista = PagedListHelper<Importacion>.Crear(importaciones, AppSettings.DefaultPageSize, page);

            LogImportacionesListadoModel logImportacionesListadoModel = new LogImportacionesListadoModel();
            logImportacionesListadoModel.PagedList = lista;
            logImportacionesListadoModel.Filtros = filtros;

            return PartialOrView(logImportacionesListadoModel);
        }

        public ActionResult Importar()
        {
            return PartialView(new ImportacionModel());
        }

        [HttpPost]
        public ActionResult ZipUpload(HttpPostedFileBase files)
        {

            var pathCompleto = Path.Combine(AppSettings.UploadTempPath, files.FileName);
            DirectoryHelper.LimpiarDirectorio(AppSettings.UploadTempPath);
            files.SaveAs(pathCompleto);

            return Json(new { name = files.FileName });
        }

        [HttpPost]
        public ActionResult Importar(ImportacionModel model)
        {
            if (!ModelState.IsValid)
                return Json(new {exito = false});

            string error;
            var exito = SincronizarPrincipal(model.NombreArchivo, out error);
            
            return Json(new {exito, error});
        }

        private bool SincronizarPrincipal(string nombreArchivo, out string error)
        {
            error = null;
            //Obtengo y descomprimo el zip en la carpeta temporal
            var xml = new XmlDocument();
            var path = Path.Combine(AppSettings.UploadTempPath, nombreArchivo);

            DirectoryHelper.LimpiarDirectorio(AppSettings.UploadTempPath, ".xml");

            var rarFile = new ZipFile(path);
            rarFile.ExtractAll(AppSettings.UploadTempPath);

            //Leo los archivos xml y los corro si todavia no se corrieron
            var nombresArchivos = DirectoryHelper.ObtenerArchivos(AppSettings.UploadTempPath, "xml");
            nombresArchivos = nombresArchivos.Select(x => x.Split('\\').Last()).ToList();
            var xmls = nombresArchivos.Select(x => new ArchivoKioscoDTO(x)).OrderBy(f => f.Secuencia).ToList();
            var result = true;
            Entidades.MaxiKiosco kiosco = null;

            //Verifico que no se haya salteado ningun archivo
            int ultimaSecuenciaAcusada;
            if (xmls.Any())
            {
                var identifier = xmls.First().MaxiKioscoIdentifier;
                kiosco = Uow.MaxiKioscos.Obtener(m => m.Identifier == identifier);
                ultimaSecuenciaAcusada = kiosco.UltimaSecuenciaAcusada ?? 0;
                if (xmls.First().Secuencia > ultimaSecuenciaAcusada + 1)
                {
                    error = string.Format(
                            "Error: hay archivos faltantes. Se espera un archivo de secuencia: {0}, y se pasó uno con la secuencia: {1}",
                            ultimaSecuenciaAcusada + 1, xmls.First().Secuencia);
                    return false;
                }
            }

            foreach (var xmlFile in xmls)
            {
                kiosco = kiosco ?? Uow.MaxiKioscos.Obtener(m => m.Identifier == xmlFile.MaxiKioscoIdentifier);
                if (kiosco.UltimaSecuenciaAcusada == null || kiosco.UltimaSecuenciaAcusada < xmlFile.Secuencia)
                {
                    xml.Load(Path.Combine(AppSettings.UploadTempPath, xmlFile.NombreCompleto));
                    result = Uow.Exportaciones.ActualizarPrincipal(xml.InnerXml, xmlFile.MaxiKioscoIdentifier, xmlFile.Secuencia, xmlFile.NombreCompleto);
                    if (!result)
                    {
                        error = "Ha ocurrido un error durante intentando sincronizar el archivo: " + xmlFile.NombreCompleto;
                        break;
                    }
                        
                }
            }

            return result;
        }

        public ActionResult EstadoKioscos()
        {
            var estados = Uow.MaxiKioscos.EstadoMaxiKioscos(UsuarioActual.CuentaId).ToList();

            var exportaciones = Uow.Exportaciones.ListadoPorCuenta(UsuarioActual.CuentaId).OrderByDescending(e => e.Fecha).ToList();
            var secuencia = exportaciones.Any() ? exportaciones.Last().Secuencia : 0;

            var model = new EstadoKioscosModel()
                            {
                                Estados = estados.ToList(),
                                UltimaSecuenciaPrincipal = secuencia
                            };
        
            if (Request.IsAjaxRequest())
                return PartialView(model);

            return PartialOrView(model);
        }

        [HttpPost]
        public ActionResult Exportar()
        {
            var exito = Uow.Exportaciones.PuedeExportarPrincipal();

            if (exito)
                exito = Uow.Exportaciones.ExportarPrincipal(UsuarioActual.Usuario.UsuarioId) > 0;
            return new JsonResult() { Data = new { exito }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult Detalle(int secuencia)
        {
            var exportacion = Uow.Exportaciones.Obtener(e => e.Secuencia == secuencia && e.CuentaId == UsuarioActual.CuentaId, e => e.ExportacionArchivo);
            return this.Content(exportacion.ExportacionArchivo.Archivo, "text/xml");
        }

        public ActionResult Descargar()
        {
            var model = new ExportacionDescargaModel() { DescargaTipo = 1 };
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Descargar(ExportacionDescargaModel model)
        {
            ValidarDescarga(model);
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }
            var filename = model.GenerarNombreArchivo();
            var archivos = model.ObtenerExportaciones();
            return new JsonResult() { Data = new { exito = true, 
                                                    filename, 
                                                    maxikioscoId = model.MaxiKioscoId,
                                                    tieneArchivos = archivos.Any()
                                    }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        private void ValidarDescarga(ExportacionDescargaModel model)
        {
            if (model.DescargaTipo == 3)
            {
                if (model.Secuencia == null)
                    ModelState.AddModelError("Secuencia", "Debe ingresar un número de secuencia");
                else
                {
                    var maxSec = Uow.Exportaciones.ListadoPorCuenta(UsuarioActual.CuentaId).Max(e => e.Secuencia);
                    if (model.Secuencia > maxSec)
                        ModelState.AddModelError("Secuencia", "El número de secuencia ingresado es mayor al actual");
                }
            }
            else if (model.DescargaTipo == 1 && model.MaxiKioscoId == null)
            {
                ModelState.AddModelError("MaxiKioscoId", "Debe seleccionar un maxikiosco");
            }
            else if (model.DescargaTipo == 4 && model.Fecha == null)
            {
                ModelState.AddModelError("Fecha", "Debe seleccionar una fecha");
            }
        }

        [HttpGet]
        public ActionResult DescargarArchivo(ExportacionDescargaModel model)
        {
            List<Exportacion> exportaciones = model.ObtenerExportaciones();
            var listaXmls = exportaciones.Select(e => new KeyValuePair<string, string>(e.Nombre, e.ExportacionArchivo.Archivo)).ToList();
            return ZipHelper.ZipResult(listaXmls, model.FileName);
        }
        
        public ActionResult ResetearArchivosDeExportacion()
        {
            var ultimaExportacion = Uow.Exportaciones.Listado().OrderByDescending(e => e.Secuencia).FirstOrDefault();
            if (ultimaExportacion != null)
            {
                var secuencia = ultimaExportacion.Secuencia + 1;
                Uow.Exportaciones.Resetear();
                Uow.Exportaciones.ExportarPrincipal(1, secuencia);
            }
            return new ContentResult(){ Content = "Exito"};
        }
    }
}
