var _transferenciaId;
(function () {
    var $modal = $('#TransferenciasModal'),
        $ingresarCantidadModal = $('#IngresarCantidadModal'),
        $agregarProductoModal = $('#SeleccionarProductoModal'),
        $currentRow = $('#TableTransferenciasProductos tbody tr:first'),
        $tableTransferenciaProductos = $('#TableTransferenciasProductos'),
        $tableTransferenciaProductosBody = $("#TableTransferenciasProductos tbody"),
        init = function() {
            _aprobar = false;
            $modal.on('submit', 'form#FrmCrearTransferencia', submit);

            //highlight current row
            $('#TableTransferenciasProductos').on('click', 'tr', tableTransferenciasClick);

            //Cargar un nuevo transferencia producto cuando se selecciona un producto del modal
            $("#SeleccionarProductoModal").on('maxikiosco.productoselected', productoSeleccionado);
            $("#TransferenciasModal #OrigenId").change(nodosChange);
            $("#TransferenciasModal #DestinoId").change(nodosChange);
            $('#TableTransferenciasProductos').on('click', '.btn-transferencia-producto-eliminar', eliminarTransferenciaProductoClick);
            
            //Eventos botones inferiores.
            $(".btn-asterisco").click(ingresarCantidad);
            $(".btn-mas").click(agregarProducto);
            $(".btn-suprimir").click(eliminarTransferenciaProductoActual);

            //Eventos de acceso directo.
            $(document).on('keydown', null, '*', ingresarCantidad);
            $(document).on('keydown', null, 'del', eliminarTransferenciaProductoActual);
            $(document).on('keydown', null, 'Down', tableTransferenciasKeydown);
            $(document).on('keydown', null, 'Up', tableTransferenciasKeyup);
            $(document).on('keydown', null, '+', agregarProducto);

            $modal.on('hidden.bs.modal', function() {

                //Unsuscribe from key events
                $(document).off('keydown', ingresarCantidad);
                $(document).off('keydown', eliminarTransferenciaProducto);
                $(document).off('keydown', tableTransferenciasKeydown);
                $(document).off('keydown', tableTransferenciasKeyup);
                $(document).off('keydown', agregarProducto);
            });

            //Focus first input in modals.
            $ingresarCantidadModal.on('shown.bs.modal', function() {
                controles.parse('#IngresarCantidadModal');
                validacion.parse('#IngresarCantidadModal');
                $('#CantidadIngresada', this).select()[0].focus();
            });
            
            //Cantidad precio y costo modificaciones submits.
            $ingresarCantidadModal.find('#FrmIngresarCantidad').submit(ingresarCantidadSubmit);

            $('.modal .btn-aprobar').click(aprobar);
        },
        aprobar = function () {
            _aprobar = true;
            submit();
        },
        submit = function (e) {
            
            if (e) {
                e.preventDefault();
            }
            var $form = $('#FrmCrearTransferencia');
            ////Checkear que la transferencia tenga almenos un producto.
            if (!formValid($form)) {
                return false;
            }

            $form.find('#OrigenId, #DestinoId').removeAttr('disabled');

            var url = $form.attr('action');
            var data = $form.serialize();
            data += '&aprobar=' + _aprobar;
            maxikioscoSpinner.startSpin();
            //Post
            $.ajax({
                type: "POST",
                url: url,
                data: data
            })
                .done(submitExito)
                .always(function() {
                    maxikioscoSpinner.stopSpin();
                });

            return false;
        },
        submitExito = function(response) {
            //Raise transferenciasaved para refrescar la grilla
            _transferenciaId = response.TransferenciaId;
            $(document).trigger('maxikiosco.transferenciasaved');
        },
        formValid = function(form) {

            //Validar cantidad de productos.
            var cantProductos = form.find('#TableTransferenciasProductos tbody tr').length;
            if (cantProductos === 0) {
                alert('Debe ingresar al menos un producto');
                return false;
            }

            return true;
        },
        agregarProducto = function() {
            $agregarProductoModal.modal();
        },
        productoSeleccionado = function(event, productoId) {

            //Verificamos que no exista el producto cargado
            var productoSelector = String.format('td input[name$=".ProductoId"][value="{0}"]', productoId);
            var producto = $tableTransferenciaProductos.find(productoSelector);
            if (producto.length > 0) {
                return;
            }

            var origenId = $('#TransferenciasModal #OrigenId').val();
            var destinoId = $('#TransferenciasModal #DestinoId').val();
            cargarProducto(productoId, origenId, destinoId);
        },
        cargarProducto = function(productoId, origenId, destinoId) {

            var data = { productoId: productoId, origenId: origenId, destinoId: destinoId };
            var url = '/Transferencias/CargarProducto';
            maxikioscoSpinner.startSpin();
            $.ajax({
                url: url,
                data: data
            }).done(function (row) {
                var $row = $(row);

                $tableTransferenciaProductosBody.append($row);

                $currentRow.removeClass('highlight');
                $currentRow = $row;
                $currentRow.addClass('highlight');

                toggleTransferencia();

                $modal.animate({
                    scrollTop: $currentRow.position().top
                }, 1000);

            }).always(function() {
                maxikioscoSpinner.stopSpin();
            });
        },
        ingresarCantidad = function() {
            //Obtener cantidad actual
            if ($currentRow.length === 0) {
                return;
            }

            var $inputCantidad = $ingresarCantidadModal.find('input#CantidadIngresada');
            $inputCantidad.val('');
            $ingresarCantidadModal.modal();
        },
        ingresarCantidadSubmit = function() {
            if (!$(this).valid()) {
                return false;
            }

            var cantidad = Globalize.parseFloat($('#CantidadIngresada', this).val());
            cantidad = !isNaN(cantidad) ? cantidad : 0;

            $currentRow.find('input[name$=".Cantidad"]')
                .val(cantidad)
                .closest('td')
                .find('.cell-text-content')
                .empty()
                .text(Globalize.format(cantidad, 'n2'));
            
            $ingresarCantidadModal.modal('hide');

            return false;
        },
        eliminarTransferenciaProductoActual = function() {
            eliminarTransferenciaProducto($currentRow);
        },
        eliminarTransferenciaProductoClick = function() {
            var $tr = $(this)
                .closest('tr');
            eliminarTransferenciaProducto($tr);
            return false;
        },
        eliminarTransferenciaProducto = function(tr) {

            var $filaSeleccionar = $(tr).prev('tr');

            if ($filaSeleccionar.length == 0) {
                $filaSeleccionar = $(tr).next('tr');
            }

            $currentRow.removeClass('highlight');
            $currentRow = $filaSeleccionar;
            $currentRow.addClass('highlight');

            $(tr).remove();
            toggleTransferencia();
        },
        tableTransferenciasClick = function() {
            if (!($(this).find('td:eq(0)').hasClass('total-footer-label'))) {
                $currentRow = $(this);
                $currentRow.closest('tbody').find('tr').removeClass('highlight');
                $currentRow.addClass('highlight');
            }
        },
        tableTransferenciasKeydown = function (e) {
            
            e.preventDefault();
            //Si no hay row actual seleccionar la primera.
            if ($currentRow.length === 0) {
                $currentRow = $('tr:first', '#TableTransferenciasProductos tbody').addClass('highlight');
                return;
            }

            var $nextRow = $currentRow.next('tr');
            if ($nextRow.length > 0) {
                $currentRow.removeClass('highlight');
                $currentRow = $nextRow;
                $currentRow.addClass('highlight');
                scrollToCurrentRow();
            }

        },
        tableTransferenciasKeyup = function(e) {
            e.preventDefault();
            //Si no hay row actual seleccionar la ultima.
            if ($currentRow.length === 0) {
                $currentRow = $('tr:last', '#TableTransferenciasProductos tbody').addClass('highlight');
                return;
            }

            var $prevRow = $currentRow.prev('tr');
            if ($prevRow.length > 0) {
                $currentRow.removeClass('highlight');
                $currentRow = $prevRow;
                $currentRow.addClass('highlight');
                scrollToCurrentRow();
            }
        },
        nodosChange = function() {

            $(this).valid();

            var origenId = $('#TransferenciasModal #OrigenId').val();
            var destinoId = $('#TransferenciasModal #DestinoId').val();

            if (String.isNullOrEmpty(origenId) || String.isNullOrEmpty(destinoId) || origenId == destinoId) {
                $('#AgregarProducto', $modal).attr('disabled', 'disabled');
                return;
            }

            
            //Si la factura es diferente y existe almenos un producto cargado no cambiar.
            if (existenProductosCargados()) {
                alert("No se pueden cambiar los nodos ya que existen productos cargados");
                return;
            }

            $('#AgregarProducto', $modal).removeAttrs('disabled');

            //Cada vez que cambia el origen tenemos que actualizar el listado que aparece para 
            //Reflejar el stock del mismo.
            $agregarProductoModal.find('#MostrarStockMaxikioscoId').val(origenId);

            $agregarProductoModal.find('#TableSeleccionarProductos tr td.stock-origen')
                .html('<img src="/Content/imagenes/loading.gif" />');

            $agregarProductoModal.find('form').submit();
        },
        existenProductosCargados = function() {
            var existenProductos = false;
            $tableTransferenciaProductos.find('tbody tr').each(function() {
                existenProductos = true;
                return false;
            });
            return existenProductos;
        },
        toggleTransferencia = function () {
            var $origen = $modal.find("#OrigenId");
            var $destino = $modal.find("#DestinoId");

            if (!existenProductosCargados()) {
                $origen.removeAttr("disabled");
                $destino.removeAttr("disabled");
            } else {
                $origen.attr("disabled", "disabled");
                $destino.attr("disabled", "disabled");
            }
        },
        scrollToCurrentRow = function() {
            if (!inViewport($currentRow)) {
                
                $modal.animate({
                    scrollTop: $currentRow.position().top - ($modal.height() / 2)
                }, 0);
            }
        },
        inViewport = function (el) {
            
            //special bonus for those using jQuery
            if (typeof jQuery === "function" && el instanceof jQuery) {
                el = el[0];
            }

            var rect = el.getBoundingClientRect();

            return (
                rect.top >= 0 &&
                rect.left >= 0 &&
                rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) && /*or $(window).height() */
                rect.right <= (window.innerWidth || document.documentElement.clientWidth) /*or $(window).width() */
            );
        };
    init();
})();