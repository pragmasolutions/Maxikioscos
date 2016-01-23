(function () {
    'use strict';

    angular.module('maxikioscosApp').factory('rubrosApi', ['$http', '$q', '$ionicLoading', rubrosApi]);

    function rubrosApi($http, $q, $ionicLoading) {
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

            var rubros = [
                {
                    id: 1,
                    nombre: 'RUBRO 1'
                },
                {
                    id: 2,
                    nombre: 'RUBRO 2'
                }
            ];

            deferred.resolve(rubros);

            return deferred.promise;
        };

        return {
            getAll: getAll
        };
    };
})();