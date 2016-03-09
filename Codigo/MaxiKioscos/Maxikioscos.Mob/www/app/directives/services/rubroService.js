(function () {

    angular.module("maxikioscosApp")
        .service('rubroService', rubroService);

    rubroService.$inject = ['httpService', 'SERVICE_CONSTANTS', 'maxikioscosService'];

    function rubroServicehttpService, SERVICE_CONSTANTS, maxikioscosService) {
        var srv = this;

        srv.getAllRubrosByMarca = getAllRubrosByMarca;

        function getAllRubrosByMarca(marcaId) {
           return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.RUBROS_LIST)
                        .then(function(response){
                            return response;
                        });    
        }
    }

})();