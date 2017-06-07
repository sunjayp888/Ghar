(function () {
    'use strict';

    angular
        .module('Egharpay')
        .controller('RegisterController', HomeController);

    HomeController.$inject = ['$window', 'Paging', 'OrderService', 'OrderBy', 'Order', '$uibModal'];

    function RegisterController($window, Paging, OrderService, OrderBy, Order, $uibModal, $modalInstance) {
        /* jshint validthis:true */
        var vm = this;
       

        initialise();

        function initialise() {
            retrieveStatistics();
            retrieveBarGraphStatistics();
            retrieveCentres();
        }

        
    }

})();
