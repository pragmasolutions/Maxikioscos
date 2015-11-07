using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Interfaces
{
    public interface IReporteStockRepository
    {
        ReporteStock Obtener(int mes, int anio);

        ReporteStock Obtener(int id);

        void Crear(ReporteStock reporte);

        IQueryable<ReporteStock> Listado();
    }
}
