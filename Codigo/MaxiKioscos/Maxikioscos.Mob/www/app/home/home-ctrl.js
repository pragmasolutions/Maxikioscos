(function(){
'use strict';

	angular.module('maxikioscosApp').controller('homeCtrl', homeCtrl);

	homeCtrl.$inject = ['$scope', 'maxikioscosService'];

	function homeCtrl($scope, maxikioscosService){
		var vm = this;

		vm.maxikioscosList = {};
		vm.selectedMaxikiosco = undefined;
		vm.setMaxikiosco = setMaxikiosco;

		vm.initialize = initialize;

		function initialize(){
			$scope.sharedCtrl.validateWebMasterAcess();
				
		}

		function setMaxikiosco(maxikiosco){
			maxikioscosService.maxiKioscoStatus.maxikioscoId = maxikiosco.Identifier;
			maxikioscosService.maxiKioscoStatus.machineName = maxikiosco.MachineName;
				
		};

	vm.initialize();
	}

})();