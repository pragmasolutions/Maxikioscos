(function () {

    angular.module("maxikioscosApp")
        .service('marcaService', marcaService);

    marcaService.$inject = ['httpService', 'SERVICE_CONSTANTS', 'maxikioscosService'];

    function marcaService(httpService, SERVICE_CONSTANTS, maxikioscosService) {
        var srv = this;

        srv.getAllMarcas = getAllMarcas;

        function getAllMarcas() {
            return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.MARCAS_LIST)
                        .then(function(response){
                            return response;
                        });            
        }
    }

})();