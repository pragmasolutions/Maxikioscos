using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaxiKioscos.Web.Models
{
    public class CargarProductoModel
    {
        public int CompraProductoId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public decimal CostoConIVAActual { get; set; }
        public decimal? CostoConIVAActualizado { get; set; }
        public decimal CostoSinIVAActual { get; set; }
        public decimal? CostoSinIVAActualizado { get; set; }
        public decimal PrecioConIVAActual { get; set; }
        public decimal? PrecioConIVAActualizado { get; set; }
        public decimal PrecioSinIVAActual { get; set; }
        public decimal? PrecioSinIVAActualizado { get; set; }
        public decimal Cantidad { get; set; }
        public bool Desincronizado { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
        public bool Eliminado { get; set; }
        public Guid Identifier { get; set; }
        public int StockTransaccionId { get; set; }
    }
}