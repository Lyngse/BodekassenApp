app.controller('NewPlayerCtrl', ['$scope', '$http', '$state', '$rootScope',  function($scope, $http, $state, $rootScope) {
  $scope.NewPlayer = function(name) {
    $http.post($rootScope.apiUrl + "api/createplayer", {name: name, teamId: 1})
    .then(function(response) {
      var data = response.data;
      if(data.status === "success")
      {
        console.log("Player added");
        console.log(data);
      }
      else
      {
        console.log(data);
      }
    }, function(data) {
      $rootScope.errorHandler(data);
      $scope.deleteErr = data;
    })
  };
}]);