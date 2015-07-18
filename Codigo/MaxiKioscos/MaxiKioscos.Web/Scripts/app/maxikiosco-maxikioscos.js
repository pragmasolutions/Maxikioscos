var maxikioscos = function () {
    var $modal = $("#MaxiKioscosModal"),
        $modalContent = $("#MaxiKioscosModal .modal-content"),
        init = function () {
            $('.btn-maxikiosco-crear').click(crear);
            $("#TableMaxiKioscos").on('click', 'a.btn-maxikiosco-editar', editar);
            $("#TableMaxiKioscos").on('click', 'a.btn-maxikiosco-detalle', detalle);
            $("#TableMaxiKioscos").on('click', 'a.btn-maxikiosco-eliminar', eliminar);

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
        submitExito = function (response) {
            if (response.exito) {
                $modal.modal('hide').on('hidden.bs.modal', function () {
                    refreshList();
                });
            }
        },
        refreshList = function () {
            var url = '/MaxiKioscos';
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
                validacion.parse('#MaxiKioscosModal');
                //Reparse form validation.
                controles.parse('#MaxiKioscosModal');

                $modal.modal();
                util.focusPrimerElemento($modalContent);
                return false;
            });
        };
    init();
}();