using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IProveedorRepository : IRepository<Proveedor>
    {
        /// <summary>
        /// Get <see cref="Speaker"/>s at sessions.
        /// </summary>
        /// <remarks>
        /// <see cref="Speaker"/> is a subset of  
        /// <see cref="Person"/> properties suitable for 
        /// quick client-side filtering and presentation.
        /// </remarks>
        Proveedor Obtener(string nombreProveedor);

        Proveedor ProveedoresBuscar(string palabrasABuscar, Nullable<bool> eliminado, Nullable<int> pageSize,
                                    Nullable<int> pageIndex, ObjectParameter pageTotal);
    }
}
