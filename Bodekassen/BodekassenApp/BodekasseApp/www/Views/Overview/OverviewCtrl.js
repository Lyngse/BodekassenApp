app.controller('OverviewCtrl', ['$scope', '$http', '$state', '$rootScope', '$location',  function($scope, $http, $state, $rootScope, $location) {
  $scope.GetPlayers = function() {
    $http.get($rootScope.apiUrl + "publicapi/getplayers", {params: {teamId: 1}})
    .then(function(response) {
      var data = response.data;
      if(data.status === "success")
      {
        $scope.Players = data.Players;
        console.log("Players loaded");

        console.log(data);
      }
      else
      {
        console.log(data);
      }
    }, function(data) {
      $scope.deleteErr = data;
    })
  };
  $scope.GetPlayers();

  $scope.gotoPlayer = function(playerId) {
    $location.path('/player/' + playerId);
  };

}]);