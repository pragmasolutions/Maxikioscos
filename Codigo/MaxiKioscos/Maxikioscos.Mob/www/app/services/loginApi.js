(function () {
    'use strict';

    angular.module('maxikioscosApp').service('loginApi', loginApi);

    loginApi.$inject = ['httpService', 'SERVICE_CONSTANTS','maxikioscosService', '$rootScope', 'EVENTS_CONSTANTS'];

    function loginApi(httpService, SERVICE_CONSTANTS, maxikioscosService, $rootScope, EVENTS_CONSTANTS) {
        var srv = this;

        srv.login = login;        

        function login(username, password) {
            var param = {
                            UserName: username,
                            Password:  password
                        };

            return httpService.doPost(SERVICE_CONSTANTS.LOGIN, param)
            .then(function(response){
                if (!response.Error){                    
                    maxikioscosService.maxiKioscoStatus.UserId = response.UserId;
                    return response;
                }            

                return response;
            }, function(error){
                return {
                            Error: 'No se encuentra el servicio o este está fuera de linea.'
                        };
            });
        };           
    };
})();