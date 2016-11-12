using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiKioscos.Entidades
{
    public class StockDto
    {
        public int ProductoId { get; set; }

        public string ProductoDescripcion { get; set; }

        public int MaxiKioscoId { get; set; }

        public string MaxiKioscoNombre { get; set; }

        public int? StockReposicion { get; set; }

        public decimal? StockActual { get; set; }
        
        public DateTime? FechaUltimaModificacion { get; set; }

        public bool DisponibleEnDeposito { get; set; }
    }
}
