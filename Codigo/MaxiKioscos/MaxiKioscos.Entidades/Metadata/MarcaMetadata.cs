using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MaxiKiosco.Win.Util;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(MarcaMetadata))]
    public partial class Marca : IEntity, IComboBoxDataSourceItem
    {
        #region IComboBoxDataSourceItem Members

        public int GetValue()
        {
            return MarcaId;
        }

        public string GetText()
        {
            return Descripcion;
        }

        #endregion
    }

    public class MarcaMetadata
    {
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [Remote("EsDescripcionMarcaUnica", "Marcas", ErrorMessage = "Ya existe una marca con esa descripción.")]
        public string Descripcion { get; set; }
    }
}
