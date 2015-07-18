using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(TransferenciaProductoMetadata))]
    public partial class TransferenciaProducto : IEntity, ISynchronizableEntity
    {
        public string PrimerCodigoProducto { get; set; }

        public string ProductoDescripcion { get; set; }

        public string ProductoMarca { get; set; }

        public string ProductoNombre
        {
            get { return Producto.Descripcion; }
        }
        
        public string PrecioVentaFormateado
        {
            get
            {
                return this.PrecioVenta.ToString("C2");
            }
        }
    }

    public class TransferenciaProductoMetadata
    {
        //[Range(0.05, double.MaxValue, ErrorMessage = "El valor ingresado debe ser mayor a $0,05")]
        //[Required(ErrorMessage = "Debe ingresar un costo actualizado")]
        //public decimal? CostoActualizado { get; set; }

        //[Range(0.05, double.MaxValue, ErrorMessage = "El valor ingresado debe ser mayor a $0,05")]
        //public decimal? PrecioActualizado { get; set; }

        [Range(0.05, double.MaxValue, ErrorMessage = "El valor ingresado debe ser mayor a $0,05")]
        public decimal Cantidad { get; set; }
    }
}
