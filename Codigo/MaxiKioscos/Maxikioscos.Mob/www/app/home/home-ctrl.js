(function(){
'use strict';

	angular.module('maxikioscosApp').controller('homeCtrl', homeCtrl);

	homeCtrl.$inject = ['$scope', 'maxikioscosService', 'httpService', 'SERVICE_CONSTANTS', 'controlStockApi', '$ionicPopup','localStorageService'];

	function homeCtrl($scope, maxikioscosService, httpService, SERVICE_CONSTANTS, controlStockApi, $ionicPopup, localStorageService){
		var vm = this;

		vm.connection = maxikioscosService.connection;
		
		vm.reload = reload;
		// vm.maxikioscoAvailable = true;
		vm.initialize = initialize;
		vm.connect = connect;
		//vm.isConnected = false;
		vm.controlsResume = null;
		vm.getResume = getResume;		
		vm.getControlStockResume = getControlStockResume;
		vm.controlStockResume = {
									DateFrom: moment().add(-7, 'days').toDate(),
									DateTo: moment().toDate()
								}

		function initialize(){			
			if (!$scope.sharedCtrl.authentication.isAuth){				
				$scope.sharedCtrl.goToLogin();
			}
		}

		function getResume(filterForm){
			if(filterForm.$valid){
				vm.getControlStockResume();
			}			
		}

		function getControlStockResume(){
			controlStockApi.getResume(vm.controlStockResume)
				.then(function(response){
					if(!response.Error){
						vm.controlsResume = response;   
						for (var i = 0; i < vm.controlsResume.length; i++) {
							var cs = vm.controlsResume[i];
        					cs.showProviderCategoryClass = (cs.Proveedor && cs.Rubro) ? '' : 'hidden';
        					cs.showProviderClass = (cs.Proveedor && !cs.Rubro) ? '' : 'hidden';
        					cs.showCategoryClass = (!cs.Proveedor && cs.Rubro) ? '' : 'hidden';
        					cs.showDynamicClass = (!cs.Proveedor && !cs.Rubro) ? '' : 'hidden';
        					cs.itemClass = (!cs.Proveedor && !cs.Rubro) ? 'dynamicStockControl' : 'staticStockControl';
    					}                                           
	                }else{
	                    var alertPopup = $ionicPopup.alert({
	                     title: 'Error en Resúmen',
	                     template: response.Error,
	                     okText: 'Aceptar'
	                   });

	                   alertPopup.then(function(res) {
	                     
	                   });
	                }        
				});
		}

		function connect(){
			maxikioscosService.connect().then(function(){
				vm.getControlStockResume();
			});		
		}

		function reload(){
			vm.connect();
		}

		$scope.$on('$ionicView.enter', function(event, data) {
			if (vm.connection.isConnected) {
				vm.getControlStockResume();	
			}
        });
		
		vm.initialize();
	}

})();