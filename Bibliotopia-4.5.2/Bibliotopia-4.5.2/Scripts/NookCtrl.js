(function () {

  angular.module("Bibliotopia").controller("NookCtrl", ["$http", "$location", function ($http, $location) {
    var vm = this;
    vm.nook = null;
    vm.favoriteBooks = null;


    vm.checkForUserNook = function () {
      $http.get("/api/Nook/")
        .success(function (response) {
          console.log(response);
          //if (response.data !== null) {
          //  vm.nook = response.data;
          //  console.log(vm.nook);
          //}
          //else {
          //  vm.nook = null;
          //}
        });
    };

    $http.get("/api/FavoriteBooks")
      .success(function (response) {
        vm.favoriteBooks = response;
        console.log(vm.favoriteBooks)
      });

    $http.get("/api/ToReadBooks")
      .success(function (response) {
        vm.toReadBooks = response;
        console.log(vm.toReadBooks)
      });

    vm.createNook = function () {
      $http.post("/api/Nook")
        .success(function (response) {
          console.log(response);
        });
    };
  }]);

})();