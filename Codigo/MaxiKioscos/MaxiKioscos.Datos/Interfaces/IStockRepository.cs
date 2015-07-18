using System;
using System.Collections.Generic;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IStockRepository : IRepository<Stock>
    {
        Stock ObtenerByProducto(int productoId, int maxiKisocoId);

        bool Actualizar(int? stockId, Guid? maxikioscoIdentifier);

        List<Rubro> Listado(string descripcion);
    }
}
