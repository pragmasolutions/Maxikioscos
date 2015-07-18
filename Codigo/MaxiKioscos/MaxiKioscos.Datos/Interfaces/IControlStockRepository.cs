using System.Collections.Generic;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IControlStockRepository : IRepository<ControlStock>
    {
        bool DeshabilitarAbiertos(int controlStockId, int[] stockIds);

        bool CrearControlStock(int maxiKioscoId, int? proveedorId, int? rubroId, int usuarioId, bool masVendidos,
                                    int? cantidadFilas, int limiteInferior, int limiteSuperior);

        List<ControlStockPlanillaRow> ReporteControlStockPlanilla(int controlStockId);
    }
}
