var maxikioscoAjax = function () {
    var $modal = $("#MarcasModal"),
        $modalContent = $("#MarcasModal .modal-content"),
        init = function () {
            $('.btn-marca-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-marca-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-marca-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-marca-eliminar', eliminar);
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
                validacion.parse('#MarcasModal');
                controles.parse('#MarcasModal');
            }
        },
        refreshList = function () {
            var url = '/Marcas';
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
        eliminarMarca = function () {
            var url = '/Marcas/Eliminar/' + $('#MarcaId').val();
            $.ajax({
                type: "POST",
                url: url
            }).done(submitExito);

            return false;
        },
        cargarVista = function (url) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();
                validacion.parse('#MarcasModal');
                controles.parse('#MarcasModal');
                $modal.modal();
                util.focusPrimerElemento($modalContent);
                $('.btn-eliminar').click(eliminarMarca);
                return false;
            });
        };
    init();
}();