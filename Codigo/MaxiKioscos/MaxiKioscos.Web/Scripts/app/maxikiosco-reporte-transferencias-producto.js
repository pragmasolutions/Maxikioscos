var reportes = function () {
    var $formRefreshReport = $("#FrmActualizarReporte"),
        init = function () {

            $("#MostrarTotalGeneral").click(function () {

                toggleSelectMaxikioscos();

                $formRefreshReport.submit();
            });

            toggleSelectMaxikioscos();
        },
        toggleSelectMaxikioscos = function () {
            if ($("#MostrarTotalGeneral").is(':checked')) {
                $("#MaxiKioscoOrigenId", $formRefreshReport).val('').attr('disabled', 'disabled');
                $("#MaxiKioscoDestinoId", $formRefreshReport).val('').attr('disabled', 'disabled');

            } else {
                $("#MaxiKioscoOrigenId", $formRefreshReport).removeAttr('disabled');
                $("#MaxiKioscoDestinoId", $formRefreshReport).removeAttr('disabled');
            }
        };

    init();
}();