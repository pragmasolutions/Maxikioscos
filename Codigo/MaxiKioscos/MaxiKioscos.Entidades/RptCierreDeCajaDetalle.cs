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
    
    public partial class RptCierreDeCajaDetalle
    {
        public string MaxiKioscoNombre { get; set; }
        public string UsuarioNombre { get; set; }
        public string UsuarioApellido { get; set; }
        public Nullable<decimal> Inicial { get; set; }
        public Nullable<decimal> Ventas { get; set; }
        public Nullable<decimal> Compras { get; set; }
        public Nullable<decimal> Ingresos { get; set; }
        public Nullable<decimal> Retiros { get; set; }
        public Nullable<decimal> Diferencia { get; set; }
        public Nullable<decimal> Cierre { get; set; }
        public Nullable<decimal> Excepciones { get; set; }
        public string Caja { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
    }
}