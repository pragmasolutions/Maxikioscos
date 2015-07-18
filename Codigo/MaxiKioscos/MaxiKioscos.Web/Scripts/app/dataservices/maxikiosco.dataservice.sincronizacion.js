var dataservice = dataservice || {};

dataservice.sincronizacion = function () {

    var _aplicacionBase = '/Sincronizacion/',
         exportar = function (callback) {
             maxikioscoSpinner.startSpin();
             return $.ajax({
                 type: "POST",
                 url: _aplicacionBase + 'Exportar',
                 contentType: 'application/x-www-form-urlencoded',
                 traditional: true,
                 complete: maxikioscoSpinner.stopSpin
             }).always(callback);
         };

    return {
        exportar: exportar
    };
}();