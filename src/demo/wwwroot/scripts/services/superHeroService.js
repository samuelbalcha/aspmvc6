(function () {
    'use strict';

    angular.module('superHero').factory('superHerosService', superHeroService);

    superHeroService.$inject = ['$http'];

    function superHeroService($http) {
        

        return {
            getSuperHeros: function () {
                return $http.get('/api/superheros');
            },
            getSuperHero: function (id) {
                return $http.get('/api/superheros/' + id);
            },
            createSuperHero: function (hero) {
                return $http.post('/api/superheros', hero);
            },
            updateSuperHero: function (hero) {
                return $http.put('/api/superheros/'+ hero.Id, hero);
            },
            removeSuperHero: function (id) {
                return $http.delete('/api/superheros/' + id);
            },
        };
    }
})();