app.controller('ChooseFineCtrl', ['$scope', '$http', '$state', '$rootScope', '$ionicModal',  function($scope, $http, $state, $rootScope, $ionicModal) {
  $scope.GetFineTypes = function() {
    $http.get($rootScope.apiUrl + "api/readfinetypes", {params: {teamId: 1}})
    .then(function(response) {
      var data = response.data;
      if(data.status === "success")
      {
        $scope.FineTypes = data.FineTypes;
        console.log("FineTypes loaded");
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
  $scope.GetFineTypes();

  $scope.ChooseFine = function(fineTypeName, fineTypeId, defaultAmount)
  {
    $rootScope.SelectedFineType.Name = fineTypeName;
    $rootScope.SelectedFineType.Id = fineTypeId;
    $rootScope.SelectedFineType.DefaultAmount = defaultAmount;
    $scope.openFine();
    console.log("hello?");
  };

  $ionicModal.fromTemplateUrl('Views/ChooseFineDetail/ChooseFineDetail.html', {
    scope: $scope,
    animation: 'slide-in-up'
  }).then(function(modal) {
    $scope.modal = modal;
  });

  // Triggered in the login modal to close it
  $scope.closeFine = function() {
    $scope.modal.hide();
  };

  // Open the login modal
  $scope.openFine = function() {
    $scope.modal.show();
  };

  $scope.$on('$destroy', function() {
    $scope.modal.remove();
  });

  // Perform the login action when the user submits the login form
  $scope.doLogin = function() {
    console.log('Doing login', $scope.loginData);
  };
}]);