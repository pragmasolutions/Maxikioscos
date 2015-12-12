using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync
{
   public class CierreCajaRepository: EFRepository<CierreCaja>
   {
       public CierreCajaRepository(){}

       public CierreCajaRepository(DbContext context) : base(context) { }

        public CierreCaja ObtenerUltimo()
        {
            return DbContext
                .Set<CierreCaja>()
                .Select(c => c)
                .LastOrDefault();
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
