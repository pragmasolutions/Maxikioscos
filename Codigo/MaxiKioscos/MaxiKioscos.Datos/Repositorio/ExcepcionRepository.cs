using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync
{
    public class ExcepcionRepository: EFRepository<Excepcion>
    {
        public ExcepcionRepository(){}

        public ExcepcionRepository(DbContext context) : base(context) { }

        public Excepcion Obtener(int excepcionId)
        {
            return DbContext
                .Set<Excepcion>()
                .Select(e => e)
                .LastOrDefault(e => e.ExcepcionId== excepcionId);
        }

        public List<Excepcion> Listado(int cierreCajaId)
        {
            return DbContext
                .Set<Excepcion>()
                .Select(e => e)
                .Where(e => cierreCajaId==e.CierreCajaId).ToList();
        }

        public static void EliminarODeshabilitar(int ventaId)
        {
            throw new NotImplementedException();
        }

        public static bool Guardar(Venta venta)
        {
            throw new NotImplementedException();
            return true;
        }
    }
}
