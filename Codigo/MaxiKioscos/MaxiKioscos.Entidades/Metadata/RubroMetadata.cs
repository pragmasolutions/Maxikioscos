using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MaxiKiosco.Win.Util;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(RubroMetadata))]
    public partial class Rubro : IEntity, IComboBoxDataSourceItem
    {
        #region IComboBoxDataSourceItem Members

        public int GetValue()
        {
            return RubroId;
        }

        public string GetText()
        {
            return Descripcion;
        }

        #endregion
    }

    public class RubroMetadata
    {
        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Debe ingresar una descripción")]
        [Remote("EsDescripcionRubroUnica", "Rubros", ErrorMessage = "Ya existe un rubro con esa descripción.", AdditionalFields = "RubroId")]
        public string Descripcion { get; set; }

        [DisplayName("No Facturar")]
        public bool NoFacturar { get; set; }
    }
}
