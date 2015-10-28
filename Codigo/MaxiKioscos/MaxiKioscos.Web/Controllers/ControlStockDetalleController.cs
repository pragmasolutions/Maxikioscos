using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.UI;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;
using MaxiKioscos.Seguridad;
using MaxiKioscos.Web.Comun.Atributos;
using MaxiKioscos.Web.Comun.Helpers;
using MaxiKioscos.Web.Configuration;
using MaxiKioscos.Web.Filters;
using MaxiKioscos.Web.Models;
using PagedList;

namespace MaxiKioscos.Web.Controllers
{
    [ActivityAuthorize(Actions = MaxikioscoPermisos.CONTROLDESTOCK)]
    public class ControlStockDetalleController : BaseController
    {
        public ControlStockDetalleController(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public ActionResult Corregir(int id)
        {
            var detalle = Uow.ControlStockDetalles.Obtener(d => d.ControlStockDetalleId == id, d => d.Stock,
                                                            d => d.Stock.MaxiKiosco, d => d.Stock.Producto);
            if (detalle.MotivoCorreccionId == null)
            {
                detalle.MotivoCorreccionId = 6; //"Sin Motivo" por default
            }
            return PartialView(detalle);
        }

    }
}
