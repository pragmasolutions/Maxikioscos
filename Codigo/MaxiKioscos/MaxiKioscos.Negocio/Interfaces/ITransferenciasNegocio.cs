using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public interface ITransferenciasNegocio
    {
        void Crear(Transferencia transferencia);

        void Editar(Transferencia transferencia, bool aprobar);

        void Aprobar(int transferenciaId);
    }
}
