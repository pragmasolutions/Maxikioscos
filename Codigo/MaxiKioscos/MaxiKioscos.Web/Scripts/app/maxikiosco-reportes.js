var reportes = function () {
    var $formRefreshReport = $("#FrmActualizarReporte"),
        init = function () {

            $("#ButtonsPanel").on('click', 'a.download-report', descargar);
            
            //Reparse form validation.
            controles.parse('#AdminContainer');
        },
        descargar = function() {
            //Descargar el reporte con los filtros espedicados
            
            var url = $(this).attr('href');
            var data = $formRefreshReport.serialize();
            url += '&' + data;
            $(this).attr('href', url);
        };

    init();
}();