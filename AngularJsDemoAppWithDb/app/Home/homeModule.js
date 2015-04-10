/**
 * Created by Fabian on 01.04.2015.
 */

var homeModule = angular.module("homeModule", ['ngRoute']);

homeModule.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            controller: "homeController",
            templateUrl: "/app/Home/Templates/overview.html"
        })
        .otherwise({redirectTo: "/"});
});

