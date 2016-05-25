var reportesSugerencias = function () {
    var $formRefreshReport = $("#FrmActualizarReporte"),
    init = function () {
        maxikioscoSpinner.stopSpin();
        
        validacion.parse('#FrmActualizarReporte');
        controles.parse('#FrmActualizarReporte');
        $('.panel-body').on('submit', 'form', submit);
    },
    submit = function () {
        debugger;
        if ($('#MaxiKioscoId').val() && $('#ProveedorId').val() && $('#Dias').val()) {
            var url = '/Reportes/GenerarSugerenciaComprasPorProveedor';
            var data = $formRefreshReport.serialize();
            url += '?' + data;
            $(this).attr('href', url);

            $('#ReporteIframe').attr('src', url);
        }
        return false;
    };

    init();
}();