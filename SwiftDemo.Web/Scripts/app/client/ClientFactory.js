(function () {
    'use strict';

    /*
     * @Client factory is the representation of client controller
     */
    angular.module("mainModule").factory("ClientFactory", ClientFactory);

    ClientFactory.$inject = ["APIFactory", "$timeout", "$q", "Notification"];
    function ClientFactory(APIFactory, $timeout, $q, Notification) {

        var service = {
            apiUrl: "api/Clients",
            formClientMaintenance: {},
            Client: {
                "Name": "", "Address": "", ClientPhones: [
                ]
            },
            ClientCopy: {
                Name: "", Address: "", ClientPhones: [
                ]
            },
            ClientRecords: [],
            ClientPhones: "",
            SaveClient: SaveClient,
            Update: Update,
            SendDelivery: SendDelivery,
            IsBusy: false
        }
        /*
         * @description Save client and gets the updated result
         */
        function SaveClient() {
            service.IsBusy = true;
            var ClientPhones = service.ClientPhones.replace(/[\s,]+/g, ',').split(",");
            angular.forEach(ClientPhones, function (phone) {
                service.Client.ClientPhones.push({ "ClientRecord": null, "PhoneNumber": { Number: phone }, "PhoneNumberId": -1, "ClientRecordId": -1 });
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
        /*
         * @description Calls the API to send the delivery
         */
        function SendDelivery(clientRecord) {
            APIFactory.Post(service.apiUrl + "/SendDelivery", clientRecord).then(function (response) {
                Notification.success(response.data);
            }, function (error) {
                Notification.warning(error);
            });
        }
        /*
         * @description Update client record
         */
        function Update(clientRecord) {
            APIFactory.Put(service.apiUrl + "?Id=" + clientRecord.Id, clientRecord).then(function (response) {
                var eee = response;
            }, function (error) {
                var eeer = error;
            });
        }
        return service;

    }
})();