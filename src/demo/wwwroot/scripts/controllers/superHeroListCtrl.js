(function () {
    'use strict';

    angular.module('superHero').controller('superHeroListCtrl', superHeroListCtrl);

    superHeroListCtrl.$inject = ['$scope', 'superHerosService'];

    function superHeroListCtrl($scope, superHeroService) {
       
        $scope.superheros = [];

        init();

        function init() {
            superHeroService.getSuperHeros().then(function (response) {
                $scope.superheros = response.data;
            }, function(err){
                alert(err);
            });
        }
    }





})();
