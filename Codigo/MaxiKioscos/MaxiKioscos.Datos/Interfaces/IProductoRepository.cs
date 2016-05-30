using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IProductoRepository : IRepository<Producto>
    {
        ProductoCompleto Obtener(int productoId, int maxikioscoId, int proveedorId);
        ProductoParaTransferencia ObtenerParaTransferencia(int productoId, int origenId, int destinoId);
        List<ProductoStock> ObtenerStock(int productoId);
        List<PromocionCompleta> PromocionesListado(int? rubroId, string descripcion, decimal? precio,
            int? stockReposicion, int? conStockMenorA, string codigo);

        ProductoPorCodigo ProductoPorCodigo(string codigo, int maxiKioscoId);
    }
}
