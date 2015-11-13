using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class ReporteStockRepository : EFSimpleRepository<ReporteStock>, IReporteStockRepository
    {
        public ReporteStockRepository() { }

        public ReporteStockRepository(DbContext context) : base(context) { }

        public ReporteStock Obtener(int mes, int anio)
        {
            return MaxiKioscosEntities.ReportesStock.FirstOrDefault(x => x.Mes == mes && x.Anio == anio);
        }
        
        public void Crear(ReporteStock reporte)
        {
            MaxiKioscosEntities.ReportesStock.Add(reporte);
        }
    }
}
