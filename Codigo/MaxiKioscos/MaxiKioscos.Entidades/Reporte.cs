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
    
    public partial class Reporte
    {
        public Reporte()
        {
            this.ReporteRoles = new HashSet<ReporteRol>();
        }
    
        public int ReporteId { get; set; }
        public string NombreCompleto { get; set; }
        public string Nombre { get; set; }
        public string Padre { get; set; }
        public string Path { get; set; }
    
        public virtual ICollection<ReporteRol> ReporteRoles { get; set; }
    }
}
