var seleccionarProducto = function () {
    var $currentRow,
        $modal = $("#SeleccionarProductoModal"),
        $formFilter = $("#SeleccionarProductoModal form"),
        $modalCrearProductos = $('#ProductosModal'),
        $modalCrearProductosContent = $("#ProductosModal .modal-content"),
        $modalCrearProductoError = $('#ProductoErrorModal'),
        $modalCrearProductoErrorContent = $('#ProductoErrorModal .modal-content'),
        dirtySearch = false,
        _agregandoProducto = false,
        init = function () {
            $('.btn-producto-crear').click(crear);

            $modalCrearProductos.on('maxikiosco.productoSubmitCompleted', productoSubmitCompleted);

            //Evento seleccionar producto
            $modal.on('click', '.btn-seleccionar-producto', seleccionarProducto);

            //Parsear los controles dentro del modal.
            controles.parse("#SeleccionarProductoModal");

            $modal.on('shown.bs.modal', function () {
                //Eventos de acceso directo.
                $(document).on('keydown', null, 'Down', tableKeydown);
                $(document).on('keydown', null, 'Up', tableKeyup);
                $('#Descripcion', $modal).on('keydown', null, 'Down', tableKeydown);
                $('#Descripcion', $modal).on('keydown', null, 'Up', tableKeyup);
                //Captura enter en la fila actual.
                $(document).keydown(enterKeyDown);

                //Fucus en el input de descripcion.
                $('#Descripcion', this).select()[0].focus();
                dirtySearch = false;
            });

            $modal.on('hidden.bs.modal', function () {
                //Unsuscribe from key events
                $(document).off('keydown', tableKeydown);
                $(document).off('keydown', tableKeyup);
                $('#Descripcion', $modal).off('keydown', tableKeydown);
                $('#Descripcion', $modal).off('keydown', tableKeyup);
                $(document).off('keydown', enterKeyDown);
            });

            $modal.on('keyup', '.search-textbox', handleBuscador);
            
            //Seleccionamos la primer fila.
            seleccionarPrimeraFila();
        },
        handleBuscador = function (e) {
            e.preventDefault();
            var $input = $('.search-textbox');
            if (e.which == 38 || e.which == 40) {
                dirtySearch = false;
            } else if (e.which != 32 && e.which != 13) {
                dirtySearch = true;
            } else {
                dirtySearch = false;

                //Submit cuando es space. para el enter se hace submit automatico
                if (e.which == 32) {
                    $input.closest('form').submit();
                }
            }
        }
        crear = function () {
            var url = $(this).attr('href');
            maxikioscoSpinner.startSpin();
            $modalCrearProductosContent.load(url, function () {
                maxikioscoSpinner.stopSpin();

                $modalCrearProductos.modal();

                return false;
            });
            return false;
        },
        productoSubmitCompleted = function (e, response) {
            
            if (response.exito) {
                $modalCrearProductos.modal('hide').on('hidden.bs.modal', modalHiddenAfterSuccess);
                $modal.find('.search-textbox').val(response.descripcion);
                $modal.find('#BuscarPorDescripcion[value="True"]').prop('checked', true);
                $modal.find('form').submit();
            }
            else {

                $modalCrearProductos.modal('hide');
                $modalCrearProductoErrorContent.load('/Productos/CodigoDuplicadoPopup', function () {
                    maxikioscoSpinner.stopSpin();
                    validacion.parse('#ProductoErrorModal');
                    controles.parse('#ProductoErrorModal');
                    $modalCrearProductoError.modal();
                });
            }
        },
        modalHiddenAfterSuccess = function () {
            //Unsubscribe
            $modalCrearProductos.off('hidden.bs.modal', modalHiddenAfterSuccess);

            $formFilter.submit();
        },
        enterKeyDown = function (event) {
             
            if (event.which === 13) {
                if (dirtySearch) {
                    dirtySearch = false;
                }
                else {
                    if ($currentRow) {
                        if (!_agregandoProducto) {
                            _agregandoProducto = true;
                            var $btnSeleccionar = $currentRow.find('.btn-seleccionar-producto');
                            var productoId = $btnSeleccionar.data('productoid');
                            onProductoSeleccionado(productoId);
                            $modal.modal('hide');

                            setTimeout(function() { _agregandoProducto = false; }, 1500);
                            return false;
                        }
                    }
                }
            }
        },
        tableKeydown = function (e) {

            //Si no hay row actual seleccionar la primera.
            if ($currentRow.length === 0) {

                $currentRow = $('tr:first', '#TableSeleccionarProductos tbody')
                    .addClass('highlight');
                return;
            }

            $currentRow.toggleClass('highlight');
            var $nextRow = $currentRow.next('tr');
            if ($nextRow.length > 0) {
                $currentRow = $nextRow;
            }

            $currentRow.toggleClass('highlight');

        },
        tableKeyup = function (e) {

            //Si no hay row actual seleccionar la ultima.
            if ($currentRow.length === 0) {
                $currentRow = $('tr:last', '#TableSeleccionarProductos tbody')
                    .addClass('highlight');
                return;
            }

            $currentRow.toggleClass('highlight');
            var $prevRow = $currentRow.prev('tr');
            if ($prevRow.length > 0) {
                $currentRow = $prevRow;
            }
            $currentRow.toggleClass('highlight');
        },
        seleccionarPrimeraFila = function () {
            //Seleccionamos la primer fila.
            $currentRow = $('tr:first', '#TableSeleccionarProductos tbody');
            $currentRow.toggleClass('highlight');
        },
        onProductoSeleccionado = function (productoId) {
            $modal.trigger('maxikiosco.productoselected', [productoId]);
        },
        showLoading = function () {
            $('#SeleccionarProductosLoading').show();
        },
        hideLoading = function () {
            $('#SeleccionarProductosLoading').hide();
        },
        seleccionarProducto = function () {
            var $btn = $(this);
            var productoId = $btn.data('productoid');
            onProductoSeleccionado(productoId);
        };
    init();

    return {
        showLoading: showLoading,
        hideLoading: hideLoading,
        seleccionarPrimeraFila: seleccionarPrimeraFila
    };
}();