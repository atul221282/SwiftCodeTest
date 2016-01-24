(function () {
    "use strict";
    /*
     * @description Main app module
     */
    angular.module("mainModule", ["ui.router", "commonModule", "ui-notification"]);

    /*
     * @description Configuration for main app module
     */
    angular.module("mainModule").config(config);
    config.$inject = ["$httpProvider", "$stateProvider", "$urlRouterProvider", "$locationProvider"];
    function config($httpProvider, $stateProvider, $urlRouterProvider, $locationProvider) {
        
        //$httpProvider.defaults.useXDomain = true;
        //$httpProvider.defaults.withCredentials = true;
        //delete $httpProvider.defaults.headers.common["X-Requested-With"];
        //$httpProvider.defaults.headers.common["Accept"] = "application/json";
        //$httpProvider.defaults.headers.common["Content-Type"] = "application/json";
        //$httpProvider.defaults.headers.common["Access-Control-Allow-Origin"] = "*";
        
        var clientBaseUrl = "scripts/app/client/templates/";
        // For any unmatched url, redirect to /maintain client
        $urlRouterProvider.otherwise("/MaintainClient");
        //
        // Now set up the states
        $stateProvider
          .state("MaintainClient", {
              url: "/MaintainClient",
              templateUrl: clientBaseUrl + "MaintainClient.html",
              controller: "MaintainClientController",
              controllerAs: "vm",
              resolve: {
                  ClientRecords: function ($q, $http, ClientFactory) {
                      var deferred = $q.defer();
                      $http.get(ClientFactory.apiUrl).then(function (response) {
                          deferred.resolve(response.data);
                      });
                      return deferred.promise;
                  }
              }
          });


        $locationProvider.html5Mode(true);
    }

}());