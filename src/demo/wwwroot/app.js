(function () {
    'use strict';
    angular.module('superHero', ['ngRoute']);
    angular.module('superHero').config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider.when('/', {
            templateUrl: 'partials/hero/list.html',
            controller: 'superHeroListCtrl'
        }).when('/superheros/add', {
            templateUrl: 'partials/hero/add.html',
            controller: 'superHeroAddCtrl'
        }).when('/superheros/:id', {
            templateUrl: 'partials/hero/detail.html',
            controller: 'superHeroDetailCtrl'
        });
        
        $locationProvider.html5Mode(true);
    }]);
})();