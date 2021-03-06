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
    
    public partial class Exportacion
    {
        public int ExportacionId { get; set; }
        public int Secuencia { get; set; }
        public System.DateTime Fecha { get; set; }
        public int CreadorId { get; set; }
        public int CuentaId { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }
        public bool Desincronizado { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public bool Acusada { get; set; }
    
        public virtual Cuenta Cuenta { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ExportacionArchivo ExportacionArchivo { get; set; }
    }
}
