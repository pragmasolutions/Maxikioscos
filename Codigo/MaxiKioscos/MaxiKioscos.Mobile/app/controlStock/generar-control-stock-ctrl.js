(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('GenerarControlStockCtrl', ['$scope', '$state', 'proveedoresApi', 'rubrosApi', GenerarControlStockCtrl]);

    function GenerarControlStockCtrl($scope, $state, proveedoresApi, rubrosApi) {
        var vm = this;

        proveedoresApi.getAll().then(function(proveedores) {
            vm.proveedores = proveedores;
        });

        vm.proveedorSeleccionado = null;

        rubrosApi.getAll().then(function (rubros) {
            vm.rubros = rubros;
        });

        vm.rubroSeccionado = null;

        vm.excluirStockCero = false;
        vm.soloMasVendidos = false;

        vm.CantidadFilas = 20;
    };
})();