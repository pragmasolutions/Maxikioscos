using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(StockTransaccionMetadata))]
    public partial class StockTransaccion : IEntity ,ISynchronizableEntity
    {
        
    }

    public class StockTransaccionMetadata
    {
    }
}
