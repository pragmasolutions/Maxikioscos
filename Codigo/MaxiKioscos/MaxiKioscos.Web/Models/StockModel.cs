using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MaxiKioscos.Datos.Sync;
using MaxiKioscos.Entidades;
using MaxiKioscos.Web.Configuration;

namespace MaxiKioscos.Web.Models
{
    public class StockModel
    {
        [Display(Name = "MaxiKiosco")]
        public string MaxiKiosco { get; set; }

        [Display(Name = "Producto")]
        public string Producto { get; set; }

        [Display(Name = "Stock Actual")]
        public decimal StockActual { get; set; }

        [Display(Name = "Diferencia")]
        [Range((double)0.01, Double.MaxValue, ErrorMessage = "Debe ingresar un valor mayor a cero")]
        [Required(ErrorMessage = "Debe ingresar una diferencia")]
        public decimal Diferencia { get; set; }

        [Display(Name = "Motivo")]
        [UIHint("MotivoCorreccion")]
        [Required(ErrorMessage = "Debe seleccionar un motivo")]
        public int MotivoCorreccionId { get; set; }

        [Display(Name = "Precio con IVA")]
        [UIHint("Currency")]
        [Required(ErrorMessage = "Debe ingresar un precio")]
        [Range(0.05, Double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal PrecioConIVA { get; set; }

        public Stock Stock { get; set; }
    }
}