(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('CargarControlStockCtrl', ['$scope', '$rootScope', '$state', 'controlStockApi', 'motivosApi', CargarControlStockCtrl]);

    function CargarControlStockCtrl($scope, $rootScope, $state, controlStockApi, motivosApi) {
        var vm = this;

        motivosApi.getAll()
            .then(function (motivos) {
                vm.motivos = motivos;
            });

        var productosFiltrados = $rootScope.productosFiltrados || [];

        vm.productos = productosFiltrados.map(function (x) {
            return {
                id: x.id,
                fila : x.fila,
                nombre: x.nombre,
                stockActual: x.stockActual,
                motivo: null,
                diferencia : null
            }
        });

        vm.aceptarClick = function (productos) {

            //TODO: ask for confirmation
            if (true) {

                controlStockApi.cargarControlStock(productos);

                $state.go("app.home");
            }
        };
    };
})();