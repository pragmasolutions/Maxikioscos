using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Entidades
{
    public partial class ProductoTransferenciaDesktop : IComparable
    {
        public string Filter { get; set; }

        public List<string> Codigos
        {
            get { return Codigo.Split(',').ToList(); }
        }

        public string PrecioUnitarioFormateado
        {
            get
            {
                string precio;
                precio = (Precio%1) == 0
                                ? Precio.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "") 
                                : Precio.ToString("N2");
                return String.Format("${0}", precio);
            }
        }

        public string StockActualFormateado
        {
            get
            {
                string stock = (StockActual % 1) == 0
                                ? StockActual.GetValueOrDefault().ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : StockActual.GetValueOrDefault().ToString("N2");
                return stock;
            }
        }

        public string TotalFormateado
        {
            get
            {
                string precio = (Precio % 1) == 0
                                ? Precio.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : Precio.ToString("N2");
                return String.Format("${0}", precio);
            }
        }

        public string VendidoEnUltimoMesFormateado
        {
            get
            {
                return (VendidoEnUltimoMes % 1) == 0
                                ? VendidoEnUltimoMes.GetValueOrDefault().ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : VendidoEnUltimoMes.GetValueOrDefault().ToString("N2");
            }
        }


        public int CompareTo(object obj)
        {
            var other = (ProductoTransferenciaDesktop)obj;
            if (other == null)
                return 1;

            var lista = new List<KeyValuePair<int, string>>();
            foreach (var codigo in Codigos.Where(c => c.ToLower().StartsWith(Filter)))
            {
                lista.Add(new KeyValuePair<int, string>(ProductoId, codigo));
            }
            foreach (var codigo in other.Codigos.Where(c => c.ToLower().StartsWith(Filter)))
            {
                lista.Add(new KeyValuePair<int, string>(other.ProductoId, codigo));
            }

            var listaOrdenada = lista.OrderBy(p => p.Value).ToList();
            return listaOrdenada.First().Key == other.ProductoId ? 1 : -1;
        }
    }
}
