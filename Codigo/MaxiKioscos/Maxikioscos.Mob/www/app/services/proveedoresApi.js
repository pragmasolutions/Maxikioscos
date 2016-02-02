(function () {
    'use strict';

    angular.module('maxikioscosApp').factory('proveedoresApi', ['$http', '$q', '$ionicLoading', proveedoresApi]);

    function proveedoresApi($http, $q, $ionicLoading) {
        var self = this;

        function getAll() {
            var deferred = $q.defer();

            //$ionicLoading.show({
            //    template: 'Loading...'
            //});
            //$http.post("http://maxikioscos/api/proveedores", { username: username, password: password })
            //    .success(function (data) {
            //        $ionicLoading.hide();
            //        deferred.resolve(data);
            //    })
            //    .error(function () {
            //         $ionicLoading.hide();  
            //       deferred.reject();
            //    });

            var proveedores = [
                {
                    id: 1,
                    nombre: 'PROVEEDOR 1'
                },
                {
                    id: 2,
                    nombre: 'PROVEEDOR 2'
                }
            ];

            deferred.resolve(proveedores);

            return deferred.promise;
        };

        return {
            getAll: getAll
        };
    };
})();