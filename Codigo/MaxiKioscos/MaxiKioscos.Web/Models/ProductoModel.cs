using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Entidades;
using PagedList;

namespace MaxiKioscos.Web.Models
{
    public class ProductoModel
    {
        public Producto Producto { get; set; }

        public IList<CodigoProducto> CodigosProductos { get; set; }
    }
}