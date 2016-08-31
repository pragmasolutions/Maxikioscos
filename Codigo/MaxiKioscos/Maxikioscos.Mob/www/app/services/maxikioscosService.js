(function() {

    angular.module('maxikioscosApp').service('maxikioscosService', maxikioscosService);

    maxikioscosService.$inject = ['httpService', 'SERVICE_CONSTANTS', 'localStorageService']

    function maxikioscosService(httpService, SERVICE_CONSTANTS, localStorageService) {

        var srv = this;

        srv.maxiKioscoStatus = {
            UserId: 1,
            maxikioscoId: '',
            machineName: '',
            isWebOnline: false,
            isLocalServiceOnline: false,
            urlLocalService: 'http://192.168.0.9:8080'
        }

        var _connection = {
            maxikioscoId: null,
            isConnected: false,
            maxikioscoAvailable: false
        };

        srv.connection = _connection;
        srv.validateMaxikioscoAccess = validateMaxikioscoAccess;
        srv.validateWebMasterAccess = validateWebMasterAccess;
        srv.getMaxikioscos = getMaxikioscos;
        
        srv.connect = connect;
        srv.fillConnectionData = fillConnectionData;
        srv.removeConnectionData = removeConnectionData;

        function getMaxikioscos() {
            return httpService.doGet(SERVICE_CONSTANTS.MAXIKIOSCOS)
                .then(function(response) {
                    return response;
                });
        }

        function checkLocalService() {

            return httpService.doGet(srv.maxiKioscoStatus.urlLocalService)
                .then(function(response) {

                });
        }

        function validateMaxikioscoAccess() {
            httpService.doPing(srv.maxiKioscoStatus.urlLocalService, function(response) {
                srv.maxiKioscoStatus.isLocalServiceOnline = response;
            });
        }

        function fillConnectionData() {
            var connectionData = localStorageService.get('connectionData');
            if (connectionData) {
                _connection.isConnected = connectionData.isConnected;
                _connection.maxikioscoId = connectionData.maxikioscoId;
                _connection.maxikioscoAvailable = connectionData.maxikioscoAvailable;
            } else {
                _connection.isConnected = false;
                _connection.maxikioscoId = null;
                _connection.maxikioscoAvailable = false;
            }
        };

        function removeConnectionData(){
            localStorageService.remove('connectionData');
            fillConnectionData();
        }

        function validateWebMasterAccess() {
            httpService.doPing(SERVICE_CONSTANTS.URL_MASTER_SERVICE + 'MaxiKioscosService.svc', function(response) {
                srv.maxiKioscoStatus.isWebOnline = response;
            });
        }

        function connect() {
            return httpService.doGet(srv.maxiKioscoStatus.urlLocalService + SERVICE_CONSTANTS.MAXIKIOSCO_IDENTIFIER)
                .then(function(response) {
                    if (response != null) {

                        localStorageService.set('connectionData', {
                            isConnected: true,
                            maxikioscoId: response.Identifier,
                            maxikioscoAvailable: true
                        });

                        fillConnectionData();
                    } else {
                        localStorageService.remove('connectionData');
                        fillConnectionData()
                    }
                });
        }

        function reload() {
            vm.connect();
        }
    }

})();
