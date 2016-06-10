(function () {

  angular.module("Bibliotopia").controller("NookCtrl", function ($http) {
    var vm = this;
    vm.nook = null;
    vm.checkForUserNook = function () {
      $http.get("/Home/GetUserReadingNook")
        .success(function (response) {
          if (response.ReadingNook !== null) {
            vm.nook = response.ReadingNook;
          }
          else {
            vm.nook = null;
          }
        });
    }
  });

})();