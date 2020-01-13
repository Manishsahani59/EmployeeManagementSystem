/// <reference path="angular-ui-router.js" />
/// <reference path="angular.min.js" />
var app = angular
    .module("demo", ['ui.router']).config(function ($stateProvider) {
        $stateProvider
            .state("Home", {
            url: "/home",
            templateUrl: "helloworld.html",
        })
         .state("Contactus", {
                url: "/contactUs",
                templateUrl: "contactus.html"
         })
    //    $locationProvider.html5Mode(true);
    })
    .controller("myController", function ($scope, $http) {
        $http.get('http://localhost:64535/api/Employee/')
            .then(function (response) {
               $scope.employee= response.data;
            });
    });
    

