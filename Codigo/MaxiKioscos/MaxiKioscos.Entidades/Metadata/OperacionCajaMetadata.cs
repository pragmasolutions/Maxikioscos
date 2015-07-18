using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(OperacionCajaMetadata))]
    public partial class OperacionCaja
    {
        public string FechaCompleta
        {
            get { return String.Format("{0} {1}", Fecha.ToShortDateString(), Fecha.ToShortTimeString()); }
        }
    }

    public class OperacionCajaMetadata
    {
    }
}
