using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ProveedorProductoMetadata))]
    public partial class ProveedorProducto : IEntity
    {
        public decimal? Pprecio
        {
            get { return this.Producto.PrecioConIVA; }
        }

        public string Pdescripcion
        {
            get { return this.Producto.Descripcion; }
        }

        public string Pmarca
        {
            get
            {
                return this.Producto.MarcaString;
            }
        }

        public string Prubro
        {
            get
            {
                return this.Producto.RubroString;
            }
        }

        public string ProveedorNombre
        {
            get
            {
                return this.Proveedor.Nombre;
            }
        }

        public decimal PorcentajeGanancia
        {
            get
            {
                if (this.Producto == null || this.CostoConIVA == 0)
                {
                    return 0;
                }

                return ((this.Producto.PrecioConIVA - this.CostoConIVA) / this.CostoConIVA) * 100;
            }
        }
    }

    public class ProveedorProductoMetadata
    {
        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Debe ingresar un proveedor")]
        [UIHint("Proveedor")]
        public int ProveedorId { get; set; }

        [Display(Name = "Costo sin IVA")]
        [Required(ErrorMessage = "Debe ingresar un costo")]
        [DataType(DataType.Currency)]
        public decimal CostoSinIVA { get; set; }

        [Display(Name = "Costo con IVA")]
        [Required(ErrorMessage = "Debe ingresar un costo")]
        [DataType(DataType.Currency)]
        public decimal CostoConIVA { get; set; }
    }
}
