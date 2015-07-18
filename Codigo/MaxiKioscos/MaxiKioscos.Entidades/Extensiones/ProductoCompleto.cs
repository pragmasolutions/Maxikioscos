using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Entidades
{
    public partial class ProductoCompleto : IComparable
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
                precio = (PrecioConIVA % 1) == 0
                                ? PrecioConIVA.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : PrecioConIVA.ToString("N2");
                return String.Format("${0}", precio);
            }
        }

        public string CostoConIvaFormateado
        {
            get
            {
                string costo;
                costo = (CostoConIVA % 1) == 0
                                ? CostoConIVA.GetValueOrDefault().ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : CostoConIVA.GetValueOrDefault().ToString("N2");
                return String.Format("${0}", costo);
            }
        }

        public string CostoSinIvaFormateado
        {
            get
            {
                string costo;
                costo = (CostoSinIVA % 1) == 0
                                ? CostoSinIVA.GetValueOrDefault().ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "")
                                : CostoSinIVA.GetValueOrDefault().ToString("N2");
                return String.Format("${0}", costo);
            }
        }

        public string StockFormateado
        {
            get
            {
                string stock;
                stock = (Stock % 1) == 0
                                ? Stock.ToString().Replace(",00000", "").Replace(",0000", "").Replace(".00", "").Replace(",00", "").Replace(",0", "")
                                : Stock.ToString("N2");
                return stock;
            }
        }


        public int CompareTo(object obj)
        {
            var other = (ProductoCompleto) obj;
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
