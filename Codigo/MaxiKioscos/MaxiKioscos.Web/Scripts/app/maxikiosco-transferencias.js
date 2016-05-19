var transferencias = function () {
    var $modal,
        $modalContent = $("#TransferenciasModalContrainer"),
        _loadingView = false,
        init = function () {
            $('.btn-transferencia-crear').click(crear);
            $("#z").on('click', 'a.btn-transferencia-editar', editar);
            $("#TableTransferencias").on('click', 'a.btn-transferencia-detalle', detalle);
            $("#TableTransferencias").on('click', 'a.btn-transferencia-editar', editar);
            $("#TableTransferencias").on('click', 'a.btn-transferencia-eliminar', eliminar);
            $("#TableTransferencias").on('click', 'a.btn-transferencia-aprobar', aprobar);
            
            $(document).on('maxikiosco.transferenciasaved', transferenciaSaved);

        },
        crear = function () {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        transferenciaSaved = function (parameters) {
            
            $(document).off('maxikiosco.transferenciasaved', transferenciaSaved);
            if ($('#chxImprimir').prop('checked')) {
                var src = '/Transferencias/Imprimir/' + _transferenciaId;
                window.open(src);
            }
            
            $("#TransferenciasModal").modal('hide').on('hidden.bs.modal', function () {
                //Refresh the list.
                refreshList();
            });
        },
        refreshList = function () {
            _loadingView = true;
            var url = '/Transferencias';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function() {
                maxikioscoSpinner.stopSpin();
                _loadingView = false;
            });
        },
        editar = function () {
            if (!_loadingView) {
                var url = $(this).attr('href');
                cargarVista(url);
            }
            return false;
        },
        detalle = function () {
            if (!_loadingView) {
                var url = $(this).attr('href');
                cargarVista(url);
            }
            return false;
        },
        eliminar = function () {
            if (!_loadingView) {
                var url = $(this).attr('href');
                cargarVista(url);
            }
            return false;
        },
        aprobar = function () {
            if (!_loadingView) {
                var url = $(this).attr('href');
                maxikioscoSpinner.startSpin();
                $.ajax({
                    type: "POST",
                    url: url
                }).done(refreshList);
            }
            return false;
        },
        cargarVista = function (url) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();

                $modal = $modalContent.find('#TransferenciasModal');

                validacion.parse('#TransferenciasModal');
                controles.parse('#TransferenciasModal');

                $modal.modal({
                    backdrop: 'static'
                });

                util.focusPrimerElemento($modalContent);
                $('#FechaCreacion').attr('disabled', 'disabled');

                $('#FrmEliminarTransferencia').submit(submit);

                return false;
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
        submitExito = function (result) {
             
            if (result.exito) {
                $modal.modal('hide').on('hidden.bs.modal', function () {
                    //Refresh the list.
                    refreshList();
                });
            } else {
                
                $modalContent.html(result);
                validacion.parse('#TransferenciasModal');
                controles.parse('#TransferenciasModal');
            }
        };
    init();
}();