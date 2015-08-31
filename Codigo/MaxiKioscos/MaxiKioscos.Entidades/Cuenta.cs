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
    
    public partial class Cuenta
    {
        public Cuenta()
        {
            this.Marcas = new HashSet<Marca>();
            this.MaxiKioscos = new HashSet<MaxiKiosco>();
            this.Productos = new HashSet<Producto>();
            this.Proveedores = new HashSet<Proveedor>();
            this.Rubros = new HashSet<Rubro>();
            this.Usuarios = new HashSet<Usuario>();
            this.Exportacions = new HashSet<Exportacion>();
            this.Compras = new HashSet<Compra>();
        }
    
        public int CuentaId { get; set; }
        public string Titular { get; set; }
        public System.Guid Identifier { get; set; }
        public Nullable<System.DateTime> FechaUltimaModificacion { get; set; }
        public bool Eliminado { get; set; }
        public Nullable<decimal> MargenImporteFactura { get; set; }
        public bool Desincronizado { get; set; }
        public Nullable<decimal> AplicarPercepcionIVADesde { get; set; }
        public Nullable<decimal> PorcentajePercepcionIVA { get; set; }
        public int MotivoCorreccionPorDefecto { get; set; }
        public decimal MargenInferiorCierreCajaAceptable { get; set; }
        public decimal MargenSuperiorCierreCajaAceptable { get; set; }
        public Nullable<System.Guid> MaxiKioscoIdentifierPredeterminadoTransferencias { get; set; }
        public Nullable<bool> SincronizarAutomaticamente { get; set; }
        public Nullable<int> IntervaloSincronizacion { get; set; }
    
        public virtual ICollection<Marca> Marcas { get; set; }
        public virtual ICollection<MaxiKiosco> MaxiKioscos { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Proveedor> Proveedores { get; set; }
        public virtual ICollection<Rubro> Rubros { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Exportacion> Exportacions { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual MotivoCorreccion MotivoCorreccion { get; set; }
    }
}