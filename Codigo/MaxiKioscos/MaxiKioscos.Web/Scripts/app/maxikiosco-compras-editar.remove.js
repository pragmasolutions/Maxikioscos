(function () {
    var $modal = $('#ComprasModal'),
        $ingresarCantidadModal = $('#IngresarCantidadModal'),
        $ingresarCostoPrecioModal = $('#IngresarCostoPrecioModal'),
        $agregarProductoModal = $('#SeleccionarProductoModal'),
        $currentRow = $('#TableComprasProductos tbody tr:first'),
        $tableCompraProductos = $('#TableComprasProductos'),
        $tableCompraProductosBody = $("#TableComprasProductos tbody"),
        currentFactura = null,

        init = function () {

            $modal.on('submit', 'form#FrmCrearCompra', submit);

            configureBtnCancel();

            //highlight current row
            $('#TableComprasProductos').on('click', 'tr', tableComprasClick);

            //Cargar un nuevo compra producto cuando se selecciona un producto del modal
            $("#SeleccionarProductoModal").on('maxikiosco.productoselected', productoSeleccionado);
            $("#FacturaId").change(facturaChange);
            $('#TableComprasProductos').on('click', '.btn-compra-producto-eliminar', eliminarCompraProductoClick);
            $('input[name="TipoDescuento"]').click(toggleRadioTipoDescuento);

            toggleRadioTipoDescuento();

            $("#Factura_DescuentoPorcentaje").blur(descuentoBlur);
            $("#Factura_DescuentoEnPesos").blur(descuentoBlur);

            //Eventos botones inferiores.
            $(".btn-asterisco").click(ingresarCantidad);
            $(".btn-barra").click(ingresarCostoPrecio);
            $(".btn-mas").click(agregarProducto);
            $(".btn-suprimir").click(eliminarCompraProductoActual);

            //Eventos de acceso directo.
            $(document).on('keydown', null, '*', ingresarCantidad);
            $(document).on('keydown', null, '/', ingresarCostoPrecio);
            $(document).on('keydown', null, 'del', eliminarCompraProductoActual);
            $(document).on('keydown', null, 'Down', tableComprasKeydown);
            $(document).on('keydown', null, 'Up', tableComprasKeyup);
            $(document).on('keydown', null, '+', agregarProducto);

            $modal.on('hidden.bs.modal', function () {
                //Unsuscribe from key events
                $(document).off('keydown', ingresarCantidad);
                $(document).off('keydown', ingresarCostoPrecio);
                $(document).off('keydown', eliminarCompraProducto);
                $(document).off('keydown', tableComprasKeydown);
                $(document).off('keydown', tableComprasKeyup);
                $(document).off('keydown', agregarProducto);
            });

            //Focus first input in modals.
            $ingresarCantidadModal.on('shown.bs.modal', function () {
                controles.parse('#IngresarCantidadModal');
                validacion.parse('#IngresarCantidadModal');
                $('#CantidadIngresada', this).select()[0].focus();
            });

            $ingresarCostoPrecioModal.on('shown.bs.modal', function () {
                controles.parse('#IngresarCostoPrecioModal');
                validacion.parse('#IngresarCostoPrecioModal');
                $('#CostoSinIVA', this).select()[0].focus();
            });

            //Cantidad precio y costo modificaciones submits.
            $ingresarCantidadModal.find('#FrmIngresarCantidad').submit(ingresarCantidadSubmit);

            $ingresarCostoPrecioModal.find('#FrmIngresarCostoPrecio').submit(ingresarCostoPrecioSubmit);

            //Actualizar precio cuando cambia margen de ganancia.
            $ingresarCostoPrecioModal.on('change', '#PorcentajeGanancia', function () {

                var porcentajeGananciaString = $(this).val();

                var costoString = $('#CostoConIVA', $ingresarCostoPrecioModal).val();

                if (String.isNullOrEmpty(porcentajeGananciaString) || String.isNullOrEmpty(costoString)) return;

                var costo = Globalize.parseFloat(costoString);

                if (costo == 0) return;

                var porcentajeGanancia = Globalize.parseFloat(porcentajeGananciaString);

                var nuevoPrecio = (costo * (porcentajeGanancia / 100)) + costo;

                var $precioInput = $('#PrecioConIVA', $ingresarCostoPrecioModal);

                $precioInput.val(Globalize.format(nuevoPrecio, 'n2'));

                var triggerDesdePorcentajeGanancia = true;

                $precioInput.trigger('change', [triggerDesdePorcentajeGanancia]);
            });

            //Actualizar porcentaje de ganania cuando cambia costo.
            $ingresarCostoPrecioModal.on('change', '#CostoSinIVA', function () {

                var costoSinIvaString = $(this).val();

                if (String.isNullOrEmpty(costoSinIvaString)) return;

                var costoSinIva = Globalize.parseFloat(costoSinIvaString);

                var costoConIva = costoSinIva * 1.21;

                $('#CostoConIVA', $ingresarCostoPrecioModal).val(Globalize.format(Globalize.format(costoConIva, 'n2')));

                var precioSinIvaString = $('#PrecioSinIVA', $ingresarCostoPrecioModal).val();

                if (String.isNullOrEmpty(precioSinIvaString)) return;

                var precioSinIva = Globalize.parseFloat(precioSinIvaString);

                var $porcentajeGananciaInput = $('#PorcentajeGanancia', $ingresarCostoPrecioModal);

                if (costoSinIva == 0) {
                    $porcentajeGananciaInput.val('');
                    return;
                }

                var porcentajeGanancia = ((precioSinIva - costoSinIva) / costoSinIva) * 100;
                $porcentajeGananciaInput.val(Globalize.format(porcentajeGanancia, 'n2'));
            });

            $ingresarCostoPrecioModal.on('change', '#CostoConIVA', function () {
                var costoConIvaString = $(this).val();

                if (String.isNullOrEmpty(costoConIvaString)) return;

                var costoConIva = Globalize.parseFloat(costoConIvaString);

                var costoSinIva = costoConIva / 1.21;

                $('#CostoSinIVA', $ingresarCostoPrecioModal).val(Globalize.format(Globalize.format(costoSinIva, 'n2')));

                var precioConIvaString = $('#PrecioConIVA', $ingresarCostoPrecioModal).val();

                if (String.isNullOrEmpty(precioConIvaString)) return;

                var precioConIva = Globalize.parseFloat(precioConIvaString);

                var $porcentajeGananciaInput = $('#PorcentajeGanancia', $ingresarCostoPrecioModal);

                if (costoConIva == 0) {
                    $porcentajeGananciaInput.val('');
                    return;
                }

                var porcentajeGanancia = ((precioConIva - costoConIva) / costoConIva) * 100;
                $porcentajeGananciaInput.val(Globalize.format(porcentajeGanancia, 'n2'));
            });

            //Actualizar el margen de ganancia cuando cambia el precio.
            $ingresarCostoPrecioModal.on('change', '#PrecioSinIVA', function (e, triggerDesdePorcentajeGanancia) {

                var precioSinIvaString = $(this).val();

                if (String.isNullOrEmpty(precioSinIvaString)) return;

                var precioSinIva = Globalize.parseFloat(precioSinIvaString);

                var precioConIva = precioSinIva * 1.21;

                $('#PrecioConIVA', $ingresarCostoPrecioModal).val(Globalize.format(Globalize.format(precioConIva, 'n2')));

                //No actualizo el porcentaje de ganancia si vengo desde porcentaje de ganancia
                if (triggerDesdePorcentajeGanancia) return;

                var costoSinIvaString = $('#CostoSinIVA', $ingresarCostoPrecioModal).val();

                //Solo actualizo porcentaje de ganancia si tengo costo cargado.
                if (String.isNullOrEmpty(costoSinIvaString)) return;

                var costoSinIva = Globalize.parseFloat(costoSinIvaString);

                var $porcentajeGananciaInput = $('#PorcentajeGanancia', $ingresarCostoPrecioModal);

                if (costoSinIva == 0) {
                    $porcentajeGananciaInput.val('');
                    return;
                }

                var porcentajeGanancia = ((precioSinIva - costoSinIva) / costoSinIva) * 100;
                $porcentajeGananciaInput.val(Globalize.format(porcentajeGanancia, 'n2'));
            });

            $ingresarCostoPrecioModal.on('change', '#PrecioConIVA', function (e, triggerDesdePorcentajeGanancia) {

                var precioConIvaString = $(this).val();

                if (String.isNullOrEmpty(precioConIvaString)) return;

                var precioConIva = Globalize.parseFloat(precioConIvaString);

                var precioSinIva = precioConIva / 1.21;

                $('#PrecioSinIVA', $ingresarCostoPrecioModal).val(Globalize.format(Globalize.format(precioSinIva, 'n2')));

                //No actualizo el porcentaje de ganancia si vengo desde porcentaje de ganancia
                if (triggerDesdePorcentajeGanancia) return;

                var costoConIvaString = $('#CostoConIVA', $ingresarCostoPrecioModal).val();

                //Solo actualizo porcentaje de ganancia si tengo costo cargado.
                if (String.isNullOrEmpty(costoConIvaString)) return;

                var costoConIva = Globalize.parseFloat(costoConIvaString);

                var $porcentajeGananciaInput = $('#PorcentajeGanancia', $ingresarCostoPrecioModal);

                if (costoConIva == 0) {
                    $porcentajeGananciaInput.val('');
                    return;
                }

                var porcentajeGanancia = ((precioConIva - costoConIva) / costoConIva) * 100;
                $porcentajeGananciaInput.val(Globalize.format(porcentajeGanancia, 'n2'));
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
        },
        
        descuentoBlur = function () {
            actualizarDescuento();
            actualizarTotalCompra();
        },

        configureBtnCancel = function () {
            $("#BtnCancelar", $modal).confirm({
                text: "¿Esta seguro que desea cancelar la compra?",
                title: "Cacelar Compra",
                confirm: function () {
                    $modal.modal('hide');
                },
                confirmButton: "Aceptar",
                cancelButton: "Cancelar"
            });
        },

        submit = function (e) {

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
                        $(document).trigger('maxikiosco.comprasaved');
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

                $currentRow.removeClass('highlight');
                $currentRow = $row;
                $currentRow.addClass('highlight');

                //Verificar que el producto tenga costo.
                var costo = $row.find('input[name$=".CostoActualizado"]').val();
                if (String.isNullOrEmpty(costo)) {
                    cargarCostoInicial();
                }

                actualizarTotalCompra();

                toggleFacura();

                $modal.animate({
                    scrollTop: $currentRow.position().top
                }, 1000);

            }).always(function () {
                maxikioscoSpinner.stopSpin();
            });
        },

        cargarCostoInicial = function () {

            clearIngresarCostoPrecio();

            $('#PorcentajeGanancia', $ingresarCostoPrecioModal).val('');

            cargarPrecioEnModal();

            //Si el popup se cierra y la cantidad ingresa es 0 o menor eliminar la fila del producto.
            $ingresarCostoPrecioModal.modal()
                .on('hidden.bs.modal', function () {

                    //Verificar que se hay ingresado un costo.
                    eliminarCompraProducto($currentRow);
                    //Unsuscribe
                    $ingresarCostoPrecioModal.off('hidden.bs.modal');
                });
        },

        clearIngresarCostoPrecio = function () {
            var $inputCostoSinIVA = $ingresarCostoPrecioModal.find('input#CostoSinIVA');
            var $inputCostoConIVA = $ingresarCostoPrecioModal.find('input#CostoConIVA');
            var $inputPrecioSinIVA = $ingresarCostoPrecioModal.find('input#PrecioSinIVA');
            var $inputPrecioConIVA = $ingresarCostoPrecioModal.find('input#PrecioConIVA');
            $inputCostoSinIVA.val('');
            $inputCostoConIVA.val('');
            $inputPrecioSinIVA.val('');
            $inputPrecioConIVA.val('');
        },

        ingresarCantidad = function () {

            //Obtener cantidad actual
            if ($currentRow.length === 0) {
                return;
            }

            var cantidad = $currentRow.find('input[name$=".Cantidad"]').val();
            cantidad = cantidad == 0 ? '' : cantidad;
            var $inputCantidad = $ingresarCantidadModal.find('input#CantidadIngresada');
            $inputCantidad.val('');
            $ingresarCantidadModal.modal();
        },

        ingresarCantidadSubmit = function () {

            if (!$(this).valid()) {
                return false;
            }

            var cantidad = Globalize.parseFloat($('#CantidadIngresada', this).val());
            cantidad = !isNaN(cantidad) ? cantidad : 0;

            $currentRow.find('input[name$=".Cantidad"]')
                .val(Globalize.format(cantidad, 'n2'))
                .closest('td')
                .find('.cell-text-content')
                .empty()
                .text(Globalize.format(cantidad, 'n2'));

            //Actualizar stock
            var stockAnterior = Globalize.parseFloat($currentRow.find('input[name$=".StockAnterior"]').val());
            stockAnterior = !isNaN(stockAnterior) ? stockAnterior : 0;
            var stockActual = stockAnterior + cantidad;
            $currentRow.find('td.stock-actual').text(Globalize.format(stockActual, 'n2'));

            $ingresarCantidadModal.modal('hide');

            actualizarTotalCompra();

            return false;
        },

        ingresarCostoPrecio = function () {

            //Obtener cantidad actual
            if ($currentRow.length == 0) {
                return;
            }

            cargarCostoEnModel();
            cargarPrecioEnModal();
            $ingresarCostoPrecioModal.modal();
        },

        cargarCostoEnModel = function () {
            if ($currentRow.length == 0) {
                return;
            }
            var costo = $currentRow.find('input[name$=".CostoActualizado"]').val();
            var $inputCostoConIVA = $ingresarCostoPrecioModal.find('input#CostoConIVA');
            $inputCostoConIVA.val(costo).trigger('change');
        },

        cargarPrecioEnModal = function () {
            if ($currentRow.length == 0) {
                return;
            }
            var precio = $currentRow.find('input[name$=".PrecioActualizado"]').val();
            var $inputPrecioConIVA = $ingresarCostoPrecioModal.find('input#PrecioConIVA');
            $inputPrecioConIVA.val(precio).trigger('change');
        },

        ingresarCostoPrecioSubmit = function (e) {

            if (!$(this).valid()) {
                return false;
            }

            $(document.activeElement).trigger('change');

            var costoIngresado = $('#CostoConIVA', this).val();
            var costoIngresadoSinIVA = $('#CostoSinIVA', this).val();
            var precioIngresado = $('#PrecioConIVA', this).val();

            var costoParseado = Globalize.parseFloat(costoIngresado);
            costoParseado = !isNaN(costoParseado) ? costoParseado : 0;
            var costoFormateado = Globalize.format(costoParseado, 'C2');

            var costoSinIVAParseado = Globalize.parseFloat(costoIngresadoSinIVA);
            costoSinIVAParseado = !isNaN(costoSinIVAParseado) ? costoSinIVAParseado : 0;
            var costoSinIVAFormateado = Globalize.format(costoSinIVAParseado, 'C2');

            var precioParseado = Globalize.parseFloat(precioIngresado);
            precioParseado = !isNaN(precioParseado) ? precioParseado : 0;
            var precioFormateado = Globalize.format(precioParseado, 'C2');
            var ganancia = ((precioParseado - costoParseado) / costoParseado) * 100;

            $currentRow.find('input[name$=".CostoActualizado"]')
                .val(costoIngresado)
                .closest('td')
                .find('.cell-text-content')
                .empty()
                .text(costoFormateado);

            $currentRow.find('input[name$=".CostoSinIVA"]')
                .val(costoIngresadoSinIVA)
                .closest('td')
                .find('.cell-text-content')
                .empty()
                .text(costoSinIVAFormateado);

            $currentRow.find('input[name$=".PrecioActualizado"]')
                .val(precioIngresado)
                .closest('td')
                .find('.cell-text-content')
                .empty()
                .text(precioFormateado);


            $currentRow.find('span.ganancia').text(formatMoney(ganancia) + '%');

            $ingresarCostoPrecioModal.off('hidden.bs.modal');
            $ingresarCostoPrecioModal.modal('hide');

            actualizarTotalCompra();

            return false;
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
                //Actualizar modal title.
                $ingresarCostoPrecioModal.find('.nombre-proveedor').text(factura.proveedor);

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

        existenProductosCargados = function () {
            var existenProductos = false;
            $tableCompraProductos.find('tbody tr').each(function () {
                existenProductos = true;
                return false;
            });
            return existenProductos;
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

        formatMoney = function (number) {
            var n = number,
                c = 2,
                d = ",",
                t = "",
                s = n < 0 ? "-" : "",
                i = parseInt(n = Math.abs(+n || 0).toFixed(c)) + "",
                j = (j = i.length) > 3 ? j % 3 : 0;
            return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
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