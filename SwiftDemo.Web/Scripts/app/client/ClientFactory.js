(function () {
    'use strict';

    /*
     * @Client factory is the representation of client controller
     */
    angular.module("mainModule").factory("ClientFactory", ClientFactory);

    ClientFactory.$inject = ["APIFactory", "$timeout", "$q", "Notification", "$http"];
    function ClientFactory(APIFactory, $timeout, $q, Notification, $http) {

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

        function SendDelivery(address) {
            var dataModel = {
                "apiKey": "3285db46-93d9-4c10-a708-c2795ae7872d",
                "booking": {
                    "pickupDetail": {
                        "address": "120 brunel drive, 5091"
                    },
                    "dropoffDetail": {
                        "address": address
                    }
                }
            };

            dataModel = {
                "apiKey": "3285db46-93d9-4c10-a708-c2795ae7872d",
                "booking": {
                    "pickupDetail": {
                        "address": "57 luscombe st, brunswick, melbourne"
                    },
                    "dropoffDetail": {
                        "address": "105 collins st, 3000"
                    }
                }
            }

            //$http("https://app.getswift.co/api/v2/deliveries", dataModel).then(function (response) {
            //    Notification.success('Success notification');
            //}, function (error) {
            //    console.log(error)
            //    Notification.error('Error notification');
            //});
            $http({
                method: 'PUT',
                data: address,
                url: 'api/Clients?Id=' + address.Id
            }).then(function (response) {
                var ooo = response;
                // this callback will be called asynchronously
                // when the response is available
            }, function (response) {
                var sdsd = response;
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
        }

        return service;

    }
})();