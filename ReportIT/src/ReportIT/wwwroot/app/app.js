(function () {
    'use strict';

    var app = angular.module('app', [
        'ui.router',
        'ngProgress',

        'app.home'
    ]);

    app.config([
        '$stateProvider', '$urlRouterProvider', '$locationProvider',
        function($stateProvider, $urlRouterProvider, $locationProvider) {
            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            }).hashPrefix('!');

            $urlRouterProvider.otherwise("/");

            $stateProvider
                .state('home', {
                    url: "/",
                    templateUrl: "/app/home/home-template.html",
                    controller: 'HomeCtrl',
                    params: { progress: true }
                });
        }
    ]);

    app.run(function ($rootScope, $state, ngProgressFactory) {
        var progressbar = ngProgressFactory.createInstance();

        $rootScope.$on('$stateChangeStart', function(event, toState, toParams, fromState, fromParams) {
            if (toParams.progress) {
                progressbar.start();
            }
        });

        $rootScope.$on('$stateChangeSuccess', function(event, toState, toParams, fromState, fromParams) {
            if (toParams.progress) {
                progressbar.complete();
            }
        });
    });
})();