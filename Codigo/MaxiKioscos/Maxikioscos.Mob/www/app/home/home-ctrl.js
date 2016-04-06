(function(){
'use strict';

	angular.module('maxikioscosApp').controller('homeCtrl', homeCtrl);

	homeCtrl.$inject = ['$scope', 'maxikioscosService', 'httpService'];

	function homeCtrl($scope, maxikioscosService, httpService){
		var vm = this;
		
		vm.reload = reload;
		vm.maxikioscoAvailable = maxikioscosService.maxiKioscoStatus.isLocalServiceOnline;
		vm.initialize = initialize;

		function initialize(){			
			if (!$scope.sharedCtrl.isLogged){				
				$scope.sharedCtrl.goToLogin();
			}			
		}

		function reload(){
			httpService.doPing(maxikioscosService.maxiKioscoStatus.urlLocalService, function(response){
                 vm.maxikioscoAvailable = response;                 
            });
		}
		
		vm.initialize();
	}

})();