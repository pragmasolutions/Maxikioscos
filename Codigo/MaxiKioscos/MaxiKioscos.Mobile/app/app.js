// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.services' is found in services.js
// 'starter.controllers' is found in controllers.js
angular.module('maxikioscosApp', ['ionic', 'ngMessages'])

    .config(function ($stateProvider, $urlRouterProvider) {

        // Ionic uses AngularUI Router which uses the concept of states
        // Learn more here: https://github.com/angular-ui/ui-router
        // Set up the various states which the app can be in.
        // Each state's controller can be found in controllers.js
        $stateProvider
            .state('home', {
                url: '/home',
                templateUrl: 'app/home/home.html',
                controller: 'homeCtrl'
            })
            .state('loginState', {
                url: '/login',
                templateUrl: 'app/login/login.html',
                controller: 'LoginCtrl'
            })
            .state('generarControlStock', {
                url: '/generarControlStock',
                templateUrl: 'app/controlStock/generar-control-stock.html',
                controller: 'GenerarControlStockCtrl'
            })
            .state('controlStockVistaPrevia', {
                url: '/controlStockVistaPrevia',
                templateUrl: 'app/controlStock/control-stock-vista-previa.html',
                controller: 'ControlStockVistaPreviaCtrl'
            })
            .state('cargarControlStock', {
                url: '/cargarControlStock',
                templateUrl: 'app/controlStock/cargar-control-stock.html',
                controller: 'CargarControlStockCtrl'
            })

            .state('app', {
                abstract: true,
                url: "/app",

                templateUrl: "app/layout/menu-layout.html"
            })
            .state('app.home', {
                url: '/home',
                views: {
                    'mainContent': {
                        templateUrl: 'app/home/home.html'
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
            });



        // if none of the above states are matched, use this as the fallback
        $urlRouterProvider.otherwise('/app/home');

    });