/// <reference path="E:\XAMARIN\2021\simple_login_register\angJS\Scripts/angular.min.js" />
/// <reference path="E:\XAMARIN\2021\simple_login_register\angJS\Scripts/angular-route.js" />

var myapp = angular.module("myapp", ["ngRoute"]);

myapp.config(function ($routeProvider,$locationProvider) {
    $routeProvider.when('/home',{
        templateUrl: "/app/views/Home.html",
        controller: "homeController"
    }).when('/register',{
        templateUrl:"/app/views/Register.html",
        controller: "registerController"
    }).when('/login',{
        templateUrl:"/app/views/Login.html",
        controller:"loginController"
    }).otherwise({redirectTo:'/home'})
});