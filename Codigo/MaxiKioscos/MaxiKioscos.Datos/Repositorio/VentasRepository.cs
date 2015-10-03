using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class VentaRepository: EFRepository<Venta>
    {
        public VentaRepository(){}

        public VentaRepository(DbContext context) : base(context) { }

        public Venta Obtener(int ventaId)
        {
            return DbContext
                .Set<Venta>()
                .Select(v => v)
                .FirstOrDefault(v => v.VentaId== ventaId);
        }

        public List<Venta> Listado(int cuentaId)
        {
            return DbContext
                .Set<Venta>()
                .Select(v => v)
                .Where(v => cuentaId==v.CuentaId).ToList();
        }

        public int GenerarNroVenta(int maxikioscoId)
        {
            return MaxiKioscosEntities.VentaGenerarNumero(maxikioscoId).FirstOrDefault().GetValueOrDefault();

        }
    }
}
