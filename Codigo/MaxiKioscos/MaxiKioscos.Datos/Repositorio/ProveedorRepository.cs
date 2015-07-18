using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class ProveedorRepository : EFRepository<Proveedor>,IProveedorRepository
    {
        public ProveedorRepository(){}
        public ProveedorRepository(DbContext context) : base(context) { }
        
        public static void EliminarODeshabilitar(int proveedorId)
        {
            throw new NotImplementedException();
        }

        public  bool Guardar(Proveedor proveedor)

        {
           throw new NotImplementedException();
            return true;
        }

        public Proveedor Obtener(string nombreProveedor)
        {
            return DbContext
                .Set<Proveedor>()
                .Select(p => p)
                .FirstOrDefault(p => p.Nombre==nombreProveedor);
        }

        public Proveedor ProveedoresBuscar(string palabrasABuscar, bool? eliminado, int? pageSize, int? pageIndex, ObjectParameter pageTotal)
        {
            throw new NotImplementedException();
        }

        public static List<Proveedor> Buscar(string PalabrasABuscar, bool? Habilitado, int? CategoriaId, int pageSize, int pageIndex, out int totalRegistros)
        {
            throw new NotImplementedException();
        }
    }

}
