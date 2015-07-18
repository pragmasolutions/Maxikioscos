using MaxiKioscos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Web.Models
{
    public class IngresarCostoPrecioModel
    {
        [Display(Name = "Costo sin IVA")]
        [Required(ErrorMessage = "Debe ingresar el costo")]
        [DataType(DataType.Currency)]
        public decimal? CostoSinIVA { get; set; }

        [Display(Name = "Costo con IVA")]
        [Required(ErrorMessage = "Debe ingresar el costo")]
        [DataType(DataType.Currency)]
        public decimal? CostoConIVA { get; set; }

        [Display(Name = "Precio sin IVA")]
        [Required(ErrorMessage = "Debe ingresar el precio")]
        [DataType(DataType.Currency)]
        public decimal? PrecioSinIVA { get; set; }

        [Display(Name = "Precio con IVA")]
        [Required(ErrorMessage = "Debe ingresar el precio")]
        [DataType(DataType.Currency)]
        public decimal? PrecioConIVA { get; set; }
    }

    public class EditarProductoModel
    {
        public EditarProductoModel()
        {
            IngresarCostoPrecioModel = new IngresarCostoPrecioModel();
        }

        public IngresarCostoPrecioModel IngresarCostoPrecioModel { get; set; }
    }
}