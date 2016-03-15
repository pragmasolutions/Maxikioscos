(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('CargarControlStockCtrl', 

        ['$scope', '$q', '$rootScope', '$state','$timeout','$cordovaBarcodeScanner', '$ionicScrollDelegate', '$ionicPosition', 
         'controlStockApi', 'motivosApi', '$ionicPopup', CargarControlStockCtrl]);

    function CargarControlStockCtrl($scope, $q, $rootScope, $state,$timeout,$cordovaBarcodeScanner, $ionicScrollDelegate, $ionicPosition, controlStockApi, motivosApi, $ionicPopup) {
        var vm = this;

        vm.criterios = $rootScope.criterios || {};
        vm.guardar = guardar;
        vm.getMotivos = getMotivos;
        vm.initialize = initialize;

        function initialize(){
            vm.getMotivos();
        }

        function getMotivos(){
            motivosApi.getAll()
            .then(function (motivos) {
                vm.motivos = motivos;
            });
        }

        var productosFiltrados = $rootScope.productosFiltrados || [];

        vm.productos = productosFiltrados.map(function (x) {
            return {
                StockId: x.StockId,                      
                Codigo : x.Codigo,
                Producto: x.Producto,
                StockActual: x.StockActual,
                FechaUltimaModificacion: x.FechaUltimaModificacion,
                Eliminado: x.Eliminado,
                Identifier: x.Identifier,
                Desincronizado: x.Desincronizado,
                HabilitadoParaCorregir: x.HabilitadoParaCorregir,
                MotivoCorreccionId: null,
                Diferencia : 0
            }
        });

        function resaltarProducto(barcode){
            var producto = _.find(vm.productos, function(x) { return x.Codigo == barcode; });

                if (producto && producto.Codigo) {

                    var filaProducto = angular.element(document.getElementById(producto.Codigo));

                    if (filaProducto) {

                        //Buscar producto en el listado para hacerle foco a la fila.
                        var productoPosicion = $ionicPosition.offset(filaProducto);

                        filaProducto.addClass('highlighted-row');

                        $timeout(function(){
                             filaProducto.removeClass('highlighted-row');
                        }, 2000);

                        $ionicScrollDelegate.scrollTo(productoPosicion.left, productoPosicion.top, true);
                    }
                }
        }

        vm.buscarProductoClick = function () {            
            $cordovaBarcodeScanner
            .scan()
            .then(function (imageData) {
                var barcode = imageData.text;                
                resaltarProducto(barcode);                            
            }, function (err) {
                // An error occured. Show a message to the user                
                alert("Error scanning: " + err);
            });                           
        };

         function guardar() {
            vm.criterios.ControlStockDetalle = vm.productos;
            var confirmPopup = $ionicPopup.confirm({
                     title: 'Guardar listado',
                    template: '¿Está seguro de que desea guardar el listado?'
                });

               confirmPopup.then(function(res) {
                     if(res) {
                       controlStockApi.cerrarControlStock(vm.criterios)
                       .then(function(response){
                            if(response){
                                $scope.sharedCtrl.goToChooseReportType();
                            }else{
                                //MOSTRAR ERROR
                            }                            
                       });
                     }
               });            
                
            }

        vm.initialize();
    };        
})();