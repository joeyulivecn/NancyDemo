/// <reference path="..\scripts/angular.js" />

var app = angular.module('app', [])
        .controller('AppController', ['$scope', '$log', '$http', function ($scope, $log, $http) {
            $log.debug('AppController');
            $scope.appTitle = "Hello Nancy & MongoDB!";

            $http.get('api/v1/users').success(function (result) {
                $scope.users = result;
            });
        }]);