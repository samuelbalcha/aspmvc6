(function () {
    'use strict';
    angular.module('superHero', ['ngRoute']);
    angular.module('superHero').config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider.when('/', {
            templateUrl: 'partials/list.html',
            controller: 'superHeroListCtrl'
        }).when('/superheros/add', {
            templateUrl: 'partials/add.html',
            controller: 'superHeroAddCtrl'
        }).when('/superheros/:id', {
            templateUrl: 'partials/detail.html',
            controller: 'superHeroDetailCtrl'
        });
        
        $locationProvider.html5Mode(true);
    }]);
})();