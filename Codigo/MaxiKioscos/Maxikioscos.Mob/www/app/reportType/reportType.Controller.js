(function(){

	angular.module('maxikioscoApp').controller('reportTypeController', reportTypeController);

	reportTypeController.$inject = ['$scope'];

	function reportTypeController($scope){
		var vm = this;

		vm.reportsType = [
			{
				Name: 'Por lote'
			},
			{
				Name: 'Manual'
			}
		]

		vm.goToForBatch = goToForBatch;
		vm.goToManual = goToManual;

		function goToForBatch(){
			$scope.sharedCtrl.goToControlStockVistaPrevia():
		}

		function goToManual(){
			
		}
	}
})();