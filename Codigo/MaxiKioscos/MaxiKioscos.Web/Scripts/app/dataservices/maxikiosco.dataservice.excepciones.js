var dataservice = dataservice || {};

dataservice.excepciones = function () {

    var _aplicacionBase = '/Excepciones/',
         obtenerCierresCaja = function (maxiKioscoId, fecha, callback) {
             maxikioscoSpinner.startSpin();
             return $.ajax({
                 type: "GET",
                 url: _aplicacionBase + 'ObtenerCierresCaja',
                 contentType: 'application/x-www-form-urlencoded',
                 data: {
                     fecha: fecha,
                     maxikioscoId: maxiKioscoId
                 },
                 traditional: true,
                 complete: maxikioscoSpinner.stopSpin
             }).always(callback);
         };

    return {
        obtenerCierresCaja: obtenerCierresCaja
    };
}();