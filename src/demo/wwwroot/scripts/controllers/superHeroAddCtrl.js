(function () {
    'use strict';

    angular.module('superHero').controller('superHeroAddCtrl', superHeroAddCtrl);

    superHeroAddCtrl.$inject = ['$scope', 'superHerosService', '$location'];

    function superHeroAddCtrl($scope, superHeroService, $location) {
       
        $scope.superhero = {};
        $scope.add = add;

        function add(){
            superHeroService.addSuperHero($scope.superhero).then(function (response) {
                $location.path('/superheros/' + response.data.Id);
            }, function (error) {
                alert(error)
            });
        }
    }


})();
