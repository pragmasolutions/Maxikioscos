(function () {
    'use strict';

    angular.module('maxikioscosApp').factory('controlStockApi', ['$http', '$q', '$ionicLoading', controlStockApi]);

    function controlStockApi($http, $q, $ionicLoading) {
        var self = this;

        function getVistaPrevia() {
            var deferred = $q.defer();

            //$ionicLoading.show({
            //    template: 'Loading...'
            //});
            //$http.post("http://maxikioscos/api/rubros", { username: username, password: password })
            //    .success(function (data) {
            //        $ionicLoading.hide();
            //        deferred.resolve(data);
            //    })
            //    .error(function () {
            //         $ionicLoading.hide();  
            //       deferred.reject();
            //    });

            var productos = [
                {
                    fila: 1,
                    id: 1,
                    nombre: 'PRODUCTO 1',
                    stockActual: 5
                },
                {
                    fila: 2,
                    id: 2,
                    nombre: 'PRODUCTO 2',
                    stockActual: 7
                },
                {
                    fila: 3,
                    id: 3,
                    nombre: 'PRODUCTO 3',
                    stockActual: 0
                },
                {
                    fila: 4,
                    id: 4,
                    nombre: 'PRODUCTO 4',
                    stockActual: 2
                }
            ];

            deferred.resolve(productos);

            return deferred.promise;
        };

        function cargarControlStock(controlStockProductos) {
            var deferred = $q.defer();

            //$ionicLoading.show({
            //    template: 'Loading...'
            //});
            //$http.post("http://maxikioscos/api/rubros", { username: username, password: password })
            //    .success(function (data) {
            //        $ionicLoading.hide();
            //        deferred.resolve(data);
            //    })
            //    .error(function () {
            //         $ionicLoading.hide();  
            //       deferred.reject();
            //    });

            deferred.resolve(true);

            return deferred.promise;
        };

        return {
            getVistaPrevia: getVistaPrevia,
            cargarControlStock: cargarControlStock
        };
    };
})();