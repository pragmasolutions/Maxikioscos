(function () {
    'use strict';

    angular.module('maxikioscosApp').factory('motivosApi', ['$http', '$q', '$ionicLoading', motivosApi]);

    function motivosApi($http, $q, $ionicLoading) {
        var self = this;

        function getAll() {
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

            var motivos = [
                {
                    id: 1,
                    nombre: 'MOTIVO 1'
                },
                {
                    id: 2,
                    nombre: 'MOTIVO 2'
                },
                {
                    id: 2,
                    nombre: 'MOTIVO 3'
                }
            ];

            deferred.resolve(motivos);

            return deferred.promise;
        };

        return {
            getAll: getAll
        };
    };
})();