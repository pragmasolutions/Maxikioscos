(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('GenerarControlStockCtrl', GenerarControlStockCtrl);

    GenerarControlStockCtrl.$inject = ['$scope', '$rootScope', 'proveedoresApi', 'rubrosApi', 'maxikioscosService', '$ionicPopup'];

    function GenerarControlStockCtrl($scope, $rootScope, proveedoresApi, rubrosApi, maxikioscosService, $ionicPopup) {
        var vm = this;
        
        vm.criterios={};
        vm.initialize = initialize;
        vm.proveedores = null;
        vm.rubros = null;
        vm.getAllProveedores = getAllProveedores;
        vm.getAllRubros = getAllRubros;
        vm.validateProveedor = validateProveedor;
        vm.validateRubro = validateRubro;
        
        vm.criterios.proveedorSeleccionado = null;
        vm.criterios.rubroSeleccionado = null;
        vm.criterios.excluirStockCero = false;
        vm.criterios.soloMasVendidos = false;
        vm.criterios.cantidadFilas = '';
        vm.generarClick = generarClick;
        vm.soloMasVendidosChanged = soloMasVendidosChanged;

        function initialize(){
            vm.getAllProveedores();
            vm.getAllRubros();
        }

        function validateProveedor(){
            if(vm.criterios.proveedorSeleccionado==""){
                vm.criterios.proveedorSeleccionado = null;
            }
        }

         function validateRubro(){
            if(vm.criterios.rubroSeleccionado==""){
                vm.criterios.rubroSeleccionado = null;
            }
        }

         function generarClick() {
            $rootScope.criterios = {
                                    ShopIdentifier: maxikioscosService.connection.maxikioscoId,
                                    ProviderId: vm.criterios.proveedorSeleccionado ? vm.criterios.proveedorSeleccionado : null,
                                    ProductCategoryId: vm.criterios.rubroSeleccionado ? vm.criterios.rubroSeleccionado : null,
                                    ExcludeZeroStock: vm.criterios.excluirStockCero,
                                    OnlyBestSellers: vm.criterios.soloMasVendidos,
                                    RowsAmount: vm.criterios.cantidadFilas
                                };

            $scope.sharedCtrl.goToControlStockVistaPrevia();
        }

        function soloMasVendidosChanged(){
            if (vm.criterios.soloMasVendidos) {
                vm.criterios.cantidadFilas = 20;
            }
            else {
                vm.criterios.cantidadFilas = '';
            }
        }

        function getAllProveedores() {                
            proveedoresApi.getAll().then(function(proveedores) {
                if(!proveedores.Error)
                {
                    vm.proveedores = proveedores;
                }else{
                        var alertPopup = $ionicPopup.alert({
                                 title: 'Error al obtener Proveedores',
                                 template: proveedores.Error,
                                 okText: 'Aceptar'
                               });

                               alertPopup.then(function(res) {
                                 
                               });
                    }                
            });
        };

         function getAllRubros() {
            rubrosApi.getAll().then(function (rubros) {
                if(!rubros.Error){
                    vm.rubros = rubros;
                }else{
                        var alertPopup = $ionicPopup.alert({
                                 title: 'Error al obtener Rubros',
                                 template: rubros.Error,
                                 okText: 'Aceptar'
                               });

                               alertPopup.then(function(res) {
                                 
                               });

                    }                                 
            });
        }

        vm.initialize();
    };
})();