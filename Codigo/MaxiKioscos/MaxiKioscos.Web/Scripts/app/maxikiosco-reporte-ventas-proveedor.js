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
                $("#MaxiKioscoId", $formRefreshReport).val('').attr('disabled', 'disabled');

            } else {
                $("#MaxiKioscoId", $formRefreshReport).removeAttr('disabled');
            }
        };

    init();
}();