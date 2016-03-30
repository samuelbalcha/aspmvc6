(function () {
    'use strict';

    angular.module('superHero').controller('superHeroAddCtrl', superHeroAddCtrl);
    superHeroAddCtrl.$inject = ['$scope', 'superHerosService', '$location'];

    function superHeroAddCtrl($scope, superHeroService, $location) {
       
        $scope.superhero = {
            Name: '',
            Powers: [{ Name: 'sidekick' }]
        };

        $scope.superpower = {
            Name : ''
        };

        $scope.save = save;
        $scope.addPower = addPower;

        function save(){
            superHeroService.createSuperHero($scope.superhero).then(function (response) {
                $location.path('/superheros/' + response.data.Id);
            }, function (error) {
                alert(error)
            });
        }

        function addPower() {
            if ($scope.superpower.Name.length > 2) {
                $scope.superhero.Powers.push({ Name: $scope.superpower.Name });
            }
            else {
                alert("Power should have a length of 2");
            }
           
        }
    }
})();
