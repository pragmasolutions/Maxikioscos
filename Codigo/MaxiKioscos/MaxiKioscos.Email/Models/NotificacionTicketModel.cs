using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Email.Models
{
    public class NotificacionTicketModel
    {
        public int TicketId { get; set; }
        public List<string> Emails { get; set; }
        public string Mensaje { get; set; }
        public string Titulo { get; set; }
        public string Fecha { get; set; }
    }
}
