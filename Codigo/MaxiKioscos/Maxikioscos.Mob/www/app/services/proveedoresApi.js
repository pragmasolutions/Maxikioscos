(function () {
    'use strict';

    angular.module('maxikioscosApp').service('proveedoresApi', proveedoresApi);

    proveedoresApi.$inject = ['httpService', 'maxikioscosService', 'SERVICE_CONSTANTS'];

    function proveedoresApi(httpService, maxikioscosService, SERVICE_CONSTANTS) {
        var srv = this;

        srv.initialize = initialize;
        srv.getAll = getAll;

        function initialize(){

        };

        function getAll() {            
            return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.MARCAS_LIST)
                       .then(function(response){
                            return response;
                       }, function(response){
                            return {Error: response.data.ExceptionMessage};
                   });  
        };      

        srv.initialize();  
    };
})();