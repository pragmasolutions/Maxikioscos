using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<Role> Listado();
        Role Obtener(int roleId);
    }
}
