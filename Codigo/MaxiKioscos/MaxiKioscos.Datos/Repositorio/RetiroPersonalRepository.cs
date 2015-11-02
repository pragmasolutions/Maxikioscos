using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Datos.Repositorio
{
    public class RetiroPersonalRepository: EFRepository<RetiroPersonal>
    {
        public RetiroPersonalRepository(){}

        public RetiroPersonalRepository(DbContext context) : base(context) { }

        public RetiroPersonal Obtener(int retiroPersonalId)
        {
            return DbContext
                .Set<RetiroPersonal>()
                .Select(v => v)
                .FirstOrDefault(v => v.RetiroPersonalId == retiroPersonalId);
        }

        public List<RetiroPersonal> Listado()
        {
            return DbContext
                .Set<RetiroPersonal>()
                .Select(v => v).ToList();
        }

        public int GenerarNroRetiroPersonal(int maxikioscoId)
        {
            return MaxiKioscosEntities.RetiroPersonalGenerarNumero(maxikioscoId).FirstOrDefault().GetValueOrDefault();

        }

        public decimal CalcularGastadoEnPeriodo(int usuarioId)
        {
            var primero = this.Listado(c => c.CierreCaja).Where(x => !x.Eliminado && x.CierreCaja.UsuarioId == usuarioId)
                                                                .OrderBy(x => x.FechaRetiroPersonal).FirstOrDefault();
            if (primero == null)
                return 0;

            var primerFecha = new DateTime(primero.FechaRetiroPersonal.Year, primero.FechaRetiroPersonal.Month, primero.FechaRetiroPersonal.Day, 0, 0, 0, 0);
            var diferenciaEnDias = DateTime.Now.Subtract(primerFecha).TotalDays;
            var resto = diferenciaEnDias % 14;

            var fechaInicio = DateTime.Now.AddDays(resto * -1);
            return this.Listado(c => c.CierreCaja).Where(x => !x.Eliminado
                                                              && x.CierreCaja.UsuarioId == usuarioId
                                                              && x.FechaRetiroPersonal >= fechaInicio)
                                                    .Select(x => x.ImporteTotal)
                                                              .DefaultIfEmpty(0)
                                                    .Sum();
        }
    }
}
