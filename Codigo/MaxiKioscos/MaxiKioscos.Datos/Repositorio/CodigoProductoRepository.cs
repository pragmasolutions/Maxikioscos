using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class CodigoProductoRepository: EFRepository<CodigoProducto>
    {
        public CodigoProductoRepository(){}

        public CodigoProductoRepository(DbContext context) : base(context) { }

        public CodigoProducto Obtener(int codigoProductoId)
        {
            return DbContext
                .Set<CodigoProducto>()
                .Select(u => u)
                .FirstOrDefault(u => u.CodigoProductoId == codigoProductoId);
        }

        public CodigoProducto Obtener(string codigo)
        {
            return DbContext
                .Set<CodigoProducto>()
                .Select(u => u)
                .Include("Producto")
                .FirstOrDefault(u => u.Codigo.Contains(codigo));
        }

        public List<CodigoProducto> Listado(int productoId)
        {
            return DbContext
                .Set<CodigoProducto>()
                .Select(p => p)
                .Where(p =>productoId==p.ProductoId).ToList();
        }

        public static void EliminarODeshabilitar(int productoId)
        {
            throw new NotImplementedException();
        }

        public static bool Guardar(Producto producto)
        {
            throw new NotImplementedException();
            return true;
        }
    }
}
