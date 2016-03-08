(function () {
    'use strict';

    angular.module('maxikioscosApp').service('controlStockApi', controlStockApi);

    controlStockApi.$inject = ['maxikioscosService', 'httpService'];

    function controlStockApi(maxikioscosService, httpService) {
        var srv = this;
        
        srv.initialize = initialize;
        srv.getVistaPrevia = getVistaPrevia;
        srv.cargarControlStock = cargarControlStock;

        function initialize(){

        };

        function getVistaPrevia() {
            var param = { username: username, password: password };
            return httpService.doGet('http://'+ maxikioscosService.maxiKioscoStatus.machineName + '/api/rubros', param)
            .then(function(response){
                return response;
            }, function(response){
                return null;
            });
        };        

        function cargarControlStock(controlStockProductos) {
            var param = { username: username, password: password };
            return httpService.doPost('http://'+ maxikioscosService.maxiKioscoStatus.machineName + '/api/rubros', param)
            .then(function(response){
                return response;
            }, function(response){
                return null;
            });                       
        };        

        srv.initialize();
    };
})();