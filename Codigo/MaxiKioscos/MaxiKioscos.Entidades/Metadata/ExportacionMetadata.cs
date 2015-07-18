using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ExportacionMetadata))]
    public partial class Exportacion : IEntity
    {
        public string ArmarNombreParaKiosco(Guid maxikioscoIdentifier)
        {
            //formato: {GUID} EXP-{SECUENCIA} {Fecha}
            return String.Format("{0} EXP-{1} {2}.xml", maxikioscoIdentifier, this.Secuencia, this.Fecha.ToString("dd-MM-yyyy"));
        }
    }

    public class ExportacionMetadata
    {
        
    }
}
