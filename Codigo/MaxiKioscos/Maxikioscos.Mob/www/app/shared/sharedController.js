(function () {
    angular.module('maxikioscosApp').controller('sharedController', sharedController);

    sharedController.$inject = ['$state', 'maxikioscosService', '$scope', 'httpService', 'SERVICE_CONSTANTS'];

    function sharedController($state, maxikioscosService, $scope, httpService, SERVICE_CONSTANTS) {
        var vm = this;

        vm.isLogged = false;

        vm.currentSection = "HOME";                      
        
        vm.goToHome = goToHome;

        vm.goToLogin = goToLogin;

        vm.goToLogOff = goToLogOff;

    	//generarControlStock
        vm.goToGenerarControlStock = goToGenerarControlStock;        
        //controlStockVistaPrevia
        vm.goToControlStockVistaPrevia = goToControlStockVistaPrevia;
    	//cargarControlStock
    	vm.goToCargarControlStock = goToCargarControlStock;

        vm.goToCargarControlStockDinamico = goToCargarControlStockDinamico;

        vm.initialize = initialize;

        vm.validateLogin = validateLogin;
              

        function initialize() {
            maxikioscosService.validateMaxikioscoAccess();
            maxikioscosService.validateWebMasterAccess();
        }

        function goToHome() {      
            vm.validateLogin("app.home");                  
        }

        function goToLogin() {            
            vm.currentSection = "LOGIN";
            $state.go("app.login");
        }

        function goToLogOff(){
            return httpService.doPost(SERVICE_CONSTANTS.LOGOFF)
            .then(function(response){
                vm.isLogged = false;
                vm.goToLogin();
            }, function(error){
                return error;
            });
        }

        function goToGenerarControlStock() {
            vm.validateLogin("app.generarControlStock");            
        }

        function goToControlStockVistaPrevia() {
            vm.validateLogin("app.controlStockVistaPrevia");             
        }

       function goToCargarControlStock() {
            vm.validateLogin("app.cargarControlStock");             
        }

        function goToCargarControlStockDinamico() {
            vm.validateLogin("app.cargarControlStockDinamico");             
        }
       
       function validateLogin(page){
            if(!vm.isLogged){
                vm.goToLogin();
            }else{
                $state.go(page);
            }
       }

        vm.initialize();
    }
})();