app.controller('NewFineCtrl', ['$scope', '$http', '$state', '$rootScope',  function($scope, $http, $state, $rootScope) {
  $scope.caseOfBeer = false;
  $scope.fineDeposit = false;
  $scope.name = null;
  $scope.defaultAmount = null;

  $scope.clear = function() {
    if($scope.newFineType) {
      $scope.form.newFineType.$setPristine();
      $scope.name = "";
      $scope.defaultPrice = null;
      $scope.specialFineType = false;
      $scope.fineDeposit = false;
      console.log("cleared?");
    }
  };

  $scope.NewFineType = function(name, defaultAmount, caseOfBeer, fineDeposit) {
    $http.post($rootScope.apiUrl + "api/createfinetype", {name: name, defaultAmount: defaultAmount, teamId: 1, isCaseOfBeer: caseOfBeer, isDeposit: fineDeposit})
    .then(function(response) {
      var data = response.data;
      if(data.status === "success")
      {
        console.log("Finetype added");
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