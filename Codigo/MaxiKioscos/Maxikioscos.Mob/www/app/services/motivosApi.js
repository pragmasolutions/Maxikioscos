(function () {
    'use strict';

    angular.module('maxikioscosApp').service('motivosApi', motivosApi);

    motivosApi.$inject = ['httpService', 'maxikioscosService', 'SERVICE_CONSTANTS'];

    function motivosApi(httpService, maxikioscosService, SERVICE_CONSTANTS) {
        var srv = this;

        srv.initialize = initialize;
        srv.getAll = getAll;

        function initialize(){

        };

        function getAll() {
           return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.MOTIVOS_LIST)
           .then(function(response){
                return response;
           }, function(response){
                return null;
           });
        };      

        srv.initialize(); 
    };
})();