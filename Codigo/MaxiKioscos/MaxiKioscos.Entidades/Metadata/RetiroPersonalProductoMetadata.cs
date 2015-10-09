using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MaxiKiosco.Win.Util;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(RetiroPersonalProductoMetadata))]
    public partial class RetiroPersonalProducto : IEntity
    {
        public string ProductoNombre
        {
            get { return Producto.Descripcion; }
        }

        public string Codigo
        {
            get { return Producto.CodigosListado; }
        }

        public bool EsPromocion { get; set; }
    }

    public class RetiroPersonalProductoMetadata
    {
    }
}
