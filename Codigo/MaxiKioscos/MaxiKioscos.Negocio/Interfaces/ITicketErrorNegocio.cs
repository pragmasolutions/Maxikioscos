using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill;
using MaxiKioscos.Email.Models;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public interface ITicketErrorNegocio
    {
        List<EmailResult> ReportarError(ReportarErrorModel model, TicketError ticket);
    }
}
