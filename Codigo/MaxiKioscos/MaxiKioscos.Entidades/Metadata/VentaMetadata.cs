using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(VentaMetadata))]
    public partial class Venta : IEntity
    {
        public int CuentaId
        {
            get { return CierreCaja.CuentaId; }
            set { CierreCaja.CuentaId = value; }
        }
    }

    public class VentaMetadata
    {
    }
}
