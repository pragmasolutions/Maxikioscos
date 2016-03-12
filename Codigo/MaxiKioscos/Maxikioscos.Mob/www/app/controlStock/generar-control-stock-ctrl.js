(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('GenerarControlStockCtrl', GenerarControlStockCtrl);

    GenerarControlStockCtrl.$inject = ['$scope', '$rootScope', 'proveedoresApi', 'rubrosApi', 'maxikioscosService'];

    function GenerarControlStockCtrl($scope, $rootScope, proveedoresApi, rubrosApi, maxikioscosService) {
        var vm = this;
        
        vm.criterios={};
        vm.initialize = initialize;
        vm.proveedores = null;
        vm.rubros = null;
        vm.getAllProveedores = getAllProveedores;
        vm.getAllRubros = getAllRubros;
        
        vm.criterios.proveedorSeleccionado = null;
        vm.criterios.rubroSeleccionado = null;
        vm.criterios.excluirStockCero = false;
        vm.criterios.soloMasVendidos = false;
        vm.criterios.cantidadFilas = 20;
        vm.generarClick = generarClick;

        function initialize(){
            vm.getAllProveedores();
            vm.getAllRubros();
        }

         function generarClick() {
            $rootScope.criterios = {
                                    ShopIdentifier: maxikioscosService.maxiKioscoStatus.maxikioscoId,
                                    ProviderId: vm.criterios.proveedorSeleccionado ? vm.criterios.proveedorSeleccionado : null,
                                    ProductCategoryId: vm.criterios.rubroSeleccionado ? vm.criterios.rubroSeleccionado : null,
                                    ExcludeZeroStock: vm.criterios.excluirStockCero,
                                    OnlyBestSellers: vm.criterios.soloMasVendidos,
                                    RowsAmount: vm.criterios.cantidadFilas
                                };

            $scope.sharedCtrl.goToControlStockVistaPrevia();
        };

         function getAllProveedores() {                
            proveedoresApi.getAll().then(function(proveedores) {
                vm.proveedores = proveedores;
            });
        };

         function getAllRubros() {
            rubrosApi.getAll().then(function (rubros) {
                vm.rubros = rubros;
            });
        }

        vm.initialize();
    };
})();