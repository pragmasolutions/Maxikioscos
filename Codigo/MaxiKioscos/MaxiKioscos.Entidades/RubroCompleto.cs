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
    
    public partial class RubroCompleto
    {
        public int RubroId { get; set; }
        public System.Guid Identifier { get; set; }
        public string Descripcion { get; set; }
        public bool Desincronizado { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public bool Eliminado { get; set; }
        public int CuentaId { get; set; }
        public string TieneExcepciones { get; set; }
        public bool NoFacturar { get; set; }
    }
}
