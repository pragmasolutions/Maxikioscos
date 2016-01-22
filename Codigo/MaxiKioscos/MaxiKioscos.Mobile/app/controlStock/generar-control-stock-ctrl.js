(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('GenerarControlStockCtrl', ['$scope', '$state', 'proveedoresApi', GenerarControlStockCtrl]);

    function GenerarControlStockCtrl($scope, $state, proveedoresApi) {
        var vm = this;

        proveedoresApi.getAll().then(function(proveedores) {
            vm.proveedores = proveedores;
        });

        vm.proveedorSeleccionado = null;
    };
})();