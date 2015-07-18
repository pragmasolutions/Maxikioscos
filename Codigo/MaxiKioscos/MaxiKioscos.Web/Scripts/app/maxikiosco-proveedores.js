var proveedores = function () {
    var $modal = $("#ProveedoresModal"),
        $modalContent = $("#ProveedoresModal .modal-content"),
        init = function () {

            $('.btn-proveedor-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-proveedor-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-proveedor-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-proveedor-eliminar', eliminar);

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
        submitExito = function (parameters) {
            
            $modal.modal('hide').on('hidden.bs.modal', function () {
                //Refresh the list.
                refreshList();
            });
        },
        refreshList = function () {
            var url = '/Proveedores';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function() {
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
                validacion.parse('#ProveedoresModal');
                //Reparse form validation.
                controles.parse('#ProveedoresModal');

                $modal.modal();
                util.focusPrimerElemento($modalContent);
                return false;
            });
        };
    init();
}();