(function () {
    'use strict';

    /*
     * @Client factory is the representation of client controller
     */
    angular.module("mainModule").factory("ClientFactory", ClientFactory);

    ClientFactory.$inject = ["APIFactory", "$timeout"];
    function ClientFactory(APIFactory, $timeout) {

        var service = {
            formClientMaintenance: {},
            Client: {
                Name: "", Address: "", PhoneNumbers: []
            },
            ClientCopy: {
                Name: "", Address: "", PhoneNumbers: []
            },
            PhoneNumbers: "",
            SaveClient: SaveClient,
            IsBusy: false
        }

        function SaveClient() {
            service.IsBusy = true;
            service.Client.PhoneNumbers = service.PhoneNumbers.replace(/[\s,]+/g, ',').split(",");
            $timeout(function () {
                console.log(service.Client);
                service.IsBusy = false;
                service.Client = angular.copy(service.ClientCopy);
                service.PhoneNumbers = "";
                service.formClientMaintenance.$setPristine();
            }, 3000)
        }

        return service;

    }
})();