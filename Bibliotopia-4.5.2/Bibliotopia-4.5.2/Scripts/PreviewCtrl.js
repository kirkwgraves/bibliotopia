(function () {

  angular.module("Bibliotopia").controller("PreviewCtrl", ["$http", "$routeParams", function ($http, $routeParams) {


    var vm = this;
    vm.previewId = $routeParams.googleBookId;

    $http.get('https://www.googleapis.com/books/v1/volumes/' + vm.previewId)
      .success(function (response) {
        vm.previewBook = response;
      })
      .error(function (response) {
        console.log("error: ", response);
      });

    var viewer = new google.books.DefaultViewer(document.getElementById('viewerCanvas'));

    viewer.load(vm.previewId);


  }]);

})();