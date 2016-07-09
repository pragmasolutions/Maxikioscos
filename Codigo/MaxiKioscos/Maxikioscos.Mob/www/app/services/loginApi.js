(function() {
    'use strict';

    angular.module('maxikioscosApp').service('loginApi', loginApi);

    loginApi.$inject = ['httpService', 'SERVICE_CONSTANTS', 'maxikioscosService', '$rootScope', 'EVENTS_CONSTANTS', 'localStorageService'];

    function loginApi(httpService, SERVICE_CONSTANTS, maxikioscosService, $rootScope, EVENTS_CONSTANTS, localStorageService) {
        var srv = this;

        srv.login = login;
        srv.logOut = logOut;
        srv.fillAuthData = fillAuthData;

        var _authentication = {
            isAuth: false,
            userName: "",
            userId: null
        };

        srv.authentication = _authentication;

        function fillAuthData() {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentication.isAuth = true;
                _authentication.userId = authData.userId;
                _authentication.userName = authData.userName;
            }
        };

        function logOut() {

            return httpService.doPost(SERVICE_CONSTANTS.LOGOFF).then(function() {
                localStorageService.remove('authorizationData');
                _authentication.isAuth = false;
                _authentication.userName = "";
                _authentication.userId = null;
            })
        };

        function login(username, password) {
            var param = {
                UserName: username,
                Password: password
            };

            return httpService.doPost(SERVICE_CONSTANTS.LOGIN, param)
                .then(function(response) {
                    if (!response.Error) {
                        maxikioscosService.maxiKioscoStatus.UserId = response.UserId;

                        localStorageService.set('authorizationData', {
                            userId: response.UserId,
                            userName: username
                        });

                        _authentication.isAuth = true;
                        _authentication.userName = username;
                        _authentication.userId = response.UserId;

                        return response;
                    }

                    return response;
                }, function(error) {
                    return {
                        Error: 'No se encuentra el servicio o este está fuera de linea.'
                    };
                });
        };
    };
})();
