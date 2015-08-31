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
    
    public partial class MaxiKiosco
    {
        public MaxiKiosco()
        {
            this.CierreCajas = new HashSet<CierreCaja>();
            this.Facturas = new HashSet<Factura>();
            this.Stocks = new HashSet<Stock>();
            this.Compras = new HashSet<Compra>();
            this.ExcepcionRubroes = new HashSet<ExcepcionRubro>();
            this.MaxiKioscoTurnos = new HashSet<MaxiKioscoTurno>();
            this.CorreccionesDeStocks = new HashSet<CorreccionStock>();
            this.Importacions = new HashSet<Importacion>();
            this.ControlesStock = new HashSet<ControlStock>();
            this.Transferencias = new HashSet<Transferencia>();
            this.Transferencias1 = new HashSet<Transferencia>();
        }
    
        public int MaxiKioscoId { get; set; }
        public System.Guid Identifier { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int CuentaId { get; set; }
        public bool Desincronizado { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public bool Eliminado { get; set; }
        public Nullable<int> UltimaSecuenciaExportacion { get; set; }
        public Nullable<int> UltimaSecuenciaAcusada { get; set; }
        public bool EstaOnLine { get; set; }
        public bool Asignado { get; set; }
        public string Abreviacion { get; set; }
        public Nullable<int> UltimoScriptCorrido { get; set; }
        public Nullable<System.DateTime> UltimaSincronizacionExitosa { get; set; }
        public Nullable<System.DateTime> UltimaConexion { get; set; }
    
        public virtual ICollection<CierreCaja> CierreCajas { get; set; }
        public virtual Cuenta Cuenta { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<ExcepcionRubro> ExcepcionRubroes { get; set; }
        public virtual ICollection<MaxiKioscoTurno> MaxiKioscoTurnos { get; set; }
        public virtual ICollection<CorreccionStock> CorreccionesDeStocks { get; set; }
        public virtual ICollection<Importacion> Importacions { get; set; }
        public virtual ICollection<ControlStock> ControlesStock { get; set; }
        public virtual ICollection<Transferencia> Transferencias { get; set; }
        public virtual ICollection<Transferencia> Transferencias1 { get; set; }
    }
}