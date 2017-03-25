// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
// 'starter.controllers' is found in controllers.js
var app = angular.module('BodekassenApp', ['ionic', 'starter.controllers', 'checklist-model'])

.run(function($ionicPlatform, $rootScope) {
  $ionicPlatform.ready(function() {
    // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
    // for form inputs)
    if (window.cordova && window.cordova.plugins.Keyboard) {
      cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
      cordova.plugins.Keyboard.disableScroll(true);

    }
    if (window.StatusBar) {
      // org.apache.cordova.statusbar required
      StatusBar.styleDefault();
    }
  });
  //$rootScope.apiUrl = "http://bodekassen.azurewebsites.net/";
  $rootScope.apiUrl = "http://localhost:59921/";

  $rootScope.SelectedFineType = {
    Name: "",
    Id: null,
    DefaultAmount: null
  };
})

.config(function($stateProvider, $urlRouterProvider) {
  $stateProvider

    .state('app', {
    url: '/app',
    abstract: true,
    templateUrl: 'templates/menu.html',
    controller: 'AppCtrl'
  })

  .state('app.ChooseFine', {
    url: '/choosefine',
    views: {
      'menuContent': {
        templateUrl: 'Views/ChooseFine/ChooseFine.html',
        controller: 'ChooseFineCtrl'
      }
    }
  })
  .state('app.ChooseFineDetail', {
      url: '/choosefinedetail',
      views: {
        'menuContent': {
          templateUrl: 'Views/ChooseFineDetail/ChooseFineDetail.html',
          controller: 'ChooseFineCtrl'
        }
      }
    })
  .state('app.GiveFine', {
    url: '/givefine',
    views: {
      'menuContent': {
        templateUrl: 'Views/GiveFine/GiveFine.html',
        controller: 'GiveFineCtrl'
      }
    }
  })
  .state('app.NewPlayer', {
    url: '/newplayer',
    views: {
      'menuContent': {
        templateUrl: 'Views/NewPlayer/NewPlayer.html',
        controller: 'NewPlayerCtrl'
      }
    }
  })
  .state('app.Overview', {
    url: '/overview',
    views: {
      'menuContent': {
        templateUrl: 'Views/Overview/Overview.html',
        controller: 'OverviewCtrl'
      }
    }
  })
  .state('app.Player', {
    url: '/player/:playerID',
    views: {
      'menuContent': {
        templateUrl: 'Views/Player/Player.html',
        controller: 'PlayerCtrl'
      }
    }
  })
  .state('app.Match', {
    url: '/matches/:matchID',
    views: {
      'menuContent': {
        templateUrl: 'Views/Match/Match.html',
        controller: 'MatchCtrl'
      }
    }
  })
  .state('app.Matches', {
    url: '/matches',
    views: {
      'menuContent': {
        templateUrl: 'Views/Matches/Matches.html',
        controller: 'MatchesCtrl'
      }
    }
  })
  .state('app.Browse', {
    url: '/browse',
    views: {
      'menuContent': {
        templateUrl: 'templates/browse.html',
        controller: 'AppCtrl'
      }
    }
  })
  .state('app.NewFine', {
    url: '/newfine',
    views: {
      'menuContent': {
        templateUrl: 'Views/NewFine/NewFine.html',
        controller: 'NewFineCtrl'
      }
    }
  });
  // if none of the above states are matched, use this as the fallback
  $urlRouterProvider.otherwise('/app/overview');
});
