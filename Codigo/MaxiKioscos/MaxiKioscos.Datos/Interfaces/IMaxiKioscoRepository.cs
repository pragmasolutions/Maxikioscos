using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IMaxiKioscoRepository
    {
        IQueryable<EstadoKiosco> EstadoMaxiKioscos(int? cuentaId);

        Entidades.MaxiKiosco Obtener(int id);

        Entidades.MaxiKiosco Obtener(Expression<Func<Entidades.MaxiKiosco, bool>> whereClause, params Expression<Func<Entidades.MaxiKiosco, object>>[] includes);

        IQueryable<Entidades.MaxiKiosco> Listado(params Expression<Func<Entidades.MaxiKiosco, object>>[] includes);

        void Agregar(Entidades.MaxiKiosco maxiKiosco);

        void Eliminar(Entidades.MaxiKiosco maxiKiosco);

        void Modificar(Entidades.MaxiKiosco maxiKiosco);
    }
}
