(function () {
    'use strict';

    angular.module('maxikioscosApp').service('rubrosApi', rubrosApi);

    rubrosApi.$inject = ['httpService', 'maxikioscosService'];

    function rubrosApi(httpService, maxikioscosService) {
        var srv = this;

        srv.initialize = initialize;
        srv.getAll = getAll;

        function initiliaze(){

        };

        function getAll() {
            return httpService.doGet('http://' + maxikioscosService.maxiKioscoStatus.machineName + '/api/rubros/')
           .then(function(response){
                return response;
           }, function(response){
                return null;
           });  
        };      

        srv.initialize();      
    };
})();