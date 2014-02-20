'use strict';

var rologApp = angular.module('rologApp', ['ngResource', 'ngRoute']);

rologApp.config(['$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {
    $routeProvider.when('/users/:userId', {templateUrl: '/partials/user.html', controller: 'UserController'});
    $routeProvider.when('/users/:userId/character/:characterId', {templateUrl: '/partials/user_character.html', controller: 'UserCharacterController'});
    $routeProvider.otherwise({redirectTo: '/'});
    $locationProvider.html5Mode(true);
  }]);
