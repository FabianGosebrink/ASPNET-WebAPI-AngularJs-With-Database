(function () {
    'use strict';
    angular.module("homeModule").factory("personRepository", [
    "$http", "$q", "common.services.arrayHelper", function ($http, $q, arrayHelper) {

        var urlPrefix = '/api/';
        var _allPeople = [];

        var _getAllPeople = function () {

            var deferred = $q.defer();

            $http.get(urlPrefix + "peoples")
                .then(function (result) {
                    // Successful
                    angular.copy(result.data, _allPeople);
                    deferred.resolve(result);
                },
                function () {
                    // Error
                    deferred.reject();
                });

            return deferred.promise;
        };

        var _addPerson = function (newPersonToAdd) {

            var deferred = $q.defer();

            $http.post(urlPrefix + "peoples", newPersonToAdd)
                .then(function (result) {
                    // Successful
                    var newlyCreatedPerson = result.data;
                    arrayHelper.addItemToArray(_allPeople, newlyCreatedPerson);
                    deferred.resolve(result);
                },
                function (result) {
                    // Error
                    var errors = parseErrors(result.data)
                    deferred.reject(errors);
                });

            return deferred.promise;
        };

        var _deletePerson = function (personToDeleteId) {

            var deferred = $q.defer();

            $http.delete(urlPrefix + "peoples/" + personToDeleteId)
                .then(function (result) {
                    // Successful

                    for (var i = _allPeople.length; i--;) {
                        if (_allPeople[i].Id === personToDeleteId) {
                            _allPeople.splice(i, 1);
                        }
                    }

                    deferred.resolve(result);
                },
                function () {
                    // Error
                    deferred.reject();
                });

            return deferred.promise;
        };

        function parseErrors(response) {
            var errors = [];
            for (var key in response.ModelState) {
                for (var i = 0; i < response.ModelState[key].length; i++) {
                    errors.push(response.ModelState[key][i]);
                }
            }
            return errors;
        }

        return {
            getAllPeople: _getAllPeople,
            addPerson: _addPerson,
            deletePerson: _deletePerson,
            allPeople: _allPeople
        }
    }
    ]);
})();