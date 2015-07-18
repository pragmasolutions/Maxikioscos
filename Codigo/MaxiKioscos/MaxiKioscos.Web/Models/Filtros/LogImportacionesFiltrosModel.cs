using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MaxiKioscos.Entidades;
using MaxiKioscos.Reportes.Enumeraciones;

namespace MaxiKioscos.Web.Models
{
    public class LogImportacionesFiltrosModel : IFilter<Importacion>
    {
        [DisplayName("Desde")]
        [UIHint("Date")]
        public DateTime? Desde { get; set; }

        [DisplayName("Hasta")]
        [UIHint("Date")]
        public DateTime? Hasta { get; set; }

        [DisplayName("MaxiKiosco")]
        [UIHint("MaxiKiosco")]
        public int? MaxiKioscoId { get; set; }

        public Expression<Func<Importacion, bool>> GetFilterExpression()
        {
            return i => (!this.Desde.HasValue || this.Desde.Value <= i.Fecha)
                        && (!this.Hasta.HasValue || this.Hasta.Value >= i.Fecha)
                        && (!this.MaxiKioscoId.HasValue || this.MaxiKioscoId == i.MaxiKiosco.MaxiKioscoId);
        }
    }
}