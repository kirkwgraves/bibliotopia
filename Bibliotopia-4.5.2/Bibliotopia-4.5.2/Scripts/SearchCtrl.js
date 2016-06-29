(function () {

  angular.module("Bibliotopia").controller("SearchCtrl", ['$http', function ($http) {

    $(document).ready(function () {
      // the "href" attribute of .modal-trigger must specify the modal ID that wants to be triggered
      $('.modal-trigger').leanModal();
    });

    var vm = this;
    vm.searchTitleText = null;
    vm.searchAuthorText = null;
    vm.searchSubjectText = null;
    vm.bookTitleList = null;
    vm.favoriteBook = {
      Title: null,
      Author: null,
      Genre: null,
      CoverImageUrl: null,
      GoogleBookId: null
    };

    vm.selectedBook = null;

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

    vm.clear = function () {
      vm.searchTitleText = null;
      vm.searchAuthorText = null;
      vm.searchSubjectText = null;
      $('.search-card').html("");
    };

    vm.addToFavorites = function (book) {

      vm.favoriteBook = {
        Title: book.volumeInfo.title,
        Author: book.volumeInfo.authors[0],
        Genre: book.volumeInfo.categories[0],
        CoverImageUrl: book.volumeInfo.imageLinks.thumbnail,
        GoogleBookId: book.id
      };


      $http.post('/api/FavoriteBooks/', this.favoriteBook)
      .success(function (response) {
        console.log('Success!', response);
      })
      .error(function (response) {
        console.log('error:', response);
      });
      //console.log(vm.favoriteBook);
    };

    vm.addToRead = function (book) {

      vm.bookToRead = {
        Title: book.volumeInfo.title,
        Author: book.volumeInfo.authors[0],
        Genre: book.volumeInfo.categories[0],
        CoverImageUrl: book.volumeInfo.imageLinks.thumbnail,
        GoogleBookId: book.id
      };

      $http.post('/api/ToReadBooks/', this.bookToRead)
      .success(function (response) {
        console.log('Success!', response);
      })
      .error(function (response) {
        console.log('error:', response);
      });
    };

    vm.viewBookDetail = function (book) {
      //vm.selectedBook = book;
      //console.log(vm.selectedBook);
      $('#detail').openModal({
        controller: 'SearchCtrl as searchCtrl',
        resolve: {
          book: function () {
            return vm.selectedBook;
          }
        }
      });
    };

  }]);
})();
  