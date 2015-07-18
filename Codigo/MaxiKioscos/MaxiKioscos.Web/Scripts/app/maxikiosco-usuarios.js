var maxikioscoAjax = function () {
    var $modal = $("#UsuariosModal"),
        $modalContent = $("#UsuariosModal .modal-content"),
        init = function () {
            $('.btn-usuario-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-usuario-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-usuario-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-usuario-eliminar', eliminar);
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
                validacion.parse('#UsuariosModal');
                controles.parse('#UsuariosModal');
                registrarEventos();
                checkearProveedor();
            }
        },
        refreshList = function () {
            var url = '/Usuarios';
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
                validacion.parse('#UsuariosModal');
                controles.parse('#UsuariosModal');
                $modal.modal();
                util.focusPrimerElemento($modalContent);
                registrarEventos();
                checkearProveedor();
                return false;
            });
        },
        registrarEventos = function () {
            $('#RoleId').change(function () {
                checkearProveedor();
            });
        },
        checkearProveedor = function () {
            if ($('#RoleId').val() != '3') {
                $('.usuario-proveedor').hide();
            } else {
                $('.usuario-proveedor').show();
            }
        };
    init();
}();