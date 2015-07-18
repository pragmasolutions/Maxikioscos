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
    public interface IControlStockNegocio
    {
        bool Cerrar(int controlStockId, List<ControlStockDetalle> listado);
        bool Eliminar(int id);
    }
}
