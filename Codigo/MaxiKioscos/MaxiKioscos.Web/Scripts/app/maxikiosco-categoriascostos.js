var maxikioscoAjax = function () {
    var $modal = $("#CategoriasCostosModal"),
        $modalContent = $("#CategoriasCostosModal .modal-content"),
        init = function () {
            $('.btn-categoriacosto-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-categoriacosto-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-categoriacosto-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-categoriacosto-eliminar', eliminar);
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
                validacion.parse('#CategoriasCostosModal');
                controles.parse('#CategoriasCostosModal');
            }
        },
        refreshList = function () {
            var url = '/CategoriasCostos';
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
                validacion.parse('#CategoriasCostosModal');
                controles.parse('#CategoriasCostosModal');
                $modal.modal();
                util.focusPrimerElemento($modalContent);
                return false;
            });
        };
    init();
}();