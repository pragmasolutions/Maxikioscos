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
    
    public partial class CierreCaja
    {
        public CierreCaja()
        {
            this.OperacionesCaja = new HashSet<OperacionCaja>();
            this.Ventas = new HashSet<Venta>();
            this.Excepcions = new HashSet<Excepcion>();
            this.Facturas = new HashSet<Factura>();
            this.RecuentoBilletes = new HashSet<RecuentoBillete>();
            this.Costoes = new HashSet<Costo>();
            this.RetiroPersonals = new HashSet<RetiroPersonal>();
        }
    
        public int CierreCajaId { get; set; }
        public System.Guid Identifier { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public decimal CajaInicial { get; set; }
        public Nullable<decimal> CajaFinal { get; set; }
        public Nullable<decimal> CajaEsperada { get; set; }
        public int UsuarioId { get; set; }
        public int MaxiKioskoId { get; set; }
        public bool Desincronizado { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public bool Eliminado { get; set; }
        public Nullable<decimal> Diferencia { get; set; }
    
        public virtual MaxiKiosco MaxiKiosco { get; set; }
        public virtual ICollection<OperacionCaja> OperacionesCaja { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
        public virtual ICollection<Excepcion> Excepcions { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<RecuentoBillete> RecuentoBilletes { get; set; }
        public virtual ICollection<Costo> Costoes { get; set; }
        public virtual ICollection<RetiroPersonal> RetiroPersonals { get; set; }
    }
}
