app.controller('MatchesCtrl', ['$scope', '$http', '$state', '$rootScope',  function($scope, $http, $state, $rootScope) {
  $scope.GetMatches = function() {
    $http.get($rootScope.apiUrl + "publicapi/getmatches", {params: {teamId: 1}})
    .then(function(response) {
      var data = response.data;
      if(data.status === "success")
      {
        $scope.Matches = data.Matches;
        console.log("Matches loaded");

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
  $scope.GetMatches();
}]);