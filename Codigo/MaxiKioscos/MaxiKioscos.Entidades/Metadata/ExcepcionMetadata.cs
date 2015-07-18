using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKioscos.Web.Comun.Atributos;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ExcepcionMetadata))]
    public partial class Excepcion : IEntity
    {
        public string CierreCajaDetalle
        {
            get
            {
                var inicio = String.Format("{0} {1}", CierreCaja.FechaInicio.ToShortDateString(), CierreCaja.FechaInicio.ToShortTimeString());
                if (CierreCaja.FechaFin == null)
                    return String.Format("{0} [{1}]", inicio, CierreCaja.Usuario.NombreUsuario);
                
                var fin = String.Format("{0} {1}", CierreCaja.FechaFin.GetValueOrDefault().ToShortDateString(), 
                                                    CierreCaja.FechaFin.GetValueOrDefault().ToShortTimeString());
                return String.Format("{0} - {1} [{2}]", inicio, fin, CierreCaja.Usuario.NombreUsuario);
            }
        }
    }

    public class ExcepcionMetadata 
    {
        [DisplayName("Cierre de Caja")]
        [UIHint("CierreCaja")]
        [Required(ErrorMessage = "Debe seleccionar un cierre de caja")]
        public int CierreCajaId { get; set; }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Importe")]
        [UIHint("NegativeCurrency")]
        [Required(ErrorMessage = "Debe ingresar un importe")]
        [NotEqualToValue("0,00", ErrorMessage = "El importe no puede ser 0")]
        public decimal Importe { get; set; }

        [DisplayName("Fecha Excepción")]
        [UIHint("Date")]
        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public DateTime FechaCarga { get; set; }
        
    }
}
