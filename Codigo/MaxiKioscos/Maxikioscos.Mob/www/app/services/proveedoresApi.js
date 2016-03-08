(function () {
    'use strict';

    angular.module('maxikioscosApp').service('proveedoresApi', proveedoresApi);

    proveedoresApi.$inject = ['httpService', 'maxikioscosService'];

    function proveedoresApi(httpService, maxikioscosService) {
        var srv = this;

        srv.initialize = initialize;
        srv.getAll = getAll;

        function initiliaze(){

        };

        function getAll() {
            return httpService.doGet('http://' + maxikioscosService.maxiKioscoStatus.machineName + '/api/provider/')
           .then(function(response){
                return response;
           }, function(response){
                return null;
           });  
        };      

        srv.initialize();  
    };
})();