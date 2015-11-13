var maxikioscoAjax = function () {
    var init = function () {
        $("#TableReportesStock").on('click', 'a.btn-reporte-stock-detalle', detalle);
        },
        detalle = function () {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        cargarVista = function (url) {
            
            maxikioscoSpinner.startSpin();
            $('#AdminContainer').load(url, function () {
                maxikioscoSpinner.stopSpin();
                validacion.parse('#AdminContainer');
                controles.parse('#AdminContainer');
                $("#AdminContainer").on('click', 'a.btn-volver', function (){
                    var url = $(this).attr('href');
                    cargarVista(url);
                    return false;
                });

                $("#TableReportesStockDetalle").on('click', 'a.btn-stock-valorizado', function () {
                    var url = $(this).attr('href');
                    cargarReporte(url);
                    return false;
                });
                return false;
            });
            return false;
        },
        cargarReporte = function(url) {
            $('#ReportContainer').show();
            $('#ReportContainer iframe').attr('src', url);
        };
    init();
}();