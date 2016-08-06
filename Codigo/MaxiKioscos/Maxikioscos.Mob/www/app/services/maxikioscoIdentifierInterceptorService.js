(function() {
    'use strict';
    angular.module('maxikioscosApp').factory('maxikioscoIdentifierInterceptorService', ['$q', '$injector', '$location', function($q, $injector, $location) {
        var maxikioscoIdentifierInterceptorServiceFactory = {};
        var _request = function(config) {
            config.headers = config.headers || {};
            var maxikioscosService = $injector.get('maxikioscosService');
            var isLocalApiCall = config.url && config.url.indexOf('api') !== -1
            if (maxikioscosService.connection && maxikioscosService.connection.maxikioscoId && isLocalApiCall) {
                config.headers.MaxikioscoIdentifier = maxikioscosService.connection.maxikioscoId;
            }
            return config;
        }
        var _responseError = function(rejection) {
            var deferred = $q.defer();
            if (rejection.status === 409) {
                var maxikioscosService = $injector.get('maxikioscosService');
                if (maxikioscosService) {
                    maxikioscosService.removeConnectionData();
                    $location.path('/');
                }
            }

            deferred.reject(rejection);

            return deferred.promise;
        }

        maxikioscoIdentifierInterceptorServiceFactory.request = _request;
        maxikioscoIdentifierInterceptorServiceFactory.responseError = _responseError;
        return maxikioscoIdentifierInterceptorServiceFactory;
    }]);
})();
