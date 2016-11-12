using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public interface IStockNegocio
    {
        void ActualizarStock(Stock stock, decimal diferencia, int motivoCorreccionId, decimal precionConIVA);

        void TransferirStock(Stock stockOrigen, int unidades, int destinoId);
        
        IQueryable<StockDto> Listado(int cuentaId, int? maxiKioscoId, bool? necesitaReposicion,
                                     string productoDescripcion, int? proveedorId, bool? disponibleEnDeposito, int? page);
    }
}
