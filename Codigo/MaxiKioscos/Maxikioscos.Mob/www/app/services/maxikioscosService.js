(function(){
	
	angular.module('maxikioscosApp').service('maxikioscosService', maxikioscosService);

	maxikioscosService.$inject = ['httpService', 'SERVICE_CONSTANTS']

	function maxikioscosService(httpService, SERVICE_CONSTANTS){

		var srv = this;

		srv.maxiKioscoStatus = {
			UserId: 1,			
			maxikioscoId: '252BB32B-B6A7-4580-9BEC-2027C94D7E3A',
			machineName: 'localhost',
			isWebOnline: true,
			isLocalServiceOnline: true,
			urlLocalService: 'http://192.168.0.11:8080'
		}

		
		srv.getMaxikioscos = getMaxikioscos;				
		srv.urlLocalService = urlLocalService;

		function urlLocalService(maxikiosco){			
			srv.maxiKioscoStatus.maxikioscoId = maxikiosco.Identifier;
			srv.maxiKioscoStatus.machineName = maxikiosco.MachineName;
			srv.maxiKioscoStatus.urlLocalService = SERVICE_CONSTANTS.PROTOCOL_SERVICE + srv.maxiKioscoStatus.machineName + SERVICE_CONSTANTS.PORT;
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