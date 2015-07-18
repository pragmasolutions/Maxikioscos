using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
   public class RubroRepository: EFRepository<Rubro>
   {
       public RubroRepository(){}

        public RubroRepository(DbContext context) : base(context) { }

        public Rubro Obtener(int rubroId)
        {
            return DbContext
                .Set<Rubro>()
                .Select(u => u)
                .FirstOrDefault(u => u.RubroId==rubroId);
        }

        public List<Rubro> Listado(string descripcion)
        {
            return DbContext
                .Set<Rubro>()
                .Select(u => u)
                .Where(u => u.Descripcion.Contains(descripcion)).ToList();
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
