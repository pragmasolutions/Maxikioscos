//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaxiKioscos.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransferenciaProducto
    {
        public int TransferenciaProductoId { get; set; }
        public int TransferenciaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public bool Desincronizado { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public System.Guid Identifier { get; set; }
        public bool Eliminado { get; set; }
        public Nullable<decimal> StockOrigen { get; set; }
        public decimal StockDestino { get; set; }
        public int Orden { get; set; }
        public decimal Costo { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual Transferencia Transferencia { get; set; }
    }
}
