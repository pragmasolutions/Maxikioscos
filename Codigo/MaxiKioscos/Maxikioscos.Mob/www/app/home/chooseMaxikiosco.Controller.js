(function(){
'use strict';

	angular.module('maxikioscosApp').controller('chooseMaxikioscoCtrl', chooseMaxikioscoCtrl);

	chooseMaxikioscoCtrl.$inject = ['$scope', 'maxikioscosService'];

	function chooseMaxikioscoCtrl($scope, maxikioscosService){
		var vm = this;

		vm.maxikioscosList = {};
		vm.selectedMaxikiosco = undefined;
		vm.setMaxikiosco = setMaxikiosco;

		vm.initialize = initialize;

		function initialize(){						
			// maxikioscosService.getMaxikioscos()
			// .then(function(response){
			// 	vm.maxikioscosList = response;
			// });							
			$scope.sharedCtrl.validateMaxikioscoAcess();
		}

		function setMaxikiosco(maxikiosco){
			//maxikioscosService.urlLocalService(maxikiosco);			
			$scope.sharedCtrl.validateMaxikioscoAcess();
		};			

		vm.initialize();
	}

})();