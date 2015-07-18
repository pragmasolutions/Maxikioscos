var maxikioscoAjax = function () {
    var $modal = $("#ExcepcionesModal"),
        $modalContent = $("#ExcepcionesModal .modal-content"),
        init = function () {
            $('.btn-excepcion-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-excepcion-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-excepcion-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-excepcion-eliminar', eliminar);
            $modal.on('submit', 'form', submit);

            controles.parse('#AdminContainer');
        },
        crear = function () {
            var url = $(this).attr('href');
            cargarVista(url, crearCallback);
            return false;
        },
        crearCallback = function () {
            
            $('#Excepcion_CierreCajaId').attr('disabled', 'disabled');
            $('#MaxikioscoId').change(obtenerCierresCaja);
            
            $('#Fecha').datepicker({
                format: "dd/mm/yyyy",
            }).on('changeDate', function (ev) {
                obtenerCierresCaja();
                $(this).datepicker('hide');
            });
        },
        obtenerCierresCaja = function () {
            var fecha = $('#Fecha').val();
            var maxikioscoId = $('#MaxikioscoId').val();
            
            $('#Excepcion_CierreCajaId').empty();
            $('#Excepcion_CierreCajaId').append('<option value="">Seleccione Cierre Caja</option>');

            if (fecha && maxikioscoId) {
                dataservice.excepciones.obtenerCierresCaja(maxikioscoId, fecha, function (cierres) {
                    for (var i = 0; i < cierres.length; i++) {
                        var cierre = cierres[i];
                        $('#Excepcion_CierreCajaId').append('<option value="' + cierre.CierreCajaId + '">' + cierre.Nombre + '</option>');
                    }
                    $('#Excepcion_CierreCajaId').removeAttr('disabled');
                });
            } else {
                $('#Excepcion_CierreCajaId').attr('disabled', 'disabled');
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
                validacion.parse('#ExcepcionesModal');
                controles.parse('#ExcepcionesModal');
                
                $('#Fecha').datepicker({
                    format: "dd/mm/yyyy",
                }).on('changeDate', function (ev) {
                    obtenerCierresCaja();
                    $(this).datepicker('hide');
                });
                
                $('#MaxikioscoId').change(obtenerCierresCaja);
            }
        },
        refreshList = function () {
            var url = '/Excepciones';
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
        cargarVista = function (url, callback) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();
                validacion.parse('#ExcepcionesModal');
                controles.parse('#ExcepcionesModal');
                $modal.modal();

                if (callback) {
                    callback();
                }
                return false;
            });
        };
    init();
}();