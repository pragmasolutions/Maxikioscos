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
       
    }

    public class CostoMetadata
    {

    }
}
