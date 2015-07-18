var dataservice = dataservice || {};

dataservice.usuarios = function () {

    var _aplicacionBase = '/Usuarios/',
         setearMaxikioscoDefaultId = function (maxiKioscoId, callback) {
             return $.ajax({
                 type: "POST",
                 url: _aplicacionBase + 'SetearMaxikioscoDefaultId',
                 contentType: 'application/x-www-form-urlencoded',
                 data: {
                     maxiKioscoDefaultId: maxiKioscoId
                 },
                 traditional: true
             }).always(callback);
         };

    return {
        setearMaxikioscoDefaultId: setearMaxikioscoDefaultId
    };
}();