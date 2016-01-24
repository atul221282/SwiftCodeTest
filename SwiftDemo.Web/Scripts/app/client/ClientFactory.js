(function () {
    'use strict';

    angular.module("mainModule").factory("ClientFactory", ClientFactory);

    ClientFactory.$inject = ["$http", "$window", "$timeout"];
    function ClientFactory($http, $window, $timeout) {

        var service = {
            formClientMaintenance: {},
            Client: {
                Name: "", Address: "", PhoneNumbers: []
            },
            PhoneNumbers: "",
            SaveClient: SaveClient,
            IsBusy: false
        }

        function SaveClient() {
            service.IsBusy = true;
            service.Client.PhoneNumbers = service.PhoneNumbers.split(",");
            $timeout(function () {
                console.log(service.Client);
                service.IsBusy = false;
            }, 3000)
        }

        return service;

    }
})();