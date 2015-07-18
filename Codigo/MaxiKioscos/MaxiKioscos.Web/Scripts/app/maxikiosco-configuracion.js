var maxikioscoAjax = function () {
    var $modal = $("#ConfiguracionModal"),
        $modalContent = $("#ConfiguracionModal .modal-content"),
        init = function () {
            $('.btn-configuracion-editar').click(editar);
            $modal.on('submit', 'form', submit);
        },
        editar = function () {
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
                    refreshPage();

                    maxikiosco.cuenta.margenImporteFactura = result.fields.MargenImporteFactura;
                    maxikiosco.cuenta.porcentajePercepcionIVA = result.fields.PorcentajePercepcionIVA;
                    maxikiosco.cuenta.aplicarPercepcionIVADesde = result.fields.AplicarPercepcionIVADesde;
                });
            } else {
                $modalContent.html(result);
                validacion.parse('#ConfiguracionModal');
                controles.parse('#ConfiguracionModal');
            }
        },
        refreshPage = function () {
            var url = '/Cuenta';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function () {
                maxikioscoSpinner.stopSpin();
            });
        },
        cargarVista = function (url) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();
                validacion.parse('#ConfiguracionModal');
                controles.parse('#ConfiguracionModal');
                $modal.modal();

                $modal.find('#SincronizarAutomaticamente').change(function() {
                    if ($(this).val() != "true") {
                        $modal.find('#IntervaloSincronizacion').val("");
                    }
                });
                return false;
            });
        };
    init();
}();