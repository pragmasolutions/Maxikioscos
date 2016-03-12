(function () {
    angular.module('maxikioscosApp').controller('sharedController', sharedController);

    sharedController.$inject = ['$state', 'maxikioscosService', '$scope', 'httpService', 'SERVICE_CONSTANTS'];

    function sharedController($state, maxikioscosService, $scope, httpService, SERVICE_CONSTANTS) {
        var vm = this;

        vm.currentSection = "HOME";               

        vm.validateMaxikioscoAcess = validateMaxikioscoAcess;

        vm.validateWebMasterAcess = validateWebMasterAcess;
        
        vm.goToHome = goToHome;
    	//generarControlStock
        vm.goToGenerarControlStock = goToGenerarControlStock;        
        //controlStockVistaPrevia
        vm.goToControlStockVistaPrevia = goToControlStockVistaPrevia;
    	//cargarControlStock
    	vm.goToCargarControlStock = goToCargarControlStock;

        vm.goToChooseReportType = goToChooseReportType;

        vm.goToChooseMaxikiosco = goToChooseMaxikiosco;

        vm.initialize = initialize;
              

        function initialize() {
            //vm.validateWebMasterAcess(); 
        }

        function goToHome() {
            vm.currentSection = "HOME";
            $state.go("app.home");
        }

        function goToGenerarControlStock() {
            vm.currentSection = "Generar Control Stock";
             $state.go("app.generarControlStock");
        }

        function goToControlStockVistaPrevia() {
            vm.currentSection = "Control StockVista Previa";
             $state.go("app.controlStockVistaPrevia");
        }

       function goToCargarControlStock() {
            vm.currentSection = "Cargar Control Stock";
             $state.go("app.cargarControlStock");
        }

        function goToChooseReportType() {
            vm.currentSection = "Seleccionar";
             $state.go("app.chooseReportType");
        }

        function goToChooseMaxikiosco() {
            vm.currentSection = "Seleccionar";
             $state.go("app.chooseMaxikiosco");
        }

        function validateMaxikioscoAcess() {
            // httpService.doPing(SERVICE_CONSTANTS.PROTOCOL_SERVICE + maxikioscosService.maxiKioscoStatus.machineName + SERVICE_CONSTANTS.PORT, function(response){
            //     maxikioscosService.maxiKioscoStatus.isLocalServiceOnline = response;
            //     if(response){
                    vm.goToChooseReportType();             
            //     }else{
            //         vm.goToHome();
            //         return;
            //     }            
            // });    		
        }       

        function validateWebMasterAcess(){                            
            httpService.doPing(SERVICE_CONSTANTS.URL_MASTER_SERVICE + 'MaxiKioscosService.svc', function(response){
                maxikioscosService.maxiKioscoStatus.isWebOnline = response;
                if(response){
                    vm.goToChooseMaxikiosco();    
                }else{
                    vm.goToHome();
                    return;                
                }                
            });
        }

        vm.initialize();
    }
})();