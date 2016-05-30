using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync
{
   public class ControlStockRepository: EFRepository<ControlStock>, IControlStockRepository
   {
       public ControlStockRepository(){}

       public ControlStockRepository(DbContext context) : base(context) { }
       
       public bool DeshabilitarAbiertos(int controlStockId, int[] stockIds)
       {
           try
           {
               var ids =  string.Join(",", Array.ConvertAll(stockIds, i => i.ToString()));
               MaxiKioscosEntities.ControlStockDeshabilitarAbiertos(controlStockId, ids);
               return true;
           }
           catch (Exception)
           {
               return false;
           }
       }

       public bool CrearControlStock(int maxiKioscoId, int? proveedorId, int? rubroId, int usuarioId, bool masVendidos, bool conStockCero,
                                        int? cantidadFilas, int limiteInferior, int limiteSuperior)
       {
           try
           {
               var maxi = MaxiKioscosEntities.MaxiKioscoes.FirstOrDefault(m => m.MaxiKioscoId == maxiKioscoId);
               MaxiKioscosEntities.StockActualizar(maxi.Identifier, null);

               MaxiKioscosEntities.ControlStockCrear(maxiKioscoId, proveedorId, rubroId, usuarioId, masVendidos,conStockCero,
                                                cantidadFilas, limiteInferior, limiteSuperior);
               return true;
           }
           catch (Exception)
           {
               return false;
           }
       }

       public List<ControlStockPlanillaRow> ReporteControlStockPlanilla(int controlStockId)
       {
           return MaxiKioscosEntities.ReporteControlStockPlanilla(controlStockId).ToList();
       }

       public List<ControlStockVistaPreviaRow> ReporteControlStockVistaPrevia(int maxiKioscoId, int? proveedorId, int? rubroId,
                                bool masVendidos, bool conStockCero, int? cantidadFilas)
       {
           return MaxiKioscosEntities.ControlStockVistaPrevia(maxiKioscoId, proveedorId, rubroId, masVendidos, conStockCero, cantidadFilas).ToList();
       }

       public List<ControlStockObtenerDetalleRow> ObtenerDetalle(int maxiKioscoId, int? proveedorId, int? rubroId,
           int usuarioId, bool masVendidos, bool conStockCero,
           int? cantidadFilas, int limiteInferior, int limiteSuperior)
       {
           try
           {
               return MaxiKioscosEntities.ControlStockObtenerDetalle(maxiKioscoId, proveedorId, rubroId, usuarioId,
                   masVendidos, conStockCero, cantidadFilas, limiteInferior, limiteSuperior).ToList();
           }
           catch (Exception)
           {
               return null;
           }
       }
   }
}
