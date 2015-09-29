using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MaxiKiosco.Win.Util;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(RetiroPersonalMetadata))]
    public partial class RetiroPersonal : IEntity
    {
       
    }

    public class RetiroPersonalMetadata
    {
    }
}
