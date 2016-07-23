(function () {
    'use strict';

    angular.module('maxikioscosApp').service('controlStockApi', controlStockApi);

    controlStockApi.$inject = ['maxikioscosService', 'httpService', 'SERVICE_CONSTANTS'];

    function controlStockApi(maxikioscosService, httpService, SERVICE_CONSTANTS) {
        var srv = this;
        
        srv.getVistaPrevia = getVistaPrevia;
        srv.cerrarControlStock = cerrarControlStock;
        srv.getDetalleFinal = getDetalleFinal;
        srv.getProductByCode = getProductByCode;
        srv.cerrarControlStockDinamico = cerrarControlStockDinamico;
        srv.getResume = getResume;

        function getResume(controlStockRequest){
            var param = {  
                            MaxikioscoIdentifier: maxikioscosService.connection.maxikioscoId,
                            DateFrom: controlStockRequest.DateFrom,
                            DateTo: controlStockRequest.DateTo
                        };
            return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.STOCK_CONTROL_GETRESUME, param)
            .then(function(response){
                return response;
            }, function(response){
                return {Error: response.data ? response.data.ExceptionMessage : 'Error al obtener el resumen'};
            });
        }

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
                return {Error: response.data.ExceptionMessage};
            });
        };        

         function getProductByCode(code) {
            var param = {  
                            Code: code,
                            MaxikioscoId: maxikioscosService.connection.maxikioscoId
                        };
            return httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.PRODUCTS_BY_CODE, param)
            .then(function(response){
                return response;
            }, function(response){

                if (response && response.data && response.data.ExceptionMessage) {
                    return {Error: response.data.ExceptionMessage};
                }

                if (response && response.data) {
                    return {Error: response.data};
                }

                return {Error: 'Error al obtener el producto'};
            });
        };

        function cerrarControlStock(controlStock) {                 
            return httpService.doPost(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.STOCK_CONTROL_CERRAR, controlStock)
            .then(function(response){
                return response;
            }, function(response){
                if (response && response.data && response.data.ExceptionMessage) {
                    return {Error: response.data.ExceptionMessage};
                }

                if (response && response.data) {
                    return {Error: response.data};
                }

                return {Error: 'Error al cerrar control stock'};
            });                       
        };

         function cerrarControlStockDinamico(controlStockDetalle) { 
            var param = {
                            ShopIdentifier: maxikioscosService.connection.maxikioscoId,
                            UserId: maxikioscosService.maxiKioscoStatus.UserId,
                            ProviderId: null,
                            ProductCategoryId: null,
                            ExcludeZeroStock: null,
                            OnlyBestSellers: null,
                            RowsAmount: null,
                            LowerLimit: 1,  
                            UpperLimit: controlStockDetalle.length,
                            ControlStockDetalle: controlStockDetalle
                        }                
            return httpService.doPost(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.STOCK_CONTROL_CERRAR, param)
            .then(function(response){
                return response;
            }, function(response){
                return {Error: response.data.ExceptionMessage};
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
                return {Error: response.data.ExceptionMessage};
            });
        };                 
    };
})();