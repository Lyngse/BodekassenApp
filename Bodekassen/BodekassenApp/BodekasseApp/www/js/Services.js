app.service('appService', function() {
  var usersToFineList = [];

  var addUserToFine = function(newObj) {
    usersToFineList.push(newObj);
  };

  var getUsers = function() {
    return usersToFineList;
  }

  return {
    addUserToFine: addUserToFine,
    getUsers: getUsers
  };
})