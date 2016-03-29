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
        }).when('/superheros/edit/:id', {
            templateUrl: 'partials/edit.html',
            controller: 'superHeroEditCtrl'
        }).when('/superheros/delete/:id', {
            templateUrl: 'partials/delete.html',
            controller: 'superHeroDeleteCtrl'
        });
        
        $locationProvider.html5Mode(true);
    }]);
})();