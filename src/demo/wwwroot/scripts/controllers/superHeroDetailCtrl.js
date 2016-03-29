(function () {
    'use strict';

    angular.module('superHero').controller('superHeroDetailCtrl', superHeroDetailCtrl);

    superHeroDetailCtrl.$inject = ['$scope', 'superHerosService', '$location', '$routeParams'];

    function superHeroDetailCtrl($scope, superHeroService, $location, $routeParams) {

        $scope.superhero = {};
        $scope.edit = edit;
        $scope.save = save;
        $scope.delete = remove;
        $scope.editMode = false;

        init();

        function init() {
            superHeroService.getSuperHero($routeParams.id).then(function (response) {
                $scope.superhero = response.data;
            }, function (error) {
                alert(error.data);
            });
        }
        
        function edit() {
            $scope.editMode = true;
        }

        function save() {
            $scope.editMode = false;
            superHeroService.updateSuperHero($scope.superhero).then(function (response) {
                $scope.superhero = response.data;
            }, function (error) {
                alert(error.data)
            });
        }
        function remove() {
           
            superHeroService.removeSuperHero($scope.superhero.Id).then(function (response) {
                $location.path('/');
            }, function (error) {
                alert(error.data)
            });
        }
    }


})();
