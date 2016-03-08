(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('ControlStockVistaPreviaCtrl', ['$scope', '$rootScope', '$state', 'controlStockApi', ControlStockVistaPreviaCtrl]);

    function ControlStockVistaPreviaCtrl($scope, controlStockApi) {
        var vm = this;

        vm.productosFiltrados = [];
        vm.criterios = $scope.criterios || {};

        controlStockApi.getVistaPrevia(vm.criterios)
            .then(function(productosControlStock) {
                vm.productos = productosControlStock;
                vm.productosFiltrados = vm.productos;

                vm.criterios.desdeFila = 1;
                vm.criterios.hastaFila = vm.productos.length;
            });

        vm.aceptarClick = function(criterios) {

            //TODO: ask for confirmation
            if (true) {

                $rootScope.productosFiltrados = vm.productosFiltrados;

                $state.go("app.cargarControlStock");
            }
        };

        vm.filtrarProductos = function(desde, hasta) {
            vm.productosFiltrados = vm.productos.filter(function (x) { return (!desde || x.fila >= desde) && (!hasta || x.fila <= hasta) });
        }
    };
})();