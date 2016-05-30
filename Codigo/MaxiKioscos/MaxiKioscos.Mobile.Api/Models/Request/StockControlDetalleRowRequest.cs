using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaxiKioscos.Entidades;

namespace MaxiKioscos.Mobile.Api.Models.Request
{
    public class StockControlDetalleRowRequest 
    {
        public int StockId { get; set; }
        public string Producto { get; set; }
        public string Codigo { get; set; }
        public decimal StockActual { get; set; }
        public System.DateTime FechaUltimaModificacion { get; set; }
        public bool Desincronizado { get; set; }
        public bool Eliminado { get; set; }
        public System.Guid Identifier { get; set; }
        public bool HabilitadoParaCorregir { get; set; }
        public int? MotivoCorreccionId { get; set; }
        public int? Diferencia { get; set; }
    }
}