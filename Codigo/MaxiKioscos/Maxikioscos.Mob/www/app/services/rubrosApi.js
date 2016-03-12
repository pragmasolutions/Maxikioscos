(function () {
    'use strict';

    angular.module('maxikioscosApp').service('rubrosApi', rubrosApi);

    rubrosApi.$inject = ['httpService', 'maxikioscosService', 'SERVICE_CONSTANTS'];

    function rubrosApi(httpService, maxikioscosService, SERVICE_CONSTANTS) {
        var srv = this;

        srv.initialize = initialize;
        srv.getAll = getAll;

        function initialize(){

        };

        function getAll() {
            return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.RUBROS_LIST)
           .then(function(response){
                return response;
           }, function(response){
                return null;
           });  
        };      

        srv.initialize();      
    };
})();