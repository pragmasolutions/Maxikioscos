var maxikioscoAjax = function () {
    var $modal = $("#RolesModal"),
        $modalContent = $("#RolesModal .modal-content"),
        init = function () {
            $("#AdminContainer").unbind().on('click', 'a.btn-reporte-agregar', cargarPopup);
            $("#ListadoContainer").unbind().on('click', 'a.btn-reporte-eliminar', eliminar);
            $modal.unbind().on('submit', 'form', submit);
            $("#AdminContainer").on('click', 'a.btn-volver', cargarVista);
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
            var url = '/Roles/Reportes/' + $('#RoleId').val();
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function() {
                maxikioscoSpinner.stopSpin();
            });
        },
        cargarVista = function () {
            var url = $(this).attr('href');
            $('#AdminContainer').load(url);
            return false;
        },
        cargarPopup = function() {
            var url = $(this).attr('href');
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function() {
                maxikioscoSpinner.stopSpin();
                validacion.parse('#RolesModal');
                controles.parse('#RolesModal');
                $modal.modal();
                util.focusPrimerElemento($modalContent);
                return false;
            });
            return false;
        },
        eliminar = function () {
            var url = $(this).attr('href');
            //Post
            $.ajax({
                type: "POST",
                url: url
            }).done(refreshList);
            return false;
        }
    init();
}();