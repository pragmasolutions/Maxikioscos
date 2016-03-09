
(function () {
    angular.module("maxikioscosApp", [])
        .directive('dropdownMarca', dropdownMarca);

    dropdownMarca.$inject = ["marcaService"];

    function dropdownMarca(marcaService) {
        return {
            restrict: 'E',
            templateUrl: '/templates/DropDownListMarca.html',
            controllerAs: 'vm',            
            controller: function ($attrs, marcaService) {

                var vm = this;
                vm.marcas = [];
                vm.dataMarcas = [];                
               
                getAllDataMarcas()
                    .then(function () {
                        for (var i = 0; i < vm.marcas.data.length; i++) {
                            vm.dataMarcas.push(
                            {
                                Id: vm.marcas.data[i].Id,
                                Name: vm.marcas.data[i].Title
                            });
                        }
                    });

                function getAllDataMarcas() {
                    return marcaService.getAllMarcas()
                         .then(function (response) {
                             vm.marcas = response;
                             return vm.marcas;
                         });
                }
            }
        }
    }
})();
