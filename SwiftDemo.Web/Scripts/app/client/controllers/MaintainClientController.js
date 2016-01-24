(function () {
    'use strict';

    /*
     * Maintain client controller
     */
    angular.module("mainModule").controller("MaintainClientController", MaintainClientController);

    MaintainClientController.$inject = ["ClientFactory"]
    /* @ngInject */
    function MaintainClientController(ClientFactory) {
        var vm = this;
        vm.ClientFactory = ClientFactory;
        vm.Title = "Maintain Client";
    }

})();