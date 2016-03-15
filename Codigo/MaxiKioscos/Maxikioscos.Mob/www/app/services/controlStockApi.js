(function () {
    'use strict';

    angular.module('maxikioscosApp').service('controlStockApi', controlStockApi);

    controlStockApi.$inject = ['maxikioscosService', 'httpService', 'SERVICE_CONSTANTS'];

    function controlStockApi(maxikioscosService, httpService, SERVICE_CONSTANTS) {
        var srv = this;
        
        srv.getVistaPrevia = getVistaPrevia;
        srv.cerrarControlStock = cerrarControlStock;
        srv.getDetalleFinal = getDetalleFinal;

        function getVistaPrevia(controlStockCriterios) {
            var param = {  ShopIdentifier: controlStockCriterios.ShopIdentifier,
                            ProviderId: controlStockCriterios.ProviderId  || null,
                            ProductCategoryId: controlStockCriterios.ProductCategoryId  || null,
                            ExcludeZeroStock: controlStockCriterios.ExcludeZeroStock  || null,
                            OnlyBestSellers: controlStockCriterios.OnlyBestSellers  || null,
                            RowsAmount: controlStockCriterios.RowsAmount || null};
            return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.STOCK_CONTROL, param)
            .then(function(response){
                return response.List;
            }, function(response){
                return null;
            });
        };        

         function getProductByCode(code) {
            var param = {  code: code,
                            maxikioscoId: maxikioscosService.maxiKioscoStatus.maxikioscoId
                        };
            return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.PRODUCTS_BY_CODE, param)
            .then(function(response){
                return response;
            }, function(response){
                return null;
            });
        };

        function cerrarControlStock(controlStock) {                 
            return httpService.doPost(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.STOCK_CONTROL_CERRAR, controlStock)
            .then(function(response){
                return response;
            }, function(response){
                return null;
            });                       
        };

         function cerrarControlStockDinamico(controlStockDetalle) { 
            var param = {
                            ControlStockDetalle: controlStockDetalle
                        }                
            return httpService.doPost(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.STOCK_CONTROL_DINAMICO_CERRAR, param)
            .then(function(response){
                return response;
            }, function(response){
                return null;
            });                       
        };

        function getDetalleFinal(controlStockCriterios) {
            var param = {  ShopIdentifier: controlStockCriterios.ShopIdentifier,
                            ProviderId: controlStockCriterios.ProviderId  || null,
                            ProductCategoryId: controlStockCriterios.ProductCategoryId  || null,
                            ExcludeZeroStock: controlStockCriterios.ExcludeZeroStock  || null,
                            OnlyBestSellers: controlStockCriterios.OnlyBestSellers  || null,
                            RowsAmount: controlStockCriterios.RowsAmount || null,
                            LowerLimit: controlStockCriterios.LowerLimit || null,
                            UpperLimit: controlStockCriterios.UpperLimit || null
                        };
            return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.STOCK_CONTROL_DETALLE, param)
            .then(function(response){
                return response;
            }, function(response){
                return null;
            });
        };                 
    };
})();