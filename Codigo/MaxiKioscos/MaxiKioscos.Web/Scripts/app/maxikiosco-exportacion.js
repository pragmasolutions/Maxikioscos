var maxikioscoAjax = function () {
    var $modal = $("#SincronizacionModal"),
        $error = $("#ErrorModal"),
        $modalContent = $("#SincronizacionModal .modal-content"),
        init = function() {
            $('.btn-exportacion-crear').click(exportar);
            $('.btn-exportacion-descargar').click(descargar);
            $modal.on('submit', 'form', submit);
        },
        descargar = function () {
            var url = $(this).attr('href');
            dataservice.sincronizacion.exportar(function (result) {
                if (result.exito) {
                    refreshList();
                }
                cargarVista(url, function() {
                    registrarEventoParcial();
                });
                return false;
            });
            return false;
        },
        registrarEventoParcial = function() {
            $('input.descarga-tipo').click(function() {
                var descargaTipo = $('input[name=DescargaTipo]:checked', 'body').val();
                esconderOpciones(descargaTipo);
            });

            $('.btn-descargar').click(function() {
                $modal.modal('hide').on('hidden.bs.modal', function() {
                    //Refresh the list.
                    refreshList();
                    //window.open();
                });
            });
            
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
            var descargaTipo = $('input[name=DescargaTipo]:checked', 'body').val();
            if (response.exito) {
                if (response.tieneArchivos) {
                    $('.descarga-parcial').hide();
                    $('.descarga-kiosco').hide();
                    $('.descarga-fecha').hide();
                    $('#span-filename').html(response.filename);
                    $('#FileName').val(response.filename);
                    $('.descarga-nombre').show();
                    $('.descarga-tipo').attr('disabled', 'disabled');
                    $("#MaxiKioscoId").val(response.maxikioscoId);

                    var $form = $('form');
                    var data = $form.serialize();
                    var path = '/Sincronizacion/DescargarArchivo?DescargaTipo=' + descargaTipo + ' &' + data;
                    $('.btn-descargar').show();
                    $('.btn-descargar').attr('href', path);
                    $('.btn-validar').hide();
                } else {
                    alert('No hay datos para exportar para la opción seleccionada');
                }
                
            } else {
                $modalContent.html(response);
                validacion.parse('#SincronizacionModal');
                controles.parse('#SincronizacionModal');
                registrarEventoParcial();
                esconderOpciones(descargaTipo);
            }
        },
        esconderOpciones = function (valor) {
            $('.descarga-parcial').hide();
            $('.descarga-kiosco').hide();
            $('.descarga-fecha').hide();

            switch (valor) {
                case "1":
                    $('.descarga-kiosco').show();
                    break;
                case "3":
                    $('.descarga-parcial').show();
                    break;
                case "4":
                    $('.descarga-fecha').show();
                    break;
            }
        },
        exportar = function () {
            dataservice.sincronizacion.exportar(exportarCallback);
            return false;
        },
        exportarCallback = function (result) {
            if (result.exito) {
                refreshList();
            } else {
                $error.modal();
            }
        },
        refreshList = function () {
            var url = '/Sincronizacion';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function () {
                maxikioscoSpinner.stopSpin();
            });
        },
        cargarVista = function (url, loadCallback) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();
                validacion.parse('#SincronizacionModal');
                controles.parse('#SincronizacionModal');
                $modal.modal();
                if (loadCallback) {
                    loadCallback();
                }
                util.focusPrimerElemento($modalContent);
                return false;
            });
        };
    init();
}();