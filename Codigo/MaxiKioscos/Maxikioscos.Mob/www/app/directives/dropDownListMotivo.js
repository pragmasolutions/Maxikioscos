
(function () {
    angular.module("maxikioscosApp", [])
        .directive('dropdownMotivo', dropdownMotivo);

    dropdownMotivo.$inject = ["marcaService"];

    function dropdownMotivo(motivoService) {
        return {
            restrict: 'E',
            templateUrl: '/templates/DropDownListMotivo.html',
            controllerAs: 'vm',            
            controller: function ($attrs, motivoService) {

                var vm = this;
                vm.motivos = [];
                vm.dataMotivos = [];                
               
                getAllDataMotivo()
                    .then(function () {
                        for (var i = 0; i < vm.motivos.data.length; i++) {
                            vm.dataMotivos.push(
                            {
                                Id: vm.motivos.data[i].Id,
                                Name: vm.motivos.data[i].Title
                            });
                        }
                    });

                function getAllDataMotivos() {
                    return motivoService.getAllMotivos()
                         .then(function (response) {
                             vm.motivos = response;
                             return vm.motivos;
                         });
                }
            }
        }
    }
})();
