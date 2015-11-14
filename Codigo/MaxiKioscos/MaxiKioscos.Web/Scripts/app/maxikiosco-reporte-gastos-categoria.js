var reportes = function () {
    var $formRefreshReport = $("#FrmActualizarReporte"),
        init = function () {

            $("#MostrarTotalGeneral").click(function () {

                toggleSelectMaxikioscos();

                $formRefreshReport.submit();
            });

            toggleSelectMaxikioscos(); 
            toggleSelectCategoria();
            toggleSelectSubCategoria();
        },
        toggleSelectMaxikioscos = function () {
            if ($("#MostrarTotalGeneral").is(':checked')) {
                $("#MaxiKioscoId", $formRefreshReport).val('').attr('disabled', 'disabled');

            } else {
                $("#MaxiKioscoId", $formRefreshReport).removeAttr('disabled');
            }
        };

    toggleSelectCategoria = function () {
        if ($("#MostrarTotalGeneral").is(':checked')) {
            $("#CategoriaId", $formRefreshReport).val('').attr('disabled', 'disabled');

        } else {
            $("#CategoriaId", $formRefreshReport).removeAttr('disabled');
        }
    };

    toggleSelectSubCategoria = function () {
        if ($("#MostrarTotalGeneral").is(':checked')) {
            $("#SubCategoriaId", $formRefreshReport).val('').attr('disabled', 'disabled');

        } else {
            $("#SubCategoriaId", $formRefreshReport).removeAttr('disabled');
        }
    };

    init();
}();