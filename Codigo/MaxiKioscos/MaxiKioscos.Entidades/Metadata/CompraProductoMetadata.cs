using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(CompraProductoMetadata))]
    public partial class CompraProducto : IEntity, ISynchronizableEntity
    {
        public string PrimerCodigoProducto { get; set; }

        public string ProductoDescripcion { get; set; }

        public string ProductoMarca { get; set; }

        public decimal StockAnterior { get; set; }

        public decimal StockActual { get; set; }

        public string ProductoNombre
        {
            get { return Producto.Descripcion; }
        }
        
        public string CostoActualizadoFormateado
        {
            get
            {
                string costo = (CostoActualizado % 1) == 0
                                ? CostoActualizado.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : CostoActualizado.GetValueOrDefault().ToString("N2");
                return String.Format("${0}", costo);
            }
        }

        public string CostoActualFormateado
        {
            get
            {
                string costo = (CostoActual % 1) == 0
                                ? CostoActual.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : CostoActual.ToString("N2");
                return String.Format("${0}", costo);
            }
        }

        public string PrecioActualizadoFormateado
        {
            get
            {
                string precio = (PrecioActualizado % 1) == 0
                                ? PrecioActualizado.GetValueOrDefault().ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : PrecioActualizado.GetValueOrDefault().ToString("N2");
                return String.Format("${0}", precio);
            }
        }

        public string PrecioActualFormateado
        {
            get
            {
                string precio = (PrecioActual % 1) == 0
                                ? PrecioActual.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : PrecioActual.ToString("N2");
                return String.Format("${0}", precio);
            }
        }

        public string GananciaFormateada
        {
            get
            {
                var costo = CostoActualizado.GetValueOrDefault();
                if (costo == 0)
                    return string.Empty;
                var ganancia = ((PrecioActualizado.GetValueOrDefault() - costo) / costo) * 100;

                var cadena = (ganancia % 1) == 0
                                ? ganancia.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "").Replace(",0", "")
                                : ganancia.ToString("N2");
                return String.Format("{0}%", cadena);
            }
        }

        public decimal? CostoSinIVA
        {
            get
            {
                if (CostoActualizado == null)
                    return null;
                return CostoActualizado / 1.21m;
            }
        }

        public string CostoSinIVAFormateado
        {
            get
            {
                string costo = (CostoSinIVA % 1) == 0
                                ? CostoSinIVA.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : CostoSinIVA.GetValueOrDefault().ToString("N2");
                return String.Format("${0}", costo);
            }
        }

        public string StockActualFormateado
        {
            get
            {
                string stock = (StockActual % 1) == 0
                                ? StockActual.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : StockActual.ToString("N2");
                return stock;
            }
        }

        public string StockAnteriorFormateado
        {
            get
            {
                string stock = (StockAnterior % 1) == 0
                                ? StockAnterior.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : StockAnterior.ToString("N2");
                return stock;
            }
        }

        public string CantidadFormateada
        {
            get
            {
                return (Cantidad % 1) == 0
                                ? Cantidad.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "").Replace(",0", "")
                                : Cantidad.ToString("N2");
            }
        }
    }

    public class CompraProductoMetadata
    {
        [Range(0.05, double.MaxValue, ErrorMessage = "El valor ingresado debe ser mayor a $0,05")]
        [Required(ErrorMessage = "Debe ingresar un costo actualizado")]
        public decimal? CostoActualizado { get; set; }

        [Range(0.05, double.MaxValue, ErrorMessage = "El valor ingresado debe ser mayor a $0,05")]
        public decimal? PrecioActualizado { get; set; }

        [Range(0.05, double.MaxValue, ErrorMessage = "El valor ingresado debe ser mayor a $0,05")]
        public decimal Cantidad { get; set; }
    }
}
