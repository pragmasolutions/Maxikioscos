var stocks = function () {
    var $modal = $("#StocksModal"),
        $modalContent = $("#StocksModal .modal-content"),
        $productoModal = $("#ProductosModal"),
        $productoModalContent = $("#ProductosModal .modal-content"),
        $frmActualizarStock = $("#FrmActualizarStock"),
        init = function () {
            $('.btn-stock-crear').click(crear);
            $("#TableStocks").on('click', 'a.btn-producto', detalleProducto);
            $("#TableStocks").on('click', 'a.btn-stock-editar, a.btn-stock-transferir', editar);
            $("#TableStocks").on('click', 'a.btn-stock-detalle', detalle);
            $("#TableStocks").on('click', 'a.btn-stock-eliminar', eliminar);

            $('#MaxiKioscoId').change(maxiKioscoChange);
            $modal.on('submit', 'form', submit);
        },
        detalleProducto = function () {
            var id = $(this).data().productoid;
            cargarVistaProducto(id);
            return false;
        },
        cargarVistaProducto = function (id, callback) {
            maxikioscoSpinner.startSpin();
            var url = '/Productos/Detalle/' + id;
            $productoModalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();

                if (callback) {
                    callback();
                }
                $productoModal.modal();
                //util.focusPrimerElemento($modalContent);
                return false;
            });
        },
        maxiKioscoChange = function () {
            //submit the form
            $(this).closest('form')
                    .submit();
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
        submitExito = function (response) {
            if (response.exito) {
                $modal.modal('hide').on('hidden.bs.modal', function () {
                    refreshList();
                });
            } else {
                $modalContent.html(response);
                registerEvents();
            }
        },
        refreshList = function () {
            $frmActualizarStock.submit();
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
                registerEvents();
                return false;
            });
        },
        registerEvents = function () {
            maxikioscoSpinner.stopSpin();

            //Reparse form.
            validacion.parse('#StocksModal');
            //Reparse form validation.
            controles.parse('#StocksModal');

            $modal.modal();
            util.focusPrimerElemento($modalContent);
        };
    init();
}();