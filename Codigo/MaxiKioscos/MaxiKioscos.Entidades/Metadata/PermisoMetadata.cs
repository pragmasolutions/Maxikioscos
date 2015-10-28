using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MaxiKiosco.Win.Util;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(PermisoMetadata))]
    public partial class Permiso : IEntity
    {
    }

    public class PermisoMetadata
    {
    }
}
