using System;
using System.Collections.Generic;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IStockRepository : IRepository<Stock>
    {
        Stock ObtenerByProducto(int productoId, int maxiKisocoId);

        bool Actualizar(Guid? maxikioscoIdentifier = null, int? productoId = null);

        List<Rubro> Listado(string descripcion);
    }
}
