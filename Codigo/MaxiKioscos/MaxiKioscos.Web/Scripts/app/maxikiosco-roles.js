var maxikioscoAjax = function () {
    var $modal = $("#RolesModal"),
        $modalContent = $("#RolesModal .modal-content"),
        init = function() {
            $("#ListadoContainer").on('click', 'a.btn-rol-reportes', cargarVista);
            $("#ListadoContainer").on('click', 'a.btn-rol-permisos', cargarVista);
            $modal.on('submit', 'form', submit);
        },
        submit = function() {
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
        submitExito = function(result) {
            if (result.exito) {
                $modal.modal('hide').on('hidden.bs.modal', function() {
                    //Refresh the list.
                    refreshList();
                });
            } else {
                $modalContent.html(result);
                validacion.parse('#RolesModal');
                controles.parse('#RolesModal');
            }
        },
        refreshList = function() {
            var url = '/Usuarios';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function() {
                maxikioscoSpinner.stopSpin();
            });
        },
        cargarVista = function() {
            var url = $(this).attr('href');
            $('#AdminContainer').load(url);
            return false;
        };
    init();
}();