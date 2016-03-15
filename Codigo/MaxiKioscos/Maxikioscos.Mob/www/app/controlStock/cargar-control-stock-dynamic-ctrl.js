(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('CargarControlStockDynamicCtrl', 
        ['$scope', '$timeout','$cordovaBarcodeScanner', '$ionicScrollDelegate', '$ionicPosition', 'controlStockApi', 
        'motivosApi', '$ionicPopup', CargarControlStockDynamicCtrl]);

    function CargarControlStockDynamicCtrl($scope, $timeout, $cordovaBarcodeScanner, controlStockApi, motivosApi, $ionicPopup, $ionicScrollDelegate, $ionicPosition) {
        var vm = this;
        
        vm.criterios = {};
        vm.guardar = guardar;
        vm.getMotivos = getMotivos;
        vm.initialize = initialize;
        vm.resaltarProducto = resaltarProducto;
        vm.buscarProductoClick = buscarProductoClick;

        function initialize(){
            vm.getMotivos();
        }

        function getMotivos(){
            motivosApi.getAll()
            .then(function (motivos) {
                vm.motivos = motivos;
            });
        }

        vm.productos = [];        

        function resaltarProducto(barcode){

            var filaProducto = angular.element(document.getElementById(barcode));

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

        function buscarProductoClick() {            
            $cordovaBarcodeScanner
            .scan()
            .then(function (imageData) {
                var barcode = imageData.text;                
                controlStockApi.getProductByCode(barcode)
                .then(function(response){
                    if(response){
                        vm.productos.push(response);
                        vm.resaltarProducto(vm.productos.length);
                    }else{
                        var alertPopup = $ionicPopup.alert({
                                 title: 'Error al Buscar..',
                                 template: 'Se ha producido un error. Intente nuevamente.'
                            });

                        alertPopup.then(function(res) {
                         
                       });
                    }
                });                        
            }, function (err) {
                // An error occured. Show a message to the user                
                alert("Error scanning: " + err);
            });                           
        };

         function guardar() {            
            var confirmPopup = $ionicPopup.confirm({
                     title: 'Guardar listado',
                    template: '¿Está seguro de que desea guardar el listado?'
                });
               confirmPopup.then(function(res) {
                     if(res) {
                        
                       controlStockApi.cerrarControlStock(vm.productos)
                       .then(function(response){
                            if(response){
                                $scope.sharedCtrl.goToChooseReportType();
                            }else{
                               var alertPopup = $ionicPopup.alert({
                                 title: 'Error al Guardar',
                                 template: 'Se ha producido un error. Intente nuevamente.'
                               });

                               alertPopup.then(function(res) {
                                 
                               });
                            }                            
                       });
                     }
               });            
                
            }

        vm.initialize();
    };        
})();