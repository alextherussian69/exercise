'use strict';

angular.module('myApp.view1', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/view1', {
      templateUrl: 'view1/view1.html',
      controller: 'view1Ctrl'
  });
}])

.controller('view1Ctrl', function ($scope, personsService) {
    $scope.IsNewRecord = 1; //The flag for the new record

    loadRecords();

    function loadRecords() {
        var promiseGet = personsService.getPersons(); //The MEthod Call from service

        promiseGet.then(function (pl) { $scope.persons = pl.data },
              function (errorPl) {
                  $log.error('failure loading Person', errorPl);
              });
    }

    $scope.save = function () {
        var Person = {
            Id: $scope.Id,
            FirstName: $scope.FirstName,
            LastName: $scope.FirstName,
            JobTytle: $scope.JobTytle
        };
        var promisePut = crudService.put($scope.EmpNo,Employee);
        promisePut.then(function (pl) {
            $scope.Message = "Updated Successfuly";
        });
    }


.service('personsService', ['$http', function ($http) {
    this.getPersons = function ($scope) {
        return $http({
            method: "GET",
            url: "http://localhost:3928/api/Persons",
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            $scope.persons = data;
            console.log(data);
        }).error(function (data) {
            console.log(data);
        });;
    };
    this.putPerson = function (Id, Person) {
        var request = $http({
            method: "put",
            url: "/api/Persons/" + EmpNo,
            data: Person
        });
        return request;
    }
 }]);