(function () {

  angular.module("Bibliotopia").controller("SearchCtrl", function ($http) {

    var vm = this;
    vm.searchTitleText = null;
    vm.searchAuthorText = null;
    vm.searchSubjectText = null;
    vm.bookTitleList = null;

    vm.searchByTitle = function () {

      $http.get('https://www.googleapis.com/books/v1/volumes?q=' + vm.searchTitleText + '&maxResults=40')
      .success(function (response) {
        vm.bookTitleList = response.items;
        console.log(vm.bookTitleList);
        return response.items;
      });
    };


    vm.searchByAuthor = function () {

      $http.get('https://www.googleapis.com/books/v1/volumes?q=inauthor:' + vm.searchAuthorText + '&maxResults=40')
      .success(function (response) {
        vm.bookTitleList = response.items;
        console.log(vm.bookTitleList);
        return response.items;
      });
    };

    vm.searchBySubject = function () {

      $http.get('https://www.googleapis.com/books/v1/volumes?q=subject:' + vm.searchSubjectText + '&maxResults=40')
      .success(function (response) {
        vm.bookTitleList = response.items;
        console.log(vm.bookTitleList);
        return response.items;
      });
    };


  });
})();
  