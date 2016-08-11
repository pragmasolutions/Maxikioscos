// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.controllers' is found in controllers.js
angular.module('maxikioscosApp', [
    'ngCordova',
    'ionic',
    'starter.controllers',
    'ngMessages',
    'angularMoment',
    'LocalStorageModule'
])

.run(function($ionicPlatform) {
    $ionicPlatform.ready(function() {
        // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
        // for form inputs)
        if (window.cordova && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
            cordova.plugins.Keyboard.disableScroll(true);

        }
        if (window.StatusBar) {
            // org.apache.cordova.statusbar required
            StatusBar.styleDefault();
        }
    });
})

.run(['loginApi','maxikioscosService', function(loginApi,maxikioscosService) {
    loginApi.fillAuthData();
    maxikioscosService.fillConnectionData();
}])

.config(function($httpProvider) {
    $httpProvider.interceptors.push('maxikioscoIdentifierInterceptorService');
})

.config(function($stateProvider, $urlRouterProvider, $httpProvider) {

    $stateProvider

        .state('app', {
        url: '/app',
        abstract: true,
        templateUrl: 'app/templates/menu.html',
        controller: 'AppCtrl'
    })

    .state('app.home', {
        url: '/home',
        views: {
            'mainContent': {
                templateUrl: 'app/home/home.html'
            }
        }
    })

    .state('app.login', {
        url: '/login',
        views: {
            'mainContent': {
                templateUrl: 'app/login/login.html'
            }
        }
    })

    .state('app.generarControlStock', {
        url: '/generarControlStock',
        views: {
            'mainContent': {
                templateUrl: 'app/controlStock/generar-control-stock.html'
            }
        }
    })

    .state('app.controlStockVistaPrevia', {
        url: '/controlStockVistaPrevia',
        views: {
            'mainContent': {
                templateUrl: 'app/controlStock/control-stock-vista-previa.html'
            }
        }
    })

    .state('app.cargarControlStock', {
        url: '/cargarControlStock',
        views: {
            'mainContent': {
                templateUrl: 'app/controlStock/cargar-control-stock.html'
            }
        }
    })

    .state('app.cargarControlStockDinamico', {
        url: '/cargarControlStockDinamico',
        views: {
            'mainContent': {
                templateUrl: 'app/controlStock/cargar-control-stock-dynamic.html'
            }
        }
    })

    // if none of the above states are matched, use this as the fallback
    $urlRouterProvider.otherwise('/app/home');
});
