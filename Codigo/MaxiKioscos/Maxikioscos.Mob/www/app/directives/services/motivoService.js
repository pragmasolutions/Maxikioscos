(function () {

    angular.module("maxikioscosApp")
        .service('motivoService', motivoService);

    motivoService.$inject = ['httpService', 'SERVICE_CONSTANTS', 'maxikioscosService'];

    function motivoService(httpService, SERVICE_CONSTANTS, maxikioscosService) {
        var srv = this;

        srv.getAllMotivos = getAllMotivos;

        function getAllMotivos() {
            return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.MOTIVOS_LIST)
                        .then(function(response){
                            return response;
                        });            
        }
    }

})();