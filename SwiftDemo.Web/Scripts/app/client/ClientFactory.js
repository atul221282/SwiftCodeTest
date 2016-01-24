(function () {
    'use strict';

    /*
     * @Client factory is the representation of client controller
     */
    angular.module("mainModule").factory("ClientFactory", ClientFactory);

    ClientFactory.$inject = ["APIFactory", "$timeout", "$q", ];
    function ClientFactory(APIFactory, $timeout, $q) {

        var service = {
            apiUrl: "api/Clients",
            formClientMaintenance: {},
            Client: {
                Name: "", Address: "", ClientPhones: [
                ]
            },
            ClientCopy: {
                Name: "", Address: "", ClientPhones: [
                ]
            },
            ClientRecords: [],
            ClientPhones: "",
            SaveClient: SaveClient,

            IsBusy: false
        }
        /*
         * @description Save client and gets the updated result
         */
        function SaveClient() {
            service.IsBusy = true;
            var ClientPhones = service.ClientPhones.replace(/[\s,]+/g, ',').split(",");
            angular.forEach(ClientPhones, function (phone) {
                service.Client.ClientPhones.push({ "ClientRecord": null, "PhoneNumber": { Id: null, Number: phone } });
            });
            APIFactory.Post(service.apiUrl, service.Client).then(function (response) {
                service.ClientRecords.push(response.data);
            }, function (error) {
                console.log(error);
            }).finally(function () {
                //just for demo
                ResetForm();
            });
        }

        function ResetForm() {
            service.IsBusy = false;
            service.Client = angular.copy(service.ClientCopy);
            service.ClientPhones = "";
            service.formClientMaintenance.$setPristine();
        }

        return service;

    }
})();