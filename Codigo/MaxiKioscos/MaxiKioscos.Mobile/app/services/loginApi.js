(function () {
    'use strict';

    angular.module('maxikioscosApp').factory('loginApi', ['$http', '$q', '$ionicLoading', loginApi]);

    function loginApi($http, $q, $ionicLoading) {
        var self = this;

        function login(username, password) {
            var deferred = $q.defer();

            //$http.post("http://maxikioscos/api/login", { username: username, password: password })
            //    .success(function (data) {
            //        deferred.resolve(data);
            //    })
            //    .error(function () {
            //        deferred.reject();
            //    });

            deferred.resolve(true);

            return deferred.promise;
        };

        return {
            login: login
        };
    };
})();