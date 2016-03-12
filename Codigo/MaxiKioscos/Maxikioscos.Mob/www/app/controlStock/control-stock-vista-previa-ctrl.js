(function () {    

    angular.module('maxikioscosApp').controller('ControlStockVistaPreviaCtrl', ControlStockVistaPreviaCtrl);

    ControlStockVistaPreviaCtrl.$inject = ['$scope',  '$rootScope', '$ionicPopup', 'controlStockApi', 'maxikioscosService'];

    function ControlStockVistaPreviaCtrl($scope, $rootScope, $ionicPopup, controlStockApi, maxikioscosService) {
        var vm = this;
        
        vm.productosFiltrados = [];
        vm.criterios = $rootScope.criterios || {};

        vm.initialize = initialize;
        vm.getVistaPrevia = getVistaPrevia;        
        vm.filtrarProductos = filtrarProductos;     
        vm.desdeFila = null;
        vm.hastaFila = null;
        vm.aceptarClick = aceptarClick;

        function aceptarClick() {
            var confirmPopup = $ionicPopup.confirm({
             title: 'Generar listado',
             template: '¿Está seguro de que desea generar el listado?'
           });

           confirmPopup.then(function(res) {
             if(res) {
                vm.criterios.UserId = maxikioscosService.maxiKioscoStatus.UserId;                                
                controlStockApi.getDetalleFinal(vm.criterios)
                .then(function(productosControlStock) {
                    $rootScope.productosFiltrados = productosControlStock;
                    $rootScope.criterios = vm.criterios;
                    $scope.sharedCtrl.goToCargarControlStock();                
                });
               
             }
           });            
        };       
        

        function initialize(){
            vm.getVistaPrevia();            
        }               

        function getVistaPrevia(){
           controlStockApi.getVistaPrevia(vm.criterios)
            .then(function(productosControlStock) {
                vm.productos = productosControlStock;
                vm.productosFiltrados = vm.productos;

                vm.criterios.LowerLimit = 1;
                vm.criterios.UpperLimit = vm.productos.length;
            });        
        }
        

        function generar() {              
            vm.criterios.UserId = maxikioscosService.maxiKioscoStatus.UserId;                        
            controlStockApi.cargarControlStock(vm.criterios)
            .then(function(response){
                vm.productosFiltrados = response;                
            });            
        };

         function filtrarProductos(desde, hasta) {
            vm.productosFiltrados = vm.productos.filter(function (x) { return (!desde || x.Fila >= desde) && (!hasta || x.Fila <= hasta) });
        }    

        vm.initialize();
    };
})();