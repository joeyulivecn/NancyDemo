/// <reference path="..\scripts/angular.js" />

var app = angular.module('app', [])
        .controller('AppController', ['$scope', '$log', '$http', function ($scope, $log, $http) {
            $log.debug('AppController');
            $scope.appTitle = "Hello Nancy & MongoDB!";
            $scope.users = [];
            $http.get('http://localhost:50465/api/v1/users', { withCredentials: true }).success(function (result) {
                $scope.users = result;
            });
        }]);