(function(){
'use strict';

	angular.module('maxikioscosApp').controller('homeCtrl', homeCtrl);

	homeCtrl.$inject = ['$scope', 'maxikioscosService'];

	function homeCtrl($scope, maxikioscosService){
		var vm = this;
		
		vm.reload = reload;

		vm.initialize = initialize;

		function initialize(){			
			if (maxikioscosService.maxiKioscoStatus.isWebOnline){				
				$scope.sharedCtrl.goToChooseMaxikiosco();
			}			
		}

		function reload(){
			$scope.sharedCtrl.validateWebMasterAcess();
		}
		
		vm.initialize();
	}

})();