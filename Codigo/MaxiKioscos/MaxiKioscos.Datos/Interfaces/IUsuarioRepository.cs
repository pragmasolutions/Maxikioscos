using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        /// <summary>
        /// Get <see cref="Speaker"/>s at sessions.
        /// </summary>
        /// <remarks>
        /// <see cref="Speaker"/> is a subset of  
        /// <see cref="Person"/> properties suitable for 
        /// quick client-side filtering and presentation.
        /// </remarks>
        Usuario Obtener(string nombreUsuario);

        IQueryable<Usuario> ListadoPorCuenta(int cuentaId, params Expression<Func<Usuario, object>>[] includes);

        IQueryable<Role> RolesListado();

        void InsertarDependencias(Usuario usuario, int roleId);

        void CambiarPassword(int usuarioId, string encondedPassword, DateTime changedDate);
    }
}
