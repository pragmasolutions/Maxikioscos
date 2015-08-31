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
    
    public partial class CorreccionStock
    {
        public int CorreccionStockId { get; set; }
        public int ProductoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public bool Desincronizado { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public System.Guid Identifier { get; set; }
        public int MotivoCorreccionId { get; set; }
        public System.DateTime Fecha { get; set; }
        public int MaxiKioscoId { get; set; }
        public bool Eliminado { get; set; }
    
        public virtual MotivoCorreccion MotivoCorreccion { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual MaxiKiosco MaxiKiosco { get; set; }
    }
}