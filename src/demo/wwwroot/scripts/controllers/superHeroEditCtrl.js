(function () {
    'use strict';

    angular.module('superHero').controller('superHeroEditCtrl', superHeroEditCtrl);

    superHeroEditCtrl.$inject = ['$scope', 'superHerosService', '$location', '$routeParams'];

    function superHeroEditCtrl($scope, superHeroService, $location, $routeParams) {
       
        superHeroService.getSuperHero($routeParams.id).then(function (response) {
            $scope.superhero = response.data;
        }, function (error) {
            alert(error);
        });

        $scope.edit = edit;

        function edit(){
            superHeroService.addSuperHero($scope.superhero).then(function (response) {
                $location.path('/superheros/' + response.data.Id);
            }, function (error) {
                alert(error)
            });
        }
    }


})();
