using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public interface IComprasNegocio
    {
        void Crear(Compra compra);

        string UltimoNumeroCompra(int maxikioscoId);
    }
}
