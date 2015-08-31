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
    
    public partial class Transferencia
    {
        public Transferencia()
        {
            this.TransferenciaProductos = new HashSet<TransferenciaProducto>();
        }
    
        public int TransferenciaId { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int OrigenId { get; set; }
        public int DestinoId { get; set; }
        public int UsuarioId { get; set; }
        public Nullable<System.DateTime> FechaAprobacion { get; set; }
        public bool Desincronizado { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public System.Guid Identifier { get; set; }
        public bool Eliminado { get; set; }
    
        public virtual MaxiKiosco Destino { get; set; }
        public virtual MaxiKiosco Origen { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<TransferenciaProducto> TransferenciaProductos { get; set; }
    }
}