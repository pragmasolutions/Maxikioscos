(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('CargarControlStockDynamicCtrl', 
        ['$scope', '$q', '$rootScope', '$state','$timeout','$cordovaBarcodeScanner', '$ionicScrollDelegate', '$ionicPosition', 'controlStockApi', 
        'motivosApi', '$ionicPopup', CargarControlStockDynamicCtrl]);

    function CargarControlStockDynamicCtrl($scope, $q, $rootScope, $state,$timeout, $cordovaBarcodeScanner, $ionicScrollDelegate, $ionicPosition, controlStockApi, motivosApi, $ionicPopup) {
        var vm = this;
        
        vm.criterios = {};
        vm.guardar = guardar;
        vm.getMotivos = getMotivos;
        vm.initialize = initialize;
        vm.resaltarProducto = resaltarProducto;
        vm.buscarProductoClick = buscarProductoClick;
        vm.buscarProductoPorCodigo = buscarProductoPorCodigo;
        vm.limpiar = limpiar;
        vm.eliminar = eliminar;

        function initialize(){
            vm.getMotivos();
        }

        function getMotivos(){
            motivosApi.getAll()
            .then(function (motivos) {
                if(!motivos.Error){
                    vm.motivos = motivos;
                }else{
                        var alertPopup = $ionicPopup.alert({
                                            title: 'Error al Buscar..',
                                            template: motivos.Error,
                                            okText: 'Aceptar'
                                        });

                        alertPopup.then(function(res) {
                         
                        });

                    }                
            });
        }

        vm.productos = [];        

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

        function limpiar(){
             var confirmPopup = $ionicPopup.confirm({
                     title: 'Limpiar listado',
                    template: '¿Está seguro de que desea limpiar el listado?',
                    okText: 'Limpiar',
                    cancelText: 'Cancelar'
                });
               confirmPopup.then(function(res) {
                     if(res) {                        
                        vm.productos = [];
                     }
               }); 
        }

        function eliminar(indice){
            var confirmPopup = $ionicPopup.confirm({
                     title: 'Eliminar producto',
                    template: '¿Está seguro de que desea eliminar el producto de la lista?',
                    okText: 'Eliminar',
                    cancelText: 'Cancelar'
                });
               confirmPopup.then(function(res) {
                     if(res) {                        
                        vm.productos.splice(indice, 1);
                     }
               }); 
        }

        function buscarProductoPorCodigo(){
            $scope.data = {}
            var inputCode = $ionicPopup.show({
                            template: '<input type="number" max-length="13" ng-model="data.code">',
                            title: 'Ingrese código',
                            subTitle: 'Longitud de 13 dígitos',
                            scope: $scope,
                            buttons: [
                              { text: 'Cancelar' },
                              {
                                text: '<b>Aceptar</b>',
                                type: 'button-positive',
                                onTap: function(e) {
                                  if ($scope.data.code.toString().length < 13 || $scope.data.code.toString().length > 13) {
                                    //don't allow the user to close unless he enters wifi password
                                    e.preventDefault();
                                  } else {
                                    controlStockApi.getProductByCode($scope.data.code.toString())
                                    .then(function(response){
                                        if(!response.Error){
                                            vm.productos.push(response);                                            
                                        }else{
                                            var alertPopup = $ionicPopup.alert({
                                                    title: 'Error al Buscar..',
                                                    template: response.Error,
                                                    okText: 'Aceptar'
                                                });

                                            alertPopup.then(function(res) {
                                             
                                           });
                                        }
                                    });
                                  }
                                }
                              }
                            ]
                          });

            inputCode.then(function(res) {
            
          });
        }

        function buscarProducto(barcode){
                                 
        }

        function buscarProductoClick() {            
            $cordovaBarcodeScanner
            .scan()
            .then(function (imageData) {
                var barcode = imageData.text;                
                controlStockApi.getProductByCode(barcode)
                .then(function(response){
                    if(!response.Error){
                        vm.productos.push(response);
                        vm.resaltarProducto(barcode);
                    }else{
                        var alertPopup = $ionicPopup.alert({
                                 title: 'Error al Buscar..',
                                 template: response.Error,
                                 okText: 'Aceptar'
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
                    template: '¿Está seguro de que desea guardar el listado?',
                    okText: 'Guardar',
                    cancelText: 'Cancelar'
                });
               confirmPopup.then(function(res) {
                     if(res) {
                        
                       controlStockApi.cerrarControlStockDinamico(vm.productos)
                       .then(function(response){
                            if(!response.Error){
                                var alertPopup = $ionicPopup.alert({
                                 title: 'Mensaje',
                                 template: 'Se ha guardado correctamente.',
                                 okText: 'Aceptar'
                               });

                               alertPopup.then(function(res) {
                                    $scope.sharedCtrl.goToHome();
                               });                                
                            }else{
                               var alertPopup = $ionicPopup.alert({
                                 title: 'Error al Guardar',
                                 template: response.Error,
                                 okText: 'Aceptar'
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