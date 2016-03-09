(function(){
	
	angular.module('maxikioscosApp').service('maxikioscosService', maxikioscosService);

	maxikioscosService.$inject = ['httpService', 'SERVICE_CONSTANTS']

	function maxikioscosService(httpService, SERVICE_CONSTANTS){

		var srv = this;

		srv.maxiKioscoStatus = {
			maxikioscoId: '',
			machineName: '',
			isWebOnline: true,
			isLocalServiceOnline: true,
			urlLocalService: ''
		}

		
		srv.getMaxikioscos = getMaxikioscos;		

		function urlLocalService(machineName){
			srv.maxiKioscoStatus.urlLocalService = SERVICE_CONSTANTS.PROTOCOL + srv.maxiKioscoStatus.machineName + SERVICE_CONSTANTS.PORT;
		}

		function getMaxikioscos(){
			return httpService.doGet(SERVICE_CONSTANTS.MAXIKIOSCOS)
			.then(function(response){				
				return response.d;
			});
		}

		function checkLocalService(){
						
			return httpService.doGet(SERVICE_CONSTANTS.PROTOCOL + srv.maxiKioscoStatus.machineName + SERVICE_CONSTANTS.PORT)
			.then(function(response){				
				
			});
		}

	}	

})();