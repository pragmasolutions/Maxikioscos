(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('GenerarControlStockCtrl', ['$scope', '$state', '$rootScope', 'proveedoresApi', 'rubrosApi', GenerarControlStockCtrl]);

    function GenerarControlStockCtrl($scope, $state, $rootScope, proveedoresApi, rubrosApi) {
        var vm = this;

        proveedoresApi.getAll().then(function(proveedores) {
            vm.proveedores = proveedores;
        });

        vm.criterios = { };

        vm.criterios.proveedorSeleccionado = null;

        rubrosApi.getAll().then(function (rubros) {
            vm.rubros = rubros;
        });

        vm.criterios.rubroSeccionado = null;
        vm.criterios.excluirStockCero = false;
        vm.criterios.soloMasVendidos = false;
        vm.criterios.CantidadFilas = 20;

        vm.generarClick = function(criterios) {
            $rootScope.criterios = criterios;

            $state.go("app.controlStockVistaPrevia");
        };
    };
})();