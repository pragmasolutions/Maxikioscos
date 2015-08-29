var compras = function () {
    var $modal,
        $modalContent = $("#ComprasModalContrainer"),
        init = function () {
            $('.btn-compra-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-compra-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-compra-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-compra-eliminar', eliminar);

            $(document).off('maxikiosco.comprasaved');
            $(document).on('maxikiosco.comprasaved', compraSaved);
            //$modal.on('submit', 'form', submit);
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
                validacion.parse('#ComprasModal');
                controles.parse('#ComprasModal');
            }
        },
        crear = function () {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        compraSaved = function (parameters) {
            refreshList();
        },
        refreshList = function () {
            var url = '/Compras';
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

                //Asignar el modal cada vez que se carla vista.
                //En este script es distinto por que la vista parcial contiene varios modales
                ///Por lo que tenemos un container principal $modalContent.
                $modal = $modalContent.find('#ComprasModal');
                //Reparse form.
                validacion.parse('#ComprasModal');
                //Reparse form validation.
                controles.parse('#ComprasModal');

                $modal.modal({
                    backdrop: 'static'
                });
                util.focusPrimerElemento($modalContent);
                return false;
            });
        };
    init();
}();