﻿(function () {

  angular.module("Bibliotopia").controller("NookCtrl", function ($http, $location) {
    var vm = this;
    vm.nook = null;
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
    }
  });

})();