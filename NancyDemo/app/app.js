/// <reference path="..\scripts/angular.js" />

var app = angular.module('app', [])
        .controller('AppController', ['$scope', '$log', function ($scope, $log) {
            $log.debug('AppController');
            $scope.appTitle = "Hello Nancy & MongoDB!";
        }]);