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
                $("#MaxikioscoId", $formRefreshReport).val('').attr('disabled', 'disabled');

            } else {
                $("#MaxikioscoId", $formRefreshReport).removeAttr('disabled');
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