using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync
{
   public class StockRepository: EFRepository<Stock>, IStockRepository
   {
       public StockRepository(){}

        public StockRepository(DbContext context) : base(context) { }
       
        public Stock ObtenerByProducto(int productoId, int maxiKioscoId)
        {
            return DbContext
                .Set<Stock>()
                .Select(s => s)
                .FirstOrDefault(s => s.ProductoId == productoId && s.MaxiKioscoId == maxiKioscoId);
        }

       public bool Actualizar(Guid? maxikioscoIdentifier = null, int? productoId = null)
       {
           return MaxiKioscosEntities.StockActualizar(maxikioscoIdentifier, productoId).FirstOrDefault() == 1;
       }

        public List<Rubro> Listado(string descripcion)
        {
            throw new NotImplementedException();
        }

        public static void EliminarODeshabilitar(int proveedorId)
        {
            throw new NotImplementedException();
        }

        public static bool Guardar(Proveedor proveedor)
        {
            throw new NotImplementedException();
            return true;
        }


   }
}
