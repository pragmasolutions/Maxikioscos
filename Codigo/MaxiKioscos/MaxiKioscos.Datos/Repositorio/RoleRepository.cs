using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class RoleRepository : EFSimpleRepository<Role>, IRoleRepository
    {
        public RoleRepository() { }

        public RoleRepository(DbContext context) : base(context) { }

        public IQueryable<Role> Listado()
        {
            return MaxiKioscosEntities.webpages_Roles.Include(r => r.ReporteRoles).Include(r => r.ReporteRoles.Select(rr => rr.Reporte));
        }

        public override Role Obtener(int roleId)
        {
            return MaxiKioscosEntities.webpages_Roles.Include(r => r.ReporteRoles).Include(r => r.ReporteRoles.Select(rr => rr.Reporte))
                        .FirstOrDefault(r => r.RoleId == roleId);
        }
    }
}
