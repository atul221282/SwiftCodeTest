(function () {
    'use strict';

    /*
     * Maintain client controller
     */
    angular.module("mainModule").controller("MaintainClientController", MaintainClientController);

    
    /* @ngInject */
    function MaintainClientController() {

        var vm = this;
        vm.Title = "Maintain Client";
        vm.maintainClient = {};
    }

})();