(function () {

  var app = angular.module("Bibliotopia", ["ngRoute"]);

  app.config(function ($routeProvider) {
    $routeProvider

    // route for the home page
    .when("/", {
      templateUrl: "NgTemplates/Home.html",
      controller: "HomeCtrl as homeCtrl"
    })
    .otherwise("/");

  });
})();