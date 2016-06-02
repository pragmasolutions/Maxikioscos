(function(){
	
	angular.module('maxikioscosApp').service('maxikioscosService', maxikioscosService);

	maxikioscosService.$inject = ['httpService', 'SERVICE_CONSTANTS']

	function maxikioscosService(httpService, SERVICE_CONSTANTS){

		var srv = this;

		srv.maxiKioscoStatus = {
			UserId: 1,			
			maxikioscoId: '',
			machineName: '',
			isWebOnline: false,
			isLocalServiceOnline: false,
			//urlLocalService: 'http://localhost:8080'
			urlLocalService: 'http://192.168.0.16:8080'
		}

		srv.validateMaxikioscoAccess = validateMaxikioscoAccess;
        srv.validateWebMasterAccess = validateWebMasterAccess;
		srv.getMaxikioscos = getMaxikioscos;				
		srv.urlLocalService = urlLocalService;

		function urlLocalService(maxikiosco){			
			srv.maxiKioscoStatus.maxikioscoId = maxikiosco.Identifier;
			srv.maxiKioscoStatus.machineName = maxikiosco.MachineName;
			//srv.maxiKioscoStatus.urlLocalService = SERVICE_CONSTANTS.PROTOCOL_SERVICE + srv.maxiKioscoStatus.machineName + SERVICE_CONSTANTS.PORT;
		}

		function getMaxikioscos(){
			return httpService.doGet(SERVICE_CONSTANTS.MAXIKIOSCOS)
			.then(function(response){				
				return response;
			});
		}

		function checkLocalService(){
						
			return httpService.doGet(srv.maxiKioscoStatus.urlLocalService)
			.then(function(response){				
				
			});
		}

		 function validateMaxikioscoAccess() {
            httpService.doPing(srv.maxiKioscoStatus.urlLocalService, function(response){
                 srv.maxiKioscoStatus.isLocalServiceOnline = response;                 
            });
        }       

        function validateWebMasterAccess(){                            
            httpService.doPing(SERVICE_CONSTANTS.URL_MASTER_SERVICE + 'MaxiKioscosService.svc', function(response){
                srv.maxiKioscoStatus.isWebOnline = response;                                
            });
        }

	}	

})();