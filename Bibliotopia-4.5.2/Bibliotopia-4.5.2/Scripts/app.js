(function () {

  var app = angular.module("Bibliotopia", ["ngRoute"]);


  app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider

    // route for the home page
    .when("/", {
      templateUrl: "NgTemplates/Home.html",
      controller: "HomeCtrl as homeCtrl"
    })
    .when("/search", {
      templateUrl: "NgTemplates/Search.html",
      controller: "SearchCtrl as searchCtrl"
    })
    .when("/nook", {
      templateUrl: "NgTemplates/ReadingNook.html",
      controller: "NookCtrl as nookCtrl"
    })
    .when("/nookbooks", {
      templateUrl: "NgTemplates/UserNook.html",
      controller: "NookCtrl as nookCtrl"
    })
    .when("/preview/:googleBookId", {
      templateUrl: "NgTemplates/Preview.html",
      controller: "PreviewCtrl as previewCtrl"
    })
    .otherwise("/");

  }]);
})();