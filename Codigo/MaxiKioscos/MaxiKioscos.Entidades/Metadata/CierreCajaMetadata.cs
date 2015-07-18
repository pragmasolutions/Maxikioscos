using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(CierreCajaMetadata))]
    public partial class CierreCaja : IEntity
    {
        public int CuentaId
        {
            get { return MaxiKiosco.CuentaId; }
            set { MaxiKiosco.CuentaId = value; }
        }

        public string FechaInicioFormateada
        {
            get { return String.Format("{0} {1}", FechaInicio.ToShortDateString(), FechaInicio.ToShortTimeString()); }
        }

        public string FechaFinFormateada
        {
            get
            {
                if (FechaFin == null)
                    return string.Empty;
                return String.Format("{0} {1}", FechaFin.GetValueOrDefault().ToShortDateString(), 
                                                FechaFin.GetValueOrDefault().ToShortTimeString());
            }
        }

        public string CierreCajaDetalle
        {
            get
            {
                if (FechaFin == null)
                    return String.Format("{0} [{1}]", FechaInicioFormateada, Usuario.NombreUsuario);
                return String.Format("{0} - {1} [{2}]", FechaInicioFormateada, FechaFinFormateada, Usuario.NombreUsuario);
            }
        }
    }

    public class CierreCajaMetadata
    {
    }
}
