app.controller('PlayerCtrl', ['$scope', '$http', '$state', '$rootScope', '$stateParams', function($scope, $http, $state, $rootScope, $stateParams) {
  $scope.GetPlayer = function() {
    $http.get($rootScope.apiUrl + "publicapi/getplayer", {params: {playerId: $stateParams.playerID}})
    .then(function(response) {
      var data = response.data;
      if(data.status === "success")
      {
        $scope.Player = data;
        $scope.Name = $scope.Player.Name;
        console.log($scope.Player);
        console.log("Player loaded");

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
  $scope.GetPlayer();
}]);