using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaxiKioscos.Entidades
{
    [MetadataType(typeof(CuentaMetadata))]
    public partial class Cuenta : IEntity
    {
    }

    public class CuentaMetadata
    {
        [DisplayName("Margen Máximo de Importe de Factura")]
        [UIHint("Currency")]
        [Required(ErrorMessage = "Debe ingresar una margen")]
        public decimal? MargenImporteFactura { get; set; }

        [DisplayName("Aplicar Percepcion IVA Desde los")]
        [UIHint("Currency")]
        [Required(ErrorMessage = "Debe ingresar una monto")]
        public decimal? AplicarPercepcionIVADesde { get; set; }

        [DisplayName("Porcentaje Percepcion IVA")]
        [UIHint("Percentage")]
        [Required(ErrorMessage = "Debe ingresar una margen")]
        public decimal? PorcentajePercepcionIVA { get; set; }

        [DisplayName("Motivo de Corrección por defecto")]
        [UIHint("MotivoCorreccion")]
        [Required(ErrorMessage = "Debe seleccionar un motivo")]
        public int MotivoCorreccionPorDefecto { get; set; }

        [DisplayName("Margen inferior aceptable para cierres de caja")]
        [UIHint("Currency")]
        [Required(ErrorMessage = "Debe ingresar un margen inferior")]
        public decimal MargenInferiorCierreCajaAceptable { get; set; }

        [DisplayName("Margen superior aceptable para cierres de caja")]
        [UIHint("Currency")]
        [Required(ErrorMessage = "Debe ingresar un margen superior")]
        public decimal MargenSuperiorCierreCajaAceptable { get; set; }

        [DisplayName("Kiosco Origen de Transferencias Predeterminado")]
        [UIHint("MaxiKioscoIdentifier")]
        public Guid? MaxiKioscoIdentifierPredeterminadoTransferencias { get; set; }

        [DisplayName("Sincronizar Automáticamente")]
        [UIHint("BooleanSiNo")]
        [Required(ErrorMessage = "Debe ingresar un valor")]
        public bool? SincronizarAutomaticamente { get; set; }

        [DisplayName("Intervalo de Sincronización (en minutos)")]
        [Range(60, int.MaxValue, ErrorMessage = "El intervalo debe ser mayor o igual a 60")]
        public int? IntervaloSincronizacion { get; set; }

        [DisplayName("Límite máximo de retiro de personal")]
        [Range(1, int.MaxValue, ErrorMessage = "El límite debe ser mayor o igual a 1")]
        public decimal? LimiteMaximoRetiroPersonal { get; set; }
    }
}
