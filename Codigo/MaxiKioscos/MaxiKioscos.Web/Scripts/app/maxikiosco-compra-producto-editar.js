(function () {
    var $editarCompraProductoModal = $('#EditarCompraProductoModal'),
        $ingresarCantidadContainer = $('#IngresarCantidadContainer', $editarCompraProductoModal),
        init = function () {

            configurarControlFocus();

            $editarCompraProductoModal.find('#FrmEditarCompraProducto').submit(editarCompraProductoSubmit);

            //Actualizar precio cuando cambia margen de ganancia.
            $editarCompraProductoModal.on('change', '#PorcentajeGanancia', function () {

                var porcentajeGananciaString = $(this).val();

                var costoString = $('#CostoConIVA', $editarCompraProductoModal).val();

                if (String.isNullOrEmpty(porcentajeGananciaString) || String.isNullOrEmpty(costoString)) return;

                var costo = Globalize.parseFloat(costoString);

                if (costo == 0) return;

                var porcentajeGanancia = Globalize.parseFloat(porcentajeGananciaString);

                var nuevoPrecio = (costo * (porcentajeGanancia / 100)) + costo;

                var $precioInput = $('#PrecioConIVA', $editarCompraProductoModal);

                $precioInput.val(Globalize.format(nuevoPrecio, 'n2'));

                var triggerDesdePorcentajeGanancia = true;

                $precioInput.trigger('change', [triggerDesdePorcentajeGanancia]);
            });

            //Actualizar porcentaje de ganania cuando cambia costo.
            $editarCompraProductoModal.on('change', '#CostoSinIVA', function (e, triggerDesdeTotal) {

                var costoSinIvaString = $(this).val();

                if (String.isNullOrEmpty(costoSinIvaString)) return;

                var costoSinIva = Globalize.parseFloat(costoSinIvaString);

                var costoConIva = costoSinIva * 1.21;

                $('#CostoConIVA', $editarCompraProductoModal).val(Globalize.format(Globalize.format(costoConIva, 'n2')));

                var precioSinIvaString = $('#PrecioSinIVA', $editarCompraProductoModal).val();

                if (String.isNullOrEmpty(precioSinIvaString)) return;

                var precioSinIva = Globalize.parseFloat(precioSinIvaString);

                var $porcentajeGananciaInput = $('#PorcentajeGanancia', $editarCompraProductoModal);

                if (costoSinIva == 0) {
                    $porcentajeGananciaInput.val('');
                    return;
                }

                var porcentajeGanancia = ((precioSinIva - costoSinIva) / costoSinIva) * 100;
                $porcentajeGananciaInput.val(Globalize.format(porcentajeGanancia, 'n2'));

                if (triggerDesdeTotal) return;

                var cantidadString = $('#CantidadIngresada', $editarCompraProductoModal).val();

                if (String.isNullOrEmpty(cantidadString)) return;

                var cantidad = Globalize.parseFloat(cantidadString);

                var totalSinIva = cantidad * costoSinIva;

                $('#TotalSinIVA', $editarCompraProductoModal).val(formatHelper.formarDecimal(totalSinIva)).trigger('change');
            });
            $editarCompraProductoModal.on('change', '#CostoConIVA', function (e, triggerDesdeTotal) {
                var costoConIvaString = $(this).val();

                if (String.isNullOrEmpty(costoConIvaString)) return;

                var costoConIva = Globalize.parseFloat(costoConIvaString);

                var costoSinIva = costoConIva / 1.21;

                $('#CostoSinIVA', $editarCompraProductoModal).val(Globalize.format(Globalize.format(costoSinIva, 'n2')));

                var precioConIvaString = $('#PrecioConIVA', $editarCompraProductoModal).val();

                if (String.isNullOrEmpty(precioConIvaString)) return;

                var precioConIva = Globalize.parseFloat(precioConIvaString);

                var $porcentajeGananciaInput = $('#PorcentajeGanancia', $editarCompraProductoModal);

                if (costoConIva == 0) {
                    $porcentajeGananciaInput.val('');
                    return;
                }

                var porcentajeGanancia = ((precioConIva - costoConIva) / costoConIva) * 100;
                $porcentajeGananciaInput.val(Globalize.format(porcentajeGanancia, 'n2'));

                if (triggerDesdeTotal) return;

                var cantidadString = $('#CantidadIngresada', $editarCompraProductoModal).val();

                if (String.isNullOrEmpty(cantidadString)) return;

                var cantidad = Globalize.parseFloat(cantidadString);

                var totalConIva = cantidad * costoConIva;

                $('#TotalConIVA', $editarCompraProductoModal).val(formatHelper.formarDecimal(totalConIva)).trigger('change');
            });

            //Actualizar el margen de ganancia cuando cambia el precio.
            $editarCompraProductoModal.on('change', '#PrecioSinIVA', function (e, triggerDesdePorcentajeGanancia) {

                var precioSinIvaString = $(this).val();

                if (String.isNullOrEmpty(precioSinIvaString)) return;

                var precioSinIva = Globalize.parseFloat(precioSinIvaString);

                var precioConIva = precioSinIva * 1.21;

                $('#PrecioConIVA', $editarCompraProductoModal).val(Globalize.format(Globalize.format(precioConIva, 'n2')));

                //No actualizo el porcentaje de ganancia si vengo desde porcentaje de ganancia
                if (triggerDesdePorcentajeGanancia) return;

                var costoSinIvaString = $('#CostoSinIVA', $editarCompraProductoModal).val();

                //Solo actualizo porcentaje de ganancia si tengo costo cargado.
                if (String.isNullOrEmpty(costoSinIvaString)) return;

                var costoSinIva = Globalize.parseFloat(costoSinIvaString);

                var $porcentajeGananciaInput = $('#PorcentajeGanancia', $editarCompraProductoModal);

                if (costoSinIva == 0) {
                    $porcentajeGananciaInput.val('');
                    return;
                }

                var porcentajeGanancia = ((precioSinIva - costoSinIva) / costoSinIva) * 100;
                $porcentajeGananciaInput.val(Globalize.format(porcentajeGanancia, 'n2'));
            });
            $editarCompraProductoModal.on('change', '#PrecioConIVA', function (e, triggerDesdePorcentajeGanancia) {

                var precioConIvaString = $(this).val();

                if (String.isNullOrEmpty(precioConIvaString)) return;

                var precioConIva = Globalize.parseFloat(precioConIvaString);

                var precioSinIva = precioConIva / 1.21;

                $('#PrecioSinIVA', $editarCompraProductoModal).val(Globalize.format(Globalize.format(precioSinIva, 'n2')));

                //No actualizo el porcentaje de ganancia si vengo desde porcentaje de ganancia
                if (triggerDesdePorcentajeGanancia) return;

                var costoConIvaString = $('#CostoConIVA', $editarCompraProductoModal).val();

                //Solo actualizo porcentaje de ganancia si tengo costo cargado.
                if (String.isNullOrEmpty(costoConIvaString)) return;

                var costoConIva = Globalize.parseFloat(costoConIvaString);

                var $porcentajeGananciaInput = $('#PorcentajeGanancia', $editarCompraProductoModal);

                if (costoConIva == 0) {
                    $porcentajeGananciaInput.val('');
                    return;
                }

                var porcentajeGanancia = ((precioConIva - costoConIva) / costoConIva) * 100;
                $porcentajeGananciaInput.val(Globalize.format(porcentajeGanancia, 'n2'));
            });

            //Actualizar cantidad cuando cambian los totales.
            $editarCompraProductoModal.on('change', '#TotalSinIVA', function (e, triggerDesdeCantidad) {

                var totalSinIvaString = $(this).val();

                if (String.isNullOrEmpty(totalSinIvaString)) return;

                var totalSinIva = Globalize.parseFloat(totalSinIvaString);

                var totalConIva = totalSinIva * 1.21;

                $('#TotalConIVA', $editarCompraProductoModal).val(formatHelper.formarDecimal(totalConIva));

                if (triggerDesdeCantidad) return;

                var cantidadString = $('#CantidadIngresada', $editarCompraProductoModal).val();

                if (String.isNullOrEmpty(cantidadString)) return;

                var cantidad = Globalize.parseFloat(cantidadString);

                var costoSinIva = totalSinIva / cantidad;

                var triggerDesdeTotal = true;

                $('#CostoSinIVA', $editarCompraProductoModal).val(formatHelper.formarDecimal(costoSinIva)).trigger('change', [triggerDesdeTotal]);
            });
            $editarCompraProductoModal.on('change', '#TotalConIVA', function () {
                var totalConIvaString = $(this).val();

                if (String.isNullOrEmpty(totalConIvaString)) return;

                var totalConIva = Globalize.parseFloat(totalConIvaString);

                var totalSinIva = totalConIva / 1.21;

                $('#TotalSinIVA', $editarCompraProductoModal).val(formatHelper.formarDecimal(totalSinIva));

                var cantidadString = $('#CantidadIngresada', $editarCompraProductoModal).val();

                if (String.isNullOrEmpty(cantidadString)) return;

                var cantidad = Globalize.parseFloat(cantidadString);

                var costoConIva = totalConIva / cantidad;

                var triggerDesdeTotal = true;

                $('#CostoConIVA', $editarCompraProductoModal).val(formatHelper.formarDecimal(costoConIva)).trigger('change', [triggerDesdeTotal]);
            });

            //Actualizar el total caundo cambia la cantidad.
            $editarCompraProductoModal.on('change', '#CantidadIngresada', function () {

                var cantidadString = $('#CantidadIngresada', $editarCompraProductoModal).val();

                if (String.isNullOrEmpty(cantidadString)) return;

                var cantidad = Globalize.parseFloat(cantidadString);

                var costoSinIvaString = $('#CostoSinIVA', $editarCompraProductoModal).val();

                if (String.isNullOrEmpty(costoSinIvaString)) return;

                var costoSinIva = Globalize.parseFloat(costoSinIvaString);

                var totalSinIva = cantidad * costoSinIva;

                var triggerDesdeCantidad = true;

                $('#TotalSinIVA', $editarCompraProductoModal).val(formatHelper.formarDecimal(totalSinIva)).trigger('change', [triggerDesdeCantidad]);
            });

            $(document).off('maxikiosco.producto-cargado');
            $(document).on('maxikiosco.producto-cargado', productoCargado);
            
            $(document).off('maxikiosco.editar-compra-producto');
            $(document).on('maxikiosco.editar-compra-producto', editarCompraProducto);
        },

        configurarControlFocus = function () {
            //Focus en primer elemento cuando se abre el modal
            $editarCompraProductoModal.on('shown.bs.modal', function () {
                controles.parse('#EditarCompraProductoModal');
                validacion.parse('#EditarCompraProductoModal');

                if (isCantidadVisible()) {
                    $('#CantidadIngresada', this).select()[0].focus();
                } else {
                    $('#CostoSinIVA', this).select()[0].focus();
                }
            });
        },

        limpiarFormulario = function () {
            $editarCompraProductoModal.find('input#CostoSinIVA').val('');
            $editarCompraProductoModal.find('input#CostoConIVA').val('');
            $editarCompraProductoModal.find('input#PrecioSinIVA').val('');
            $editarCompraProductoModal.find('input#PrecioConIVA').val('');
        },

        cargarCostoYPrecio = function (producto) {
            $('#CostoConIVA', $editarCompraProductoModal)
                .val(formatHelper.formarDecimal(producto.costo))
                .trigger('change');
            $('#PrecioConIVA', $editarCompraProductoModal)
                .val(formatHelper.formarDecimal(producto.precio))
                .trigger('change');
        },

        cargarCantidadYTotales = function (producto) {
            $('#CantidadIngresada', $editarCompraProductoModal)
                .val(formatHelper.formarDecimal(producto.cantidad))
                .trigger('change');

            $('#TotalConIVA', $editarCompraProductoModal)
                .val(formatHelper.formarDecimal(producto.totalConIva));

            $('#TotalSinIVA', $editarCompraProductoModal)
                .val(formatHelper.formarDecimal(producto.totalSinIva));
        },

        cargarNombreDeProductoProveedor = function (producto) {
            $('.nombre-producto', $editarCompraProductoModal)
                .text(producto.nombre);

            $('.nombre-proveedor', $editarCompraProductoModal)
                .text(producto.proveedor);
        },

        triggerEditarProductoCacelado = function (producto) {
            $(document).trigger('maxikiosco.editar-compra-producto-cancelado', [producto]);
        },

        cargarCostoInicial = function (producto) {

            limpiarFormulario();

            cargarCantidadYTotales(producto);

            cargarCostoYPrecio(producto);

            cargarNombreDeProductoProveedor(producto);

            $ingresarCantidadContainer.show();

            $editarCompraProductoModal.modal().on('hidden.bs.modal', function () {
                triggerEditarProductoCacelado(producto);
                $editarCompraProductoModal.off('hidden.bs.modal');
            });
        },

        productoCargado = function (e, producto) {
            if (!producto.costo) {
                cargarCostoInicial(producto);
            }
        },

        editarCompraProducto = function (e, args) {
            cargarCantidadYTotales(args.producto);

            if (args.editarCantidad) {
                $ingresarCantidadContainer.show();
            } else {
                $ingresarCantidadContainer.hide();
            }

            cargarNombreDeProductoProveedor(args.producto);

            cargarCostoYPrecio(args.producto);

            $editarCompraProductoModal.modal();
        },

        costoIngresadoConIva = function () {
            var costoIngresadoConIva = $('#CostoConIVA', $editarCompraProductoModal).val();
            var costoConIva = Globalize.parseFloat(costoIngresadoConIva);
            costoConIva = !isNaN(costoConIva) ? costoConIva : 0;
            return costoConIva;
        },

        costoIngresadoSinIva = function () {
            var costoIngresadoSinIva = $('#CostoSinIVA', $editarCompraProductoModal).val();
            var costoSinIva = Globalize.parseFloat(costoIngresadoSinIva);
            costoSinIva = !isNaN(costoSinIva) ? costoSinIva : 0;
            return costoSinIva;
        },

        precioIngresadoConIva = function () {
            var precioIngresadoConIva = $('#PrecioConIVA', $editarCompraProductoModal).val();
            var precioConIva = Globalize.parseFloat(precioIngresadoConIva);
            precioConIva = !isNaN(precioConIva) ? precioConIva : 0;
            return precioConIva;
        },

        precioIngresadoSinIva = function () {
            var precioIngresadoSinIva = $('#PrecioSinIVA', $editarCompraProductoModal).val();
            var precioSinIva = Globalize.parseFloat(precioIngresadoSinIva);
            precioSinIva = !isNaN(precioSinIva) ? precioSinIva : 0;
            return precioSinIva;
        },

        totalIngresadoConIva = function () {
            var totalIngresadoConIva = $('#TotalConIVA', $editarCompraProductoModal).val();
            var totalConIva = Globalize.parseFloat(totalIngresadoConIva);
            totalConIva = !isNaN(totalConIva) ? totalConIva : 0;
            return totalConIva;
        },

        totalIngresadoSinIva = function () {
            var totalIngresadoSinIva = $('#TotalSinIVA', $editarCompraProductoModal).val();
            var totalSinIva = Globalize.parseFloat(totalIngresadoSinIva);
            totalSinIva = !isNaN(totalSinIva) ? totalSinIva : 0;
            return totalSinIva;
        },

        isCantidadVisible = function () {
            return $ingresarCantidadContainer.is(':visible');
        },

        cantidadIngresada = function () {
            var cantidad = Globalize.parseFloat($('#CantidadIngresada', $editarCompraProductoModal).val());
            cantidad = !isNaN(cantidad) ? cantidad : 0;
            return cantidad;
        },

        triggerCompraProductoEditado = function (args) {
            $(document).trigger('maxikiosco.compra-producto-editado', [args]);
        },

        editarCompraProductoSubmit = function (e) {
             
            if (!$(this).valid()) {
                return false;
            }

            $(document.activeElement).trigger('change');

            var costoConIva = costoIngresadoConIva();
            var costoSinIva = costoIngresadoSinIva();

            var precioConIva = precioIngresadoConIva();
            var precioSinIva = precioIngresadoSinIva();

            var totalConIva = totalIngresadoConIva();
            var totalSinIva = totalIngresadoSinIva();

            var ganancia = ((precioConIva - costoConIva) / costoConIva);

            var args = {
                costoConIva: costoConIva,
                costoSinIva: costoSinIva,
                precioConIva: precioConIva,
                precioSinIva: precioSinIva,
                ganancia: ganancia,
                totalSinIva: totalSinIva,
                totalConIva: totalConIva
            };

            if (isCantidadVisible()) {
                args.cantidad = cantidadIngresada();
            }

            triggerCompraProductoEditado(args);

            $editarCompraProductoModal.off('hidden.bs.modal');
            $editarCompraProductoModal.modal('hide');

            return false;
        };
    init();
})();