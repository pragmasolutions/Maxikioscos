using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(ControlStockMetadata))]
    public partial class ControlStock : IEntity
    {
        public string NroControlFormateado
        {
            get
            {
                return String.Format("{0}{1}", this.MaxiKiosco.Abreviacion, this.NroControl); 
            }
        }

        public string Estado
        {
            get { return this.Cerrado ? "Cerrado" : "Abierto"; }
        }

        public string ProveedorNombre
        {
            get
            {
                if (ProveedorId == null)
                    return string.Empty;
                return Proveedor.Nombre;
            }
        }

        public string RubroDescripcion
        {
            get
            {
                if (RubroId == null)
                    return string.Empty;
                return Rubro.Descripcion;
            }
        }

        public string Parametros
        {
            get
            {
                return String.Format("{0} [Fila {1} hasta {2}]",
                    MasVendidos 
                        ? String.Format("{0} más vendidos", CantidadFilas) 
                        : "Todos",
                    LimiteInferior,
                    LimiteSuperior);
            }
        }
    }

    public class ControlStockMetadata 
    {
        [Display(Name = "Nro Control")]
        public string NroControlFormateado { get; set; }

        [Display(Name = "Fecha Creación")]
        [UIHint("CompleteDate")]
        public DateTime FechaCreacion { get; set; }
    }
}
