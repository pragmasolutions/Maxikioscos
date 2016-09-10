(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('SettingsCtrl', 

        ['maxikioscosService', SettingsCtrl]);

    function SettingsCtrl(maxikioscosService) {
        var vm = this;

        vm.maxiKioscoStatus =  maxikioscosService.maxiKioscoStatus;
    };        
})();