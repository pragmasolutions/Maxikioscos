
(function () {
    angular.module("maxikioscosApp", [])
        .directive('dropdownRubro', dropdownRubro);

    dropdownRubro.$inject = ["rubroService"];

    function dropdownRubro(rubroService) {
        return {
            restrict: 'AE',
            templateUrl: '/templates/DropDownListRubro.html',            
            controllerAs: 'vmRubro',
            controller: function (rubroService, $element, $attrs, $scope) {

                var vmRubro = this;
                vmRubro.rubros = [];

                vmRubro.requiredRubro = {value : false};
                
                if ($attrs.requiredRubro) {
                    vmRubro.requiredRubro.value = $attrs.requiredRubro.toLowerCase() == 'true';
                }

                $attrs.$observe('marcaid', function (actual_value) {
                    vmRubro.rubros = [];
                    if (actual_value != "") {
                        rubroeService.getAllRubrosByMarca(actual_value)
                          .then(function (rubros) {
                              if (rubros.data.length > 0) {
                                  for (var i = 0; i < rubros.data.length; i++) {
                                      vmRubro.rubros.push(
                                      {
                                          Id: rubros.data[i].Id,
                                          Name: rubros.data[i].Name
                                      })
                                  }
                              }
                              else {
                                  $scope.selectedRubro = null;
                              }
                          });
                    }
                })
            }
        }
    }
})();
