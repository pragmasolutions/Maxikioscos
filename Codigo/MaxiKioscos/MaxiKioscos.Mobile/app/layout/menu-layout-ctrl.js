(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('MenuCtrl', ['$scope', '$ionicSideMenuDelegate', MenuCtrl]);

    function MenuCtrl($scope, $ionicSideMenuDelegate) {
   
        $scope.openMenu = function () {
            $ionicSideMenuDelegate.toggleLeft();
        };
    };
})();