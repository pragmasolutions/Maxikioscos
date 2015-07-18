using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class MarcaRepository :EFRepository<Marca>
    {
        public MarcaRepository(){}

        public MarcaRepository(DbContext context) : base(context) { }

        public Marca Obtener(int marcaId)
        {
            return DbContext
                .Set<Marca>()
                .Select(u => u)
                .FirstOrDefault(u => u.MarcaId==marcaId);
        }

        public List<Marca> Listado(string descripcion)
        {
            return DbContext
                .Set<Marca>()
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
