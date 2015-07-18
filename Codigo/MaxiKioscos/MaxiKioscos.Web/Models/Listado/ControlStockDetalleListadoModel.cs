using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ControlStockDetalleListadoModel
    {
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        public int ControlStockId { get; set; }

        public List<ControlStockDetalle> List { get; set; }

        public ControlStockDetalleFiltrosModel Filtros { get; set; }

        public ControlStock ControlStock { get; set; }

    }
}