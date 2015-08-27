(function () {
    var $modal = $('#ComprasModal'),
        $agregarProductoModal = $('#SeleccionarProductoModal'),
        $currentRow = $('#TableComprasProductos tbody tr:first'),
        $tableCompraProductos = $('#TableComprasProductos'),
        $tableCompraProductosBody = $("#TableComprasProductos tbody"),
        currentFactura = null,

        init = function () {

            $modal.on('submit', 'form#FrmCrearCompra', submitCompra);

            //configureBtnCancel();

            $('#TableComprasProductos').on('click', 'tr', tableComprasClick);
            $("#SeleccionarProductoModal").on('maxikiosco.productoselected', productoSeleccionado);
            $("#FacturaId", $modal).change(facturaChange);
            $('#TableComprasProductos', $modal).on('click', '.btn-compra-producto-eliminar', eliminarCompraProductoClick);
            $('input[name="TipoDescuento"]').click(toggleRadioTipoDescuento);

            toggleRadioTipoDescuento();

            $("#Factura_DescuentoPorcentaje").blur(descuentoBlur);
            $("#Factura_DescuentoEnPesos").blur(descuentoBlur);

            $("#Numero").blur(function () {
                var url = $(this).data('get-factura-url') + '?autonumero=' + $(this).val();
                maxikioscoSpinner.stopSpin();
                $.ajax({
                    type: "GET",
                    url: url
                }).done(function (data) {
                    debugger;
                    if (data.factura) {
                        var facturaId = data.factura.FacturaId;
                        $("#FacturaId", $modal).val(facturaId).trigger('change');
                    } else {
                        $("#Numero").val('');
                    }
                }).always(function () {
                    maxikioscoSpinner.stopSpin();
                });
            });

            //Eventos botones inferiores.
            $(".btn-asterisco").click(ingresarCantidad);
            $(".btn-barra").click(ingresarCostoPrecio);
            $(".btn-mas").click(agregarProducto);
            $(".btn-suprimir").click(eliminarCompraProductoActual);

            subscribeToKeyEvents();

            $modal.on('hide.bs.modal', function (e) {
                e.preventDefault();

                $.confirm({
                    text: "¿Esta seguro que desea cancelar la compra?",
                    title: "Cancelar Compra",
                    confirm: function () {
                        
                        unsubscribeToKeyEvents();

                        $modal.off('hide.bs.modal');
                        $modal.modal('hide');
                    },
                    confirmButton: "Aceptar",
                    cancelButton: "Cancelar"
                });
            });

            $("#PercepcionDGRManual", $modal).change(function () {
                if ($(this).is(':checked')) {
                    $("#PercepcionDGR").removeAttr('readonly');
                } else {
                    $("#PercepcionDGR").attr('readonly', 'readonly');
                }
                actualizarTotalCompra();
            }).trigger('change');

            $('#PercepcionDGR', $modal).change(actualizarTotalCompra);

            $('#PercepcionIVA', $modal).change(actualizarTotalCompra);

            $("#PercepcionIVAManual", $modal).change(function () {
                if ($(this).is(':checked')) {
                    $("#PercepcionIVA").removeAttr('readonly');
                } else {
                    $("#PercepcionIVA").attr('readonly', 'readonly');
                }
                actualizarTotalCompra();
            }).trigger('change');

            $(document).off('maxikiosco.editar-compra-producto-cancelado');
            $(document).on('maxikiosco.editar-compra-producto-cancelado', editarCompraProductoCancelado);

            $(document).off('maxikiosco.maxikiosco.compra-producto-editado');
            $(document).on('maxikiosco.maxikiosco.compra-producto-editado', compraProductoEditado);
        },

        descuentoBlur = function () {
            actualizarDescuento();
            actualizarTotalCompra();
        },

        subscribeToKeyEvents = function () {

            $(document).on('keydown', null, '*', ingresarCantidad);
            $(document).on('keydown', null, '/', ingresarCostoPrecio);
            $(document).on('keydown', null, 'del', eliminarCompraProductoActual);
            $(document).on('keydown', null, 'Down', tableComprasKeydown);
            $(document).on('keydown', null, 'Up', tableComprasKeyup);
            $(document).on('keydown', null, '+', agregarProducto);
        },

        unsubscribeToKeyEvents = function () {

            $(document).off('keydown', ingresarCantidad);
            $(document).off('keydown', ingresarCostoPrecio);
            $(document).off('keydown', eliminarCompraProducto);
            $(document).off('keydown', tableComprasKeydown);
            $(document).off('keydown', tableComprasKeyup);
            $(document).off('keydown', agregarProducto);
        },

        configureBtnCancel = function () {
            $("#BtnCancelar", $modal).confirm({
                text: "¿Esta seguro que desea cancelar la compra?",
                title: "Cancelar Compra",
                confirm: function () {
                    $modal.modal('hide');
                },
                confirmButton: "Aceptar",
                cancelButton: "Cancelar"
            });
        },

        submitCompra = function (e) {

            e.preventDefault();

            var $form = $(this);

            ////Checkear que la compra tenga almenos un producto.
            if (!isFormComprasValid($form)) {
                return false;
            }

            $.confirm({
                text: "¿Esta seguro que desea crear la compra?",
                title: "Crear Compra",
                confirm: function () {

                    var url = $form.attr('action');
                    var data = $form.serialize();

                    maxikioscoSpinner.startSpin();

                    $.ajax({
                        type: "POST",
                        url: url,
                        data: data
                    })
                    .done(function () {

                        $modal.off('hide.bs.modal');

                        $modal.modal('hide').on('hidden.bs.modal', function () {
                            unsubscribeToKeyEvents();
                            $modal.off('hidden.bs.modal');
                            $(document).trigger('maxikiosco.comprasaved');
                        });
                    })
                    .always(function () {
                        maxikioscoSpinner.stopSpin();
                    });
                },
                confirmButton: "Aceptar",
                cancelButton: "Cancelar"
            });

            return false;
        },

        isFormComprasValid = function (form) {

            //Validar cantidad de productos.
            var cantProductos = form.find('#TableComprasProductos tbody tr').length;
            if (cantProductos === 0) {
                alert('Debe ingresar al menos un producto');
                return false;
            }

            //Validar margen importe factura.
            var compraTot = totalGeneral();
            var diff = Math.abs(compraTot - currentFactura.importeTotal);
            var margenImporte = 10;

            if (maxikiosco.cuenta.margenImporteFactura != null) {
                margenImporte = maxikiosco.cuenta.margenImporteFactura;
            }
            if (diff > margenImporte) {

                var totalErrorMessage =
                    String.format('No se puede cargar la factura. El importe total (${0}) difiere del importe de la factura (${1}) en un valor mayor al máximo margen de factura establecido ({2})',
                        totalCompra, currentFactura.importeTotal, margenImporte);

                alert(totalErrorMessage);

                return false;
            }

            return true;
        },

        agregarProducto = function () {
            $agregarProductoModal.modal();
        },

        productoSeleccionado = function (event, productoId) {

            //Verificamos que no exista el producto cargado
            var productoSelector = String.format('td input[name$=".ProductoId"][value="{0}"]', productoId);
            var producto = $tableCompraProductos.find(productoSelector);
            if (producto.length > 0) {
                return;
            }

            var proveedorId = $('#ProveedorId', $modal).val();
            cargarProducto(productoId, currentFactura.maxiKioscoId, proveedorId);
        },

        getCostoFromRow = function (row) {
            var costoString = row.find('input[name$=".CostoActualizado"]').val();
            var costo = !String.isNullOrEmpty(costoString) ? Globalize.parseFloat(costoString) : null;
            return costo;
        },

        getPrecioFromRow = function (row) {
            var precioString = row.find('input[name$=".PrecioActualizado"]').val();
            var precio = !String.isNullOrEmpty(precioString) ? Globalize.parseFloat(precioString) : null;
            return precio;
        },

        getCantidadFromRow = function (row) {
            var cantidadString = row.find('input[name$=".Cantidad"]').val();
            var cantidad = !String.isNullOrEmpty(cantidadString) ? Globalize.parseFloat(cantidadString) : null;
            return cantidad;
        },

        getNombreFromRow = function (row) {
            return row.find('.col-compra-producto-descripcion').text();
        },

        getTotalConIvaFromRow = function (row) {
            var totalConIvaString = row.find('input[name$=".TotalConIVA"]').val();
            var totalConIva = !String.isNullOrEmpty(totalConIvaString) ? Globalize.parseFloat(totalConIvaString) : null;
            return totalConIva;
        },

        getTotalSinIvaFromRow = function (row) {
            var totaSinIvaString = row.find('input[name$=".TotalSinIVA"]').val();
            var totalSinIva = !String.isNullOrEmpty(totaSinIvaString) ? Globalize.parseFloat(totaSinIvaString) : null;
            return totalSinIva;
        },

        getProductFromRow = function (row) {

            var costo = getCostoFromRow(row);
            var precio = getPrecioFromRow(row);
            var cantidad = getCantidadFromRow(row);
            var nombre = getNombreFromRow(row);
            var totalConIva = getTotalConIvaFromRow(row);
            var totalSinIva = getTotalSinIvaFromRow(row);
            var proveedor = currentFactura.proveedor;

            var producto = {
                costo: costo,
                precio: precio,
                cantidad: cantidad,
                nombre: nombre,
                totalConIva: totalConIva,
                totalSinIva: totalSinIva,
                proveedor: proveedor
            };

            return producto;
        },

        triggerProductoCargado = function (producto) {
            $(document).trigger('maxikiosco.producto-cargado', [producto]);
        },

        focusCurrentRow = function () {
            $modal.animate({
                scrollTop: $currentRow.position().top
            }, 1000);
        },

        cambiarCurrentRow = function (row) {
            $currentRow.removeClass('highlight');
            $currentRow = row;
            $currentRow.addClass('highlight');
        },

        cargarProducto = function (productoId, maxikioscoId, proveedorId) {
            var data = { productoId: productoId, maxikioscoId: maxikioscoId, proveedorId: proveedorId };
            var url = '/Compras/CargarProducto';

            maxikioscoSpinner.startSpin();
            $.ajax({
                url: url,
                data: data
            }).done(function (row) {
                var $row = $(row);

                $tableCompraProductosBody.append($row);

                cambiarCurrentRow($row);

                actualizarTotalCompra();

                toggleFacura();

                focusCurrentRow();

                var producto = getProductFromRow($currentRow);

                triggerProductoCargado(producto);

            }).always(function () {
                maxikioscoSpinner.stopSpin();
            });
        },

        triggerEditarCompraProducto = function (args) {
            $(document).trigger('maxikiosco.editar-compra-producto', [args]);
        },

        ingresarCantidad = function () {

            if ($currentRow.length === 0) {
                return;
            }

            var producto = getProductFromRow($currentRow);
            var args = {
                producto: producto,
                editarCantidad: true,
                proveedor: currentFactura.proveedor.nombre
            }

            triggerEditarCompraProducto(args);
        },

        getStockFromRow = function (row) {
            var stock = Globalize.parseFloat(row.find('input[name$=".StockAnterior"]').val());
            stock = !isNaN(stock) ? stock : 0;
            return stock;
        },

        setStockInRow = function (stock, row) {
            row.find('td.stock-actual').text(formatHelper.formarDecimal(stock));
        },

        actualizarStockFilaActual = function (cantidad) {
            var stockAnterior = getStockFromRow($currentRow);
            var stockActual = stockAnterior + cantidad;
            setStockInRow(stockActual, $currentRow);
        },

        actualizarCantidadFilaActual = function (cantidad) {
            $currentRow.find('input[name$=".Cantidad"]')
                     .val(formatHelper.formarDecimal(cantidad))
                     .closest('td')
                     .find('.cell-text-content')
                     .empty()
                     .text(formatHelper.formarDecimal(cantidad));

            actualizarStockFilaActual(cantidad);
        },

        actualizarCostosFilaActual = function (producto) {

            $currentRow.find('input[name$=".CostoActualizado"]')
                  .val(formatHelper.formarDecimal(producto.costoConIva))
                  .closest('td')
                  .find('.cell-text-content')
                  .empty()
                  .text(formatHelper.formarMoney(producto.costoConIva));

            $currentRow.find('input[name$=".CostoSinIVA"]')
                .val(formatHelper.formarDecimal(producto.costoSinIva))
                .closest('td')
                .find('.cell-text-content')
                .empty()
                .text(formatHelper.formarMoney(producto.costoSinIva));
        },

        actualizarPreciosFilaActual = function (producto) {
            $currentRow.find('input[name$=".PrecioActualizado"]')
                  .val(formatHelper.formarDecimal(producto.precioConIva))
                  .closest('td')
                  .find('.cell-text-content')
                  .empty()
                  .text(formatHelper.formarMoney(producto.precioConIva));
        },

        actualizarTotalesFilaActual = function (producto) {

            $currentRow.find('input[name$=".TotalSinIVA"]')
                 .val(formatHelper.formarDecimal(producto.totalSinIva))
                 .closest('td')
                 .find('.cell-text-content')
                 .empty()
                 .text(formatHelper.formarMoney(producto.totalSinIva));

            $currentRow.find('input[name$=".TotalConIVA"]')
                  .val(formatHelper.formarDecimal(producto.totalConIva))
                  .closest('td')
                  .find('.cell-text-content')
                  .empty()
                  .text(formatHelper.formarMoney(producto.totalConIva));
        },

        actualizarPorcenjaGananciaFilaActual = function (ganancia) {
            $currentRow.find('span.ganancia').text(formatHelper.formatPercentage(ganancia));
        },

        editarCompraProductoCancelado = function () {
            eliminarCompraProducto($currentRow);
        },

        compraProductoEditado = function (e, producto) {
            if (producto.cantidad) {
                actualizarCantidadFilaActual(producto.cantidad);
            }

            actualizarCostosFilaActual(producto);
            actualizarTotalesFilaActual(producto);
            actualizarPreciosFilaActual(producto);
            actualizarPorcenjaGananciaFilaActual(producto.ganancia);

            actualizarTotalCompra();
        },

        ingresarCostoPrecio = function () {

            if ($currentRow.length == 0) {
                return;
            }

            var producto = getProductFromRow($currentRow);
            var args = {
                producto: producto,
                editarCantidad: false
            }

            triggerEditarCompraProducto(args);
        },

        eliminarCompraProducto = function (tr) {

            var $filaSeleccionar = $(tr).prev('tr');

            if ($filaSeleccionar.length == 0) {
                $filaSeleccionar = $(tr).next('tr');
            }

            $currentRow.removeClass('highlight');
            $currentRow = $filaSeleccionar;
            $currentRow.addClass('highlight');

            $(tr).remove();
            actualizarTotalCompra();
            toggleFacura();
        },

        eliminarCompraProductoActual = function () {
            eliminarCompraProducto($currentRow);
        },

        eliminarCompraProductoClick = function () {
            var $tr = $(this)
                .closest('tr');
            eliminarCompraProducto($tr);
            return false;
        },

        tableComprasClick = function () {
            if (!($(this).find('td:eq(0)').hasClass('total-footer-label'))) {
                $currentRow = $(this);
                $currentRow.closest('tbody').find('tr').removeClass('highlight');
                $currentRow.addClass('highlight');
            }
        },

        tableComprasKeydown = function (e) {
            e.preventDefault();
            //Si no hay row actual seleccionar la primera.
            if ($currentRow.length === 0) {
                $currentRow = $('tr:first', '#TableComprasProductos tbody').addClass('highlight');
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

        tableComprasKeyup = function (e) {
            e.preventDefault();
            //Si no hay row actual seleccionar la ultima.
            if ($currentRow.length === 0) {
                $currentRow = $('tr:last', '#TableComprasProductos tbody').addClass('highlight');
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

        existenProductosCargados = function () {
            var existenProductos = false;
            $tableCompraProductos.find('tbody tr').each(function () {
                existenProductos = true;
                return false;
            });
            return existenProductos;
        },

        facturaChange = function () {

            $(this).valid();

            var facturaId = $(this).val();

            if (String.isNullOrEmpty(facturaId)) {
                //Deshabilitar el boton de agregar
                $('#AgregarProducto', $modal).attr('disabled', 'disabled');
                return;
            }

            //Si la factura es diferente y existe almenos un producto cargado no cambiar.
            if (currentFactura && facturaId != currentFactura.facturaId && existenProductosCargados()) {
                alert("No se puede cambiar la factura existen productos cargados");
                return;
            }

            $('#AgregarProducto', $modal).removeAttrs('disabled');

            var url = String.format('/Facturas/Obtener');
            var data = { facturaId: facturaId };
            maxikioscoSpinner.stopSpin();
            $.ajax({
                type: "POST",
                url: url,
                data: data
            }).done(function (factura) {

                currentFactura = factura;
                $("#ProveedorId", $modal).val(factura.proveedorId);
                $("#ProveedorNombre", $modal).val(factura.proveedor);
                $("#MaxiKioscoId", $modal).val(factura.maxiKioscoId);
                $("#MaxiKioscoNombre", $modal).val(factura.maxikiosco);
                $("#Factura_ImporteTotal", $modal).val(factura.importeTotal);
                $("#Factura_FacturaNro", $modal).val(factura.facturaNro);
                $('#Numero', $modal).val(factura.autoNumero);
                $('#ImporteFactura', $modal).val(factura.importeTotal);
                $('#TipoComprobante', $modal).val(factura.tipoComprobante);

                $('#PercepcionIVAProcentaje', $modal).text(Globalize.format(maxikiosco.cuenta.porcentajePercepcionIVA / 100, 'p2'));
                $('#PercepcionDGRProcentaje', $modal).text(Globalize.format(factura.percepcionDGR / 100, 'p2'));

                actualizarPercepciones();

            }).always(function () {
                maxikioscoSpinner.stopSpin();
            });
        },

        aplicarPercepcionIva = function () {
            return totalCompra() >= maxikiosco.cuenta.aplicarPercepcionIVADesde && currentFactura.aplicaPercepcionIVA;
        },

        totalCompra = function () {
            var total = 0;
            $tableCompraProductos.find('tbody tr').each(function () {
                var $row = $(this);

                var cantidadString = $row.find('input[name$=".Cantidad"]').val();
                var cantidad = Globalize.parseFloat(cantidadString);
                if (isNaN(cantidad)) {
                    cantidad = 0;
                }

                var costoString = $row.find('input[name$=".CostoActualizado"]').val();
                var costo = Globalize.parseFloat(costoString);
                if (isNaN(costo)) {
                    costo = 0;
                }

                total += cantidad * costo;
            });
            return total;
        },

        descuentoCompra = function () {
            var $cellDescuento = $tableCompraProductos.find('.compra-descuento-footer');
            var descuentoString = $cellDescuento.text().trim();
            var descuento = Globalize.parseFloat(descuentoString);

            return descuento;
        },

        percepcionIva = function () {
            if (!currentFactura) {
                return 0;
            }

            var totalConDesc = totalConDescuento();

            if ($('#PercepcionIVAManual').prop('checked') == false) {
                if (totalConDesc <= 0 || !aplicarPercepcionIva()) {
                    return 0;
                }
            }


            if ($('#PercepcionIVAManual').is(':checked')) {
                var precIvaManualString = $('#PercepcionIVA').val();
                var percIvaManual = !String.isNullOrEmpty(precIvaManualString) ? Globalize.parseFloat(precIvaManualString) : 0;
                return percIvaManual;
            }

            return totalConDesc * maxikiosco.cuenta.porcentajePercepcionIVA / 100;
        },

        percepcionDgr = function () {

            if (!currentFactura) {
                return 0;
            }

            var totalConDesc = totalConDescuento();

            if (totalConDesc <= 0) {
                return 0;
            }

            if ($('#PercepcionDGRManual').is(':checked')) {
                var percDgrManualString = $('#PercepcionDGR').val();
                var percDgrManual = !String.isNullOrEmpty(percDgrManualString) ? Globalize.parseFloat(percDgrManualString) : 0;
                return percDgrManual;
            }

            return totalConDesc * currentFactura.percepcionDGR / 100;
        },

        totalConDescuento = function () {
            var descuento = descuentoCompra();
            return totalCompra() - descuento;
        },

        totalGeneral = function () {
            var descuento = descuentoCompra();
            var percDgr = percepcionDgr();
            var percIva = percepcionIva();
            return totalCompra() - descuento + percDgr + percIva;
        },

        actualizarTotalCompra = function () {
            var totCompra = totalCompra();
            $('#TotalCompra').val(totCompra.toString().replace('.', ','));
            $tableCompraProductos.find('.total-compra-footer').text(Globalize.format(totCompra, 'c2'));
            actualizarDescuento();
            $tableCompraProductos.find('.total-compra-condescuento-footer').text(Globalize.format(totalConDescuento(), 'c2'));
            actualizarPercepciones();
            var totGeneral = totalGeneral();
            $('#ImporteFinal').val(totGeneral.toString().replace('.', ','));
            $tableCompraProductos.find('.total-compra-total-general-footer').text(Globalize.format(totGeneral, 'c2'));
        },

        actualizarDescuento = function () {

            var tipoDescuento = $('input[name="TipoDescuento"]:checked').val();

            var descuento = 0;
            var descuentoString = '';

            //Calculamos el descuento dependiendo del tipo.
            if (tipoDescuento == "DescuentoEnPesos") {
                descuentoString = $('#Factura_DescuentoEnPesos').val();
                descuento = descuentoString ? Globalize.parseFloat(descuentoString) : 0;
            } else {
                descuentoString = $('#Factura_DescuentoPorcentaje').val();
                var descuentoPorcentaje = descuentoString ? Globalize.parseFloat(descuentoString) : 0;
                descuento = descuentoPorcentaje / 100 * totalCompra();
            }

            //El descuento se guarda en forma negativa.
            var descuentoFinalFormateado = '-' + Globalize.format(descuento, 'n2');

            //Guardar el valor en el hidden para el post.
            $('#Descuento').val(descuentoFinalFormateado);

            //Actualizar el footer.
            var $cellDescuento = $tableCompraProductos.find('.compra-descuento-footer');
            $cellDescuento.text(Globalize.format(descuento, 'c2'));
        },

        actualizarPercepciones = function () {
            actualizarPercepcionIva();
            actualizarPercepcionDgr();
        },

        actualizarPercepcionIva = function () {
            $('#PercepcionIVA').val(Globalize.format(percepcionIva(), 'n2'));
        },

        actualizarPercepcionDgr = function () {
            $('#PercepcionDGR').val(Globalize.format(percepcionDgr(), 'n2'));
        },

        toggleFacura = function () {
            var $factura = $("#FacturaId");

            if (!existenProductosCargados()) {
                $factura.select2("readonly", false);
            } else {
                $factura.select2("readonly", true);
            }
        },

        toggleRadioTipoDescuento = function () {

            var tipoDescuento = $('input[name="TipoDescuento"]:checked').val();
            var $form = $('#FrmCrearCompra', $modal);
            if ($form.length > 0) {
                if (tipoDescuento == "DescuentoEnPesos") {
                    //$.validator.unobtrusive.parseElement("#Factura_DescuentoPorcentaje");
                    $('#Factura_DescuentoPorcentaje')
                        .attr('disabled', 'disabled')
                        .removeClass('input-validation-error');
                    $('span[data-valmsg-for="Factura.DescuentoPorcentaje"]').empty();
                    $('#Factura_DescuentoEnPesos').removeAttr('disabled');

                } else {

                    $('#Factura_DescuentoEnPesos')
                        .attr('disabled', 'disabled')
                        .removeClass('input-validation-error');

                    $('span[data-valmsg-for="Factura.DescuentoEnPesos"]').empty();
                    $('#Factura_DescuentoPorcentaje').removeAttr('disabled');
                }
            }

            actualizarDescuento();
        },

        scrollToCurrentRow = function () {
            if (!inViewport($currentRow)) {

                $modal.animate({
                    scrollTop: $currentRow.position().top - ($modal.height() / 2)
                }, 0);
            }
        },

        inViewport = function (el) {

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