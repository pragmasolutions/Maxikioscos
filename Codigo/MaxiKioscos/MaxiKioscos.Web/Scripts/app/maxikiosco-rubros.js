var maxikioscoAjax = function () {
    var $modal = $("#RubrosModal"),
        $modalContent = $("#RubrosModal .modal-content"),
        init = function () {
            $('.btn-rubro-crear').click(crear);
            $("#TableRubros").on('click', 'a.btn-rubro-editar', editar);
            $("#TableRubros").on('click', 'a.btn-rubro-detalle', detalle);
            $("#TableRubros").on('click', 'a.btn-rubro-eliminar', eliminar);
            $modal.on('submit', 'form', submit);
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
                validacion.parse('#RubrosModal');
                controles.parse('#RubrosModal');
            }
        },
        refreshList = function () {
            var url = '/Rubros';
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
                validacion.parse('#RubrosModal');
                controles.parse('#RubrosModal');
                $modal.modal();
                util.focusPrimerElemento($modalContent);
                return false;
            });
        };
    init();
}();