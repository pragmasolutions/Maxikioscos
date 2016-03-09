(function(){

	angular.module('maxikioscosApp')
	.constant('SERVICE_CONSTANTS', (function () {	
		var protocolService = "http://";
		var api= "/api/";
		var port= ":8080";
		var urlMasterService = 'http://localhost:51557/';
		
		return {
			URL_MASTER_SERVICE: urlMasterService,
			PROTOCOL_SERVICE: protocolService,
			PORT: port,
			API: api,
			MAXIKIOSCOS: urlMasterService + 'MaxiKioscosService.svc/GetMaxiKioscos',
			RUBROS_LIST : api + 'rubros/Get',
			MARCAS_LIST : api + 'marcas/Get',
			MOTIVOS_LIST : api + 'motivos/Get',

		};
	})());
})();