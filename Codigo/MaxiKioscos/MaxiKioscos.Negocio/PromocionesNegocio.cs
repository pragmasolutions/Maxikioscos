using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxiKioscos.Datos.Interfaces;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Negocio
{
    public class PromocionesNegocio : IPromocionesNegocio
    {
        private IMaxiKioscosUow Uow { get; set; }

        public PromocionesNegocio(IMaxiKioscosUow uow)
        {
            Uow = uow;
        }

        public List<PromocionMaxikiosco> ObtenerStock(int productoId)
        {
            var maxikioscos = Uow.MaxiKioscos.Listado().ToList();
            var stocks = Uow.Stocks.Listado().Where(s => s.ProductoId == productoId).ToList();

            var lista = new List<PromocionMaxikiosco>();
            foreach (var maxi in maxikioscos)
            {
                var stock = stocks.FirstOrDefault(s => s.MaxiKioscoId == maxi.MaxiKioscoId);
                var cant = stock == null ? 0 : stock.StockActual;

                lista.Add(new PromocionMaxikiosco{
                    MaxiKioscoId = maxi.MaxiKioscoId,
                    MaxiKioscoNombre = maxi.Nombre,
                    StockActual = Convert.ToInt32(cant),
                    StockAnterior = Convert.ToInt32(cant)
                });
            }
            return lista;
        }
    }
}
