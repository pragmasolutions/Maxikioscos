using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(TicketErrorMetadata))]
    public partial class TicketError
    {
        public string EstadoString
        {
            get
            {
                switch (EstadoTicketId)
                {
                    case EstadoTicketEnum.Eliminado:
                        return "Eliminado";
                    case EstadoTicketEnum.EnProgreso:
                        return "En Progreso";
                    case EstadoTicketEnum.Cerrado:
                        return "Cerrado";
                    default:
                        return "Pendiente";
                }
            }
        }
    }

    public class TicketErrorMetadata
    {
        
    }
}
