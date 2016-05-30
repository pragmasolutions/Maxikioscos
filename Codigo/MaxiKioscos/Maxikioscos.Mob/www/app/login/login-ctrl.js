(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('LoginCtrl', LoginCtrl);

    LoginCtrl.$inject = ['$rootScope', '$scope', 'loginApi', 'maxikioscosService', 'EVENTS_CONSTANTS'];

    function LoginCtrl($rootScope, $scope, loginApi, maxikioscosService, EVENTS_CONSTANTS) {
        var vm = this;

        vm.signIn = signIn;        
        vm.message = '';

        vm.authorization = {
            username: '',
            password: ''
        };

        function signIn(form) {
            if (form.$valid) {
                loginApi.login(vm.authorization.username, vm.authorization.password)
                    .then(function (data) {
                        if(!data.Error){
                            $scope.sharedCtrl.isWebOnline = true;
                            $scope.sharedCtrl.isLogged = true;                             
                            $scope.sharedCtrl.goToHome();    
                        }else{
                            vm.message = data.Error;
                        }                        
                    });
            }
        };        
    };
})();