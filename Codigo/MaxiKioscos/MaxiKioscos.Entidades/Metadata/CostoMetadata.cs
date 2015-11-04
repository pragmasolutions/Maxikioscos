using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MaxiKiosco.Win.Util;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(CostoMetadata))]
    public partial class Costo : IEntity
    {
        public string Estado
        {
            get { return Aprobado ? "Aprobado" : "No aprobado"; }
        }

        public string NombreUsuario
        {
            get
            {
                if (CierreCaja != null)
                    return CierreCaja.Usuario.NombreUsuario;
                if (Usuario != null)
                    return Usuario.NombreUsuario;
                return string.Empty;
            }
        }

        public string MaxiKioscoNombre
        {
            get
            {
                if (CierreCaja != null)
                    return CierreCaja.MaxiKiosco.Nombre;
                if (MaxiKiosco != null)
                    return MaxiKiosco.Nombre;
                return string.Empty;
            }
        }

        public bool EsGastoGeneral { get; set; }

        public string FechaFormateada
        {
            get
            {
                DateTime fecha = Fecha;
                if (CierreCajaId == null && Turno != null)
                    fecha = new DateTime(Fecha.Year, fecha.Month, Fecha.Day, Turno.HoraMedia.Hours, Turno.HoraMedia.Minutes, 0, 0);
                return fecha.ToShortDateString() + " " + fecha.ToShortTimeString();
            }
        }

        public int? CategoriaPadreId { get; set; }
    }

    public class CostoMetadata
    {
        [DisplayName("Fecha")]
        [UIHint("Date")]
        public DateTime Fecha { get; set; }

        [DisplayName("Monto")]
        [UIHint("Currency")]
        [Required(ErrorMessage = "Debe ingresar un monto")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar un monto")]
        public decimal Monto { get; set; }

        [DisplayName("Gasto General")]
        public bool EsGastoGeneral { get; set; }

        [DisplayName("Nro. Comprobante")]
        public string NroComprobante { get; set; }

        [DisplayName("Usuario")]
        [UIHint("Usuario")]
        [Required(ErrorMessage = "Debe seleccionar un usuario")]
        public int? UsuarioId { get; set; }

        [DisplayName("Sub-Categoría")]
        [UIHint("CategoriaCostoHijas")]
        [Required(ErrorMessage = "Debe seleccionar una sub-categoría")]
        public int CategoriaCostoId { get; set; }

        [DisplayName("Turno")]
        [UIHint("Turno")]
        public int? TurnoId { get; set; }

        [DisplayName("Maxikiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxikioscoId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        [DisplayName("Categoría")]
        [UIHint("CategoriaCostoPadres")]
        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        public int? CategoriaPadreId { get; set; }
    }
}
