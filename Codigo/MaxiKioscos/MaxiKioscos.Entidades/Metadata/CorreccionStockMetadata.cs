using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(CorreccionStockMetadata))]
    public partial class CorreccionStock
    {
        public string Descripcion { get { return this.Producto.Descripcion; } }

        public string Motivo { get { return this.MotivoCorreccion.Descripcion; } }

        public decimal CantidadModificada 
        { get
            {
            if (Producto.AceptaCantidadesDecimales == true)
                {
                    if (this.MotivoCorreccion.SumarAStock)
                    
                        return  this.Cantidad;
                    else
                        return this.Cantidad*-1;
                }
            else
            {
                if (this.MotivoCorreccion.SumarAStock)

                    return Convert.ToInt16(this.Cantidad);
                else
                    return Convert.ToInt16(this.Cantidad * -1);
            }
            }
        }

        

    }

    public class CorreccionStockMetadata
    {
    }
}
