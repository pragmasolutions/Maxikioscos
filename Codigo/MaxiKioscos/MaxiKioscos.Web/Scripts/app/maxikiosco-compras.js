var compras = function () {
    var $modal,
        $modalContent = $("#ComprasModalContrainer"),
        init = function () {
            $('.btn-compra-crear').click(crear);
            $("#TableCompras").on('click', 'a.btn-compra-editar', editar);
            $("#TableCompras").on('click', 'a.btn-compra-detalle', detalle);
            $("#TableCompras").on('click', 'a.btn-compra-eliminar', eliminar);

            $(document).off('maxikiosco.comprasaved');
            $(document).on('maxikiosco.comprasaved', compraSaved);

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