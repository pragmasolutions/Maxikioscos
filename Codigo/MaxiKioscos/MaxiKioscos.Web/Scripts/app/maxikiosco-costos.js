var maxikioscoAjax = function () {
    var $modal = $("#CostosModal"),
        $modalContent = $("#CostosModal .modal-content"),
        init = function () {
            $("#ListadoContainer").on('click', 'a.btn-costo-aprobar', aprobar);
            $("#ListadoContainer").on('click', 'a.btn-costo-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-costo-eliminar', eliminar);
            $modal.on('submit', 'form', submit);
            
            //Parse auto-submit-input
            controles.parse('#AdminContainer');
        },
        crear = function () {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        submit = function () {
            var $form = $(this);
            var url = $form.attr('action');
            var data = $form.serialize();
            //Post
            $.ajax({
                type: "POST",
                url: url,
                data: data
            }).done(submitExito);
            
            return false;
        },
        submitExito = function (result) {
            if (result.exito) {
                $modal.modal('hide').on('hidden.bs.modal', function () {
                    //Refresh the list.
                    refreshList();
                });
            } else {
                $modalContent.html(result);
                validacion.parse('#CostosModal');
                controles.parse('#CostosModal');
            }
        },
        refreshList = function () {
            var url = '/Costos';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function () {
                maxikioscoSpinner.stopSpin();
            });
        },
        aprobar = function () {
            var url = $(this).attr('href');
            maxikioscoSpinner.startSpin();
            $.ajax({
                type: "POST",
                url: url
            }).done(refreshList);
            return false;
        },
        detalle = function () {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        eliminar = function () {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        cargarVista = function (url) {
            
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();

                //Reparse form.
                validacion.parse('#CostosModal');
                //Reparse form validation.
                controles.parse('#CostosModal');

                $modal.modal();
                
                return false;
            });
        };
    init();
}();