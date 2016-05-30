(function () {
    angular.module('maxikioscosApp').service('httpService', httpService);

    httpService.$inject = ['$http', '$q', '$ionicLoading'];

    function httpService($http, $q, $ionicLoading) {

        var srv = this;


        srv.doGet = doGet;

        srv.doPost = doPost;    

        srv.doPing = doPing;    

        function doPost(url, paramRequest) {
            $ionicLoading.show({
               template: 'Loading...'
            });
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: url,
                data: paramRequest
            })
            .then(function successCallback (response) {
                $ionicLoading.hide();
                if (response.statusText === 'OK') {
                    deferred.resolve(response.data);
                } else {
                    deferred.reject(response.data, response.status);
                }
            }, function errorCallback(response) {
                $ionicLoading.hide();
                deferred.reject(response);
            });

            return deferred.promise;
        }
       

        function doGet(url, paramRequest) {
            $ionicLoading.show({
               template: 'Loading...'
            });
            var deferred = $q.defer();

            $http({
                method: 'GET',                 
                url: url,
                params: paramRequest                
            })
           .then(function successCallback (response) {
              $ionicLoading.hide();
               if (response.statusText === 'OK') {
                   deferred.resolve(angular.fromJson(response.data));
               } else {
                   deferred.reject(response.data, response.status);
               }
           }, function errorCallback(response) {
              $ionicLoading.hide();
               deferred.reject(response);
           });

            return deferred.promise;
        };        

        function doPing(urlService, callback){
          $ionicLoading.show({
               template: 'Loading...'
            });
          $http.get(urlService)
                    .success(function() {
                        $ionicLoading.hide();
                        callback(true);
                    })
                    .error(function() {
                        $ionicLoading.hide();
                        callback(false);
                    })

        };
    }

})();