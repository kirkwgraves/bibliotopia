(function () {

  angular.module("Bibliotopia").controller("SearchCtrl", function ($http) {

    var vm = this;
    vm.searchText = null;
    vm.bookTitleList = null;

    vm.searchByTitle = function () {

      $http.get('https://www.googleapis.com/books/v1/volumes?q=' + vm.searchText)
      .success(function (response) {
        vm.bookTitleList = response.items;
        console.log(vm.bookTitleList);
        return response.items;
        
        // 	vm.bookTitleList =  response.items;
        // }).error(function(error) {
        // 	console.log('Error: ', Error);
      });
    };

  });

})();