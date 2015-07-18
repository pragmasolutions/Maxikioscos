var maxikioscoAjax = function () {
    var $modal = $("#FacturasModal"),
        $modalContent = $("#FacturasModal .modal-content"),
        init = function () {
            $('.btn-factura-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-factura-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-factura-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-factura-eliminar', eliminar);
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
                validacion.parse('#FacturasModal');
                controles.parse('#FacturasModal');
            }
        },
        refreshList = function () {
            var url = '/Facturas';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function () {
                maxikioscoSpinner.stopSpin();
            });
        },
        editar = function () {
            var url = $(this).attr('href');
            cargarVista(url);
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
                validacion.parse('#FacturasModal');
                //Reparse form validation.
                controles.parse('#FacturasModal');

                $modal.modal();
                
                return false;
            });
        };
    init();
}();