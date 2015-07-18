var excepcionRubro = function () {
    var $modal = $("#ExcepcionesRubrosModal"),
        $modalContent = $("#ExcepcionesRubrosModal .modal-content"),
        init = function () {

            $('.btn-excepcion-rubro-crear').click(crear);
            $("#TableExcepcionesRubros").on('click', 'a.btn-excepcion-rubro-editar', editar);
            $("#TableExcepcionesRubros").on('click', 'a.btn-excepcion-rubro-detalle', detalle);
            $("#TableExcepcionesRubros").on('click', 'a.btn-excepcion-rubro-eliminar', eliminar);

            $modal.on('click', 'input[name="TipoRecargo"]', toggleRadioTipoRecargo);
            $modal.on('submit', 'form', submit);
        },
        crear = function () {
            var url = $(this).attr('href');
            cargarVista(url,toggleRadioTipoRecargo);
            return false;
        },
        toggleRadioTipoRecargo = function () {

            var tipoRecargo = $('input[name="TipoRecargo"]:checked').val();
            var $form = $('#ExcepcionesRubrosModal form');
            if ($form.length > 0) {
                if (tipoRecargo == "Absoluto") {
                    $form.validate().element("#RecargoPorcentaje");
                    $('#RecargoPorcentaje').attr('disabled', 'disabled');
                    $('#RecargoAbsoluto').removeAttr('disabled');

                } else {
                    $form.validate().element("#RecargoAbsoluto");
                    $('#RecargoAbsoluto').attr('disabled', 'disabled');
                    $('#RecargoPorcentaje').removeAttr('disabled');
                }
            }

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
                validacion.parse('#ExcepcionesRubrosModal');
                controles.parse('#ExcepcionesRubrosModal');
                toggleRadioTipoRecargo();
            }
            
        },
        refreshList = function () {
            var url = '/ExcepcionesRubros';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function () {
                maxikioscoSpinner.stopSpin();
            });
        },
        editar = function () {
            var url = $(this).attr('href');
            cargarVista(url,toggleRadioTipoRecargo);
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
        cargarVista = function (url,callback) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();

                //Reparse form.
                validacion.parse('#ExcepcionesRubrosModal');
                //Reparse form validation.
                controles.parse('#ExcepcionesRubrosModal');
                

                $modal.modal();

                if (callback) {
                    callback();
                }
                
                util.focusPrimerElemento($modalContent);
                
                return false;
            });
        };
    init();
}();