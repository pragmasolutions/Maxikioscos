(function(){

	angular.module('maxikioscosApp').controller('reportTypeController', reportTypeController);

	reportTypeController.$inject = ['$scope'];

	function reportTypeController($scope){
		var vm = this;

		vm.reportsType = [
			{
				Name: 'Autómatico'
			},
			{
				Name: 'Manual'
			}
		]

		vm.goTo = goTo;		

		function goTo(index){
			if (index == 0){
				$scope.sharedCtrl.goToGenerarControlStock();	
			}			
		}		
	}
})();