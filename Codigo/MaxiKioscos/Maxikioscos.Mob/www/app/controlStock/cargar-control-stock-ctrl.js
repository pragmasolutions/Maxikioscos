(function () {
    'use strict';

    angular.module('maxikioscosApp').controller('CargarControlStockCtrl', 

        ['$scope', '$q', '$rootScope', '$state','$timeout','$cordovaBarcodeScanner', '$ionicScrollDelegate', '$ionicPosition', 
         'controlStockApi', 'motivosApi', CargarControlStockCtrl]);

    function CargarControlStockCtrl($scope, $q, $rootScope, $state,$timeout,$cordovaBarcodeScanner, $ionicScrollDelegate, $ionicPosition, controlStockApi, motivosApi) {
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
                codigo : x.codigo,
                nombre: x.nombre,
                stockActual: x.stockActual,
                motivo: null,
                diferencia : null
            }
        });

        function resaltarProducto(barcode){
            var producto = _.find(vm.productos, function(x) { return x.codigo == barcode; });

                if (producto && producto.codigo) {

                    var filaProducto = angular.element(document.getElementById(producto.codigo));

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

            $cordovaBarcodeScanner.scan().then(function (imageData) {
                var barcode = imageData.text;
                
                resaltarProducto(barcode);
                                
            }, function (err) {
                // An error occured. Show a message to the user
                alert("Error scanning: " + err);
            });
        };

        vm.aceptarClick = function (productos) {

            //TODO: ask for confirmation
            if (true) {

                controlStockApi.cargarControlStock(productos);

                $state.go("app.home");
            }
        };
    };
})();