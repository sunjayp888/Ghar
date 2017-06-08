(function () {
    'use strict';

    angular
        .module('Egharpay')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['$window', 'Paging', 'OrderService', 'OrderBy', 'Order', '$uibModal'];

    function RegisterController($window, Paging, OrderService, OrderBy, Order, $uibModal, $modalInstance) {
        /* jshint validthis:true */
        var vm = this;
        vm.openPincodeModal = openPincodeModal

        vm.modalInstance = $uibModal.open({
            size: 'md',
            templateUrl: '/Scripts/Angular/Templates/PincodeModal.html',
            controller: ['parent', '$uibModalInstance', function (parent, $uibModalInstance) {
                var $modal = this;
                $modal.parent = parent;
                $modal.modalClose = modalClose;
                $modal.modalSubmit = modalSubmit;
                $modal.errorMessage = null;


                function modalClose() { $uibModalInstance.dismiss(); }
                function modalSubmit() {
                    var isNew = !$modal.Holiday.PublicHolidayId;
                    if (isNew) addNewHoliday($modal.Holiday);
                    else updateHoliday($modal.Holiday);
                }

                function addNewHoliday(holiday) {
                    $modal.parent.createHolidayToDB(holiday)
                    .then(
                        function (response) {
                            if (!response.data.Succeeded)
                                $modal.errorMessage = response.data.Message;
                            else {
                                if ($modal.parent.yearFilter != holiday.Date.getFullYear()) {
                                    $modal.parent.yearFilter = holiday.Date.getFullYear();
                                    $modal.parent.getAvailableYears();
                                }
                                else
                                    $modal.parent.searchHolidays();

                                $uibModalInstance.close(holiday);
                            }
                        },
                        function (response) {
                            $modal.errorMessage = 'There was a problem while trying to save the record.';
                        });
                }


            }],
            controllerAs: 'model',
            resolve: {
                parent: function () { return vm; },
            }
        });
    }

})();
