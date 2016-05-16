(function(){
'use strict';

	angular.module('maxikioscosApp').controller('homeCtrl', homeCtrl);

	homeCtrl.$inject = ['$scope', 'maxikioscosService', 'httpService', 'SERVICE_CONSTANTS'];

	function homeCtrl($scope, maxikioscosService, httpService, SERVICE_CONSTANTS){
		var vm = this;
		
		vm.reload = reload;
		vm.maxikioscoAvailable = true;
		vm.initialize = initialize;
		vm.connect = connect;
		vm.isConnected = false;

		function initialize(){			
			if (!$scope.sharedCtrl.isLogged){				
				$scope.sharedCtrl.goToLogin();
			}
		}

		function connect(){
			httpService.doGet(maxikioscosService.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.MAXIKIOSCO_IDENTIFIER)
			.then(function(response){
				if (response != null){
					vm.isConnected = true;
					maxikioscosService.maxiKioscoStatus.maxikioscoId = response.Identifier;		
				}else{
					vm.maxikioscoAvailable = false;
					vm.isConnected = false;
				}                 
			});			
		}

		function reload(){
			vm.connect();
		}
		
		vm.initialize();
	}

})();