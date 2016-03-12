using System.Collections.Generic;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IControlStockRepository : IRepository<ControlStock>
    {
        bool DeshabilitarAbiertos(int controlStockId, int[] stockIds);

        bool CrearControlStock(int maxiKioscoId, int? proveedorId, int? rubroId, int usuarioId, bool masVendidos, bool conStockCero,
                                    int? cantidadFilas, int limiteInferior, int limiteSuperior);

        List<ControlStockPlanillaRow> ReporteControlStockPlanilla(int controlStockId);

        List<ControlStockVistaPreviaRow> ReporteControlStockVistaPrevia(int maxiKioscoId, int? proveedorId, int? rubroId,
                                bool masVendidos, bool conStockCero, int? cantidadFilas);

        List<ControlStockObtenerDetalleRow> ObtenerDetalle(int maxiKioscoId, int? proveedorId, int? rubroId, int usuarioId, bool masVendidos, bool conStockCero,
                                    int? cantidadFilas, int limiteInferior, int limiteSuperior);
    }
}
