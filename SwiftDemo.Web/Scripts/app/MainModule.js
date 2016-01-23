(function () {
    "use strict";
    /*
     * @description Main app module
     */
    angular.module("mainModule", ["ui.router", "blockUI"]);

    /*
     * @description Configuration for main app module
     */
    angular.module("mainModule").config(config);
    config.$inject = ["blockUIConfig", "$stateProvider", "$urlRouterProvider", "$locationProvider"];
    function config(blockUIConfig, $stateProvider, $urlRouterProvider, $locationProvider) {
        //nice library to display message 
        //but block it by default we need to use it manually
        blockUIConfig.autoBlock = false;

        var clientBaseUrl = "scripts/app/client/templates/";
        // For any unmatched url, redirect to /state1
        $urlRouterProvider.otherwise("/MaintainClient");
        //
        // Now set up the states
        $stateProvider
          .state("MaintainClient", {
              url: "/MaintainClient",
              templateUrl: clientBaseUrl + "MaintainClient.html",
              controller: "MaintainClientController",
              controllerAs: "vm",
          })

        $locationProvider.html5Mode(true);
    }

}());