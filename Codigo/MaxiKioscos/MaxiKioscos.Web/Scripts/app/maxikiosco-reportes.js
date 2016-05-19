var reportes = function () {
    var $formRefreshReport = $("#FrmActualizarReporte"),
        downloadsCount = 0,
        originalUrlBase,
        init = function () {

            $("#ButtonsPanel").on('click', 'a.download-report', descargar);
            
            //Reparse form validation.
            controles.parse('#AdminContainer');
        },
        descargar = function () {
            var url = $(this).attr('href');
            if (downloadsCount == 0) {
                originalUrlBase = url;
                downloadsCount++;
            } else {
                if (url.indexOf(originalUrlBase) == -1) {
                    originalUrlBase = url;
                }
            }

            var data = $formRefreshReport.serialize();
            url = originalUrlBase + '&' + data;
            $(this).attr('href', url);
        };

    init();
}();