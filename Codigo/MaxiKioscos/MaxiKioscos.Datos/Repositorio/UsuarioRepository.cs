using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Sync
{
    public class UsuarioRepository : EFRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository() { }

        public UsuarioRepository(DbContext context) : base(context) { }

        public Usuario Obtener(string nombreUsuario)
        {
            return DbContext
                .Set<Usuario>()
                .Select(u => u)
                .Include(u => u.Cuenta)
                .Include(u => u.Cuenta.MaxiKioscos)
                .Include(u => u.Roles)
                .Include(u => u.Roles.Select(r => r.ReporteRoles))
                .Include(u => u.Roles.Select(r => r.ReporteRoles.Select(rr => rr.Reporte)))
                .Include(u => u.Roles.Select(r => r.PermisoRoles))
                .Include(u => u.Roles.Select(r => r.PermisoRoles.Select(rr => rr.Permiso)))
                .FirstOrDefault(u => u.NombreUsuario.ToLower() == nombreUsuario);
        }

        public IQueryable<Usuario> ListadoPorCuenta(int cuentaId, params Expression<Func<Usuario, object>>[] includes)
        {
            var dbset = DbContext.Set<Usuario>().AsQueryable();
            dbset = includes.Aggregate(dbset, (current, include) => current.Include(include));

            return dbset.Where(u => u.CuentaId == cuentaId);
        }

        public void InsertarDependencias(Usuario usuario, int roleId)
        {
            MaxiKioscosEntities.UsuarioInsertarDependencias(usuario.UsuarioId,
                                                        roleId,
                                                        usuario.ProveedoresIdsListado);
        }

        #region IUsuarioRepository Members


        public IQueryable<Role> RolesListado()
        {
            return MaxiKioscosEntities.webpages_Roles.Include(r => r.ReporteRoles).Include(r => r.ReporteRoles.Select(rr => rr.Reporte));
        }

        #endregion

        public Membresia ObtenerMembresia(int usuarioId)
        {
            return MaxiKioscosEntities.UsuarioObtenerMembresia(usuarioId).FirstOrDefault();
        }

        public virtual Usuario Obtener(Expression<Func<Usuario, bool>> whereClause, params Expression<Func<Usuario, object>>[] includes)
        {
            var dbset = DbSet.Where(e => !e.Eliminado).AsQueryable();
            foreach (var include in includes)
            {
                dbset = dbset.Include(include);
            }
            return dbset.FirstOrDefault(whereClause);
        }


        public void CambiarPassword(int usuarioId, string encondedPassword, DateTime changedDate)
        {
            MaxiKioscosEntities.UsuarioCambiarPassword(usuarioId, encondedPassword, changedDate);
        }
    }
}
