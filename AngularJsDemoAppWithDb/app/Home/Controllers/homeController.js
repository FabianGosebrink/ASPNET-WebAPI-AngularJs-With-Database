(function () {
    'use strict';
    angular.module("homeModule").controller('homeController', [
    '$scope', 'personRepository',
    function ($scope, personRepository) {

        $scope.personRepository = personRepository;
        $scope.newPerson = {};

        var getPeople = function () {

            personRepository.getAllPeople().then(
                function () {
                    //Success
                },
                function () {
                    //Error

                });
        };

        var _addPerson = function () {
            $scope.errors = [];
            personRepository.addPerson($scope.newPerson)
                .then(
                function () {
                    $scope.newPerson = null;

                },
                function (errors) {
                    //Error
                    $scope.errors = errors;
                }
            );
        };

        var _deletePerson = function (personToDelete) {
            personRepository.deletePerson(personToDelete)
                .then(
                function () {

                },
                function () {
                    //Error

                });
        };

        getPeople();

        $scope.addPerson = _addPerson;
        $scope.deletePerson = _deletePerson;
    }
    ]);
})();