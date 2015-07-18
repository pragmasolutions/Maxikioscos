var sincronizacionAjax = function () {
    var init = function () {
            $('.btn-forzar-sincronizacion').click(forzarSincronizacion);
            $('[data-toggle="tooltip"]').tooltip();
        },
        forzarSincronizacion = function () {
            var url = $(this).attr('href');

            bootbox.confirm("Esta seguro que desea forzar la sincronización de todos los kioscos conectados?", function (confirm) {
                if (confirm) {
                    //Forzar sincronizacion
                    $.ajax(url, { type: "POST" })
                        .done(function (result) {
                            if (result.exito) {
                                refreshList();
                            } else {
                                alert(result);
                            }
                        });
                }
            });

            return false;
        },
        refreshList = function () {
            var url = '/Sincronizacion/EstadoKioscos';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function () {
                maxikioscoSpinner.stopSpin();
            });
        };
    init();
}();