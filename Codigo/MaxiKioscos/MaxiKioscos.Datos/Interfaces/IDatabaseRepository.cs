using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IDatabaseRepository : IRepository<Entidades.MaxiKiosco>
    {
        bool ActualizarEsquema(Guid maxikioscoIdentifier, string scriptsFolderPath);
    }
}
