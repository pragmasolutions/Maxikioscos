(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('LoginCtrl', ['$scope', '$state', 'loginApi', LoginCtrl]);

    function LoginCtrl($scope, $state, loginApi) {
        var vm = this;

        vm.authorization = {
            username: '',
            password: ''
        };

        vm.signIn = function (form) {
            if (form.$valid) {

                loginApi.login(vm.authorization.username, vm.authorization.username.password)
                    .then(function (data) {
                       
                        $state.go('home');

                    }).finally(function () {
                        
                    });
            }
        };
    };
})();