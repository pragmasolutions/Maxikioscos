﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(VentaProductoMetadata))]
    public partial class VentaProducto : IEntity
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

    public class VentaProductoMetadata
    {
    }
}
