var reportesVentasPorCierre = function () {
    var $formRefreshReport = $("#FrmActualizarReporte"),
    init = function () {
        $('#Fecha').datepicker({
            format: "dd/mm/yyyy",
        }).on('changeDate', function (ev) {
            obtenerCierresCaja();
            $(this).datepicker('hide');
        });

        $('#MaxikioscoId').change(obtenerCierresCaja);
        maxikioscoSpinner.stopSpin();
        
        $('.panel-body').on('submit', 'form', submit);
    },
    obtenerCierresCaja = function () {
        var fecha = $('#Fecha').val();
        var maxikioscoId = $('#MaxikioscoId').val();
            
        $('#CierreCajaId').empty();
        $('#CierreCajaId').append('<option value="">Seleccione Cierre Caja</option>');

        if (fecha && maxikioscoId) {
            dataservice.excepciones.obtenerCierresCaja(maxikioscoId, fecha, function (cierres) {
                for (var i = 0; i < cierres.length; i++) {
                    var cierre = cierres[i];
                    $('#CierreCajaId').append('<option value="' + cierre.CierreCajaId + '">' + cierre.Nombre + '</option>');
                }
                $('#CierreCajaId').removeAttr('disabled');
            });
        } else {
            $('#CierreCajaId').attr('disabled', 'disabled');
        }
    },
    submit = function () {
        var url = '/Reportes/GenerarVentasPorCierreCaja';
        var data = $formRefreshReport.serialize();
        url += '?' + data;
        $(this).attr('href', url);

        $('#ReporteIframe').attr('src', url);
        return false;
    };

    init();
}();