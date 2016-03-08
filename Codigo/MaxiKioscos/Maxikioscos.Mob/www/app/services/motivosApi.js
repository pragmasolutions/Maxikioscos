(function () {
    'use strict';

    angular.module('maxikioscosApp').service('motivosApi', motivosApi);

    motivosApi.$inject = ['httpService', 'maxikioscosService'];

    function motivosApi(httpService, maxikioscosService) {
        var srv = this;

        srv.initialize = initialize;
        srv.getAll = getAll;

        function initiliaze(){

        };

        function getAll() {
           return httpService.doGet('http://' + maxikioscosService.maxiKioscoStatus.machineName + '/api/motivos/')
           .then(function(response){
                return response;
           }, function(response){
                return null;
           });
        };      

        srv.initialize(); 
    };
})();