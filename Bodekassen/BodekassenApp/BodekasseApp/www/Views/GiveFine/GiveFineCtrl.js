app.controller('GiveFineCtrl', ['$scope', '$http', '$state', '$rootScope', 'appService',  function($scope, $http, $state, $rootScope, appService) {
  $scope.GetPlayers = function() {
    $http.get($rootScope.apiUrl + "publicapi/getplayers", {params: {teamId: 1}})
    .then(function(response) {
      var data = response.data;
      if(data.status === "success")
      {
        $scope.Players = data.Players;
        console.log("Users loaded");

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

  $rootScope.selcted = {};

  $scope.Fine = function() {
    for(var i = 0; i < $scope.Players.length; i++)
    {
      if($scope.Players[i].isChecked)
      {
        $rootScope.selcted.push($scope.Players[i]);
      }
    }
  }

}]);