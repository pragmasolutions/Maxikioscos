var productos = function () {
    var $modal = $("#ProductosModal"),
        $modalContent = $("#ProductosModal .modal-content"),
        $productoErrorModal = $('#ProductoErrorModal'),
        $productoErrorModalContent = $('#ProductoErrorModal .modal-content'),
        $agregarMarcaModalContent = $("#AgregarMarcaModal .modal-content"),
        $agregarRubroModalContent = $("#AgregarRubroModal .modal-content"),
        $formFiltros = $('#FormularioFiltrosProductos'),
        init = function () {
            $('.btn-producto-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-producto-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-producto-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-producto-eliminar', eliminar);

            $modal.on('click', '.btn-agregar-codigo', agregarCodigo);
            $modal.on('click', '.btn-agregar-costo', agregarCosto);
            $modal.on('submit', 'form', submit);

            //Parse auto-submit-input
            controles.parse('#AdminContainer');
            
            $formFiltros.submit(function () {
                
                var table = $('#TableProductos').data('cursortable');
                var $currentRow = table.currentRow;
                var currentRowId = $currentRow.prop('id');
                $formFiltros.find('#CurrentRowId').val(currentRowId);
                $('#TableProductos').cursortable('remove');
            });
        },
        crear = function () {
            var url = $(this).attr('href');
            cargarVista(url, vistaEdicionCargada);
            
            return false;
        },
        submit = function () {
            var $form = $(this);
            var url = $form.attr('action');
            var data = $form.serialize();
            //Post
            maxikioscoSpinner.startSpin();
            $.ajax({
                type: "POST",
                url: url,
                data: data
            })
            .done(submitExito)
            .always(function () {
                maxikioscoSpinner.stopSpin();
            });

            return false;
        },
        vistaEdicionCargada = function () {

            var $btnEliminarCodigo = $modal.find('.btn-eliminar-codigo');
            var $btnEliminarCosto = $modal.find('.btn-eliminar-costo');

            parseConfirmEliminarCodigo($btnEliminarCodigo);
            parseConfirmEliminarCosto($btnEliminarCosto);

            //Reparse form.
            validacion.parse('#ProductosModal');

            //Reparse form validation.
            controles.parse('#ProductosModal');

            //Para validacion de tabs ocultos.
            var $form = $("#ProductosModal form");
            var validator = $.data($form[0], 'validator');
            validator.settings.ignore = '';

            $form.submit(formProductosSubmit);

            parseIvaTableInputs();

            var $inputConIva = $('#PrecioConIVA');
            var $inputSinIva = $('#PrecioSinIVA');
            iva.parseTextBoxes($inputSinIva, $inputConIva);

            $('a.agregar-marca', $modalContent).click(function () {

                var url = $(this).prop('href');
                maxikioscoSpinner.startSpin();
                $agregarMarcaModalContent.load(url, function () {
                    maxikioscoSpinner.stopSpin();
                    var $agregarMarcaModal = $('#AgregarMarcaModal');
                    controles.parse('#AgregarMarcaModal');
                    validacion.parse('#AgregarMarcaModal');
                    $agregarMarcaModal.modal();

                    $agregarMarcaModal.find('form').submit(function () {

                        var formUrl = $(this).prop('action');
                        maxikioscoSpinner.startSpin();
                        $.ajax({
                            url: formUrl,
                            type: "POST",
                            data: $(this).serialize()
                        }).done(function (response) {

                            //Refresh selects;
                            var nuevaMarca = response.marca;
                            var $newOption = $('<option>' + nuevaMarca.Descripcion + '</option>');
                            $newOption.val(nuevaMarca.MarcaId);
                            var $marcasSelect = $("#MarcaId", $modalContent);
                            $newOption.appendTo($marcasSelect);
                            $marcasSelect.select2('val', nuevaMarca.MarcaId);
                            $marcasSelect.select2('close');
                            $agregarMarcaModal.modal('hide');
                        }).always(function () {
                            maxikioscoSpinner.stopSpin();
                        });

                        return false;
                    });
                });

                return false;
            });

            $('a.agregar-rubro', $modalContent).click(function () {

                var url = $(this).prop('href');
                maxikioscoSpinner.startSpin();
                $agregarRubroModalContent.load(url, function () {
                    maxikioscoSpinner.stopSpin();
                    var $agregarRubroModal = $('#AgregarRubroModal');
                    controles.parse('#AgregarRubroModal');
                    validacion.parse('#AgregarRubroModal');
                    $agregarRubroModal.modal();

                    $agregarRubroModal.find('form').submit(function () {

                        var formUrl = $(this).prop('action');
                        maxikioscoSpinner.startSpin();
                        $.ajax({
                            url: formUrl,
                            type: "POST",
                            data: $(this).serialize()
                        }).done(function (response) {

                            //Refresh selects;
                            var nuevaRubro = response.rubro;
                            var $newOption = $('<option>' + nuevaRubro.Descripcion + '</option>');
                            $newOption.val(nuevaRubro.RubroId);
                            var $rubrosSelect = $("#RubroId", $modalContent);
                            $newOption.appendTo($rubrosSelect);
                            $rubrosSelect.select2('val', nuevaRubro.RubroId);
                            $rubrosSelect.select2('close');
                            $agregarRubroModal.modal('hide');
                        }).always(function () {
                            maxikioscoSpinner.stopSpin();
                        });

                        return false;
                    });
                });

                return false;
            });

            //Actualizar precio con costo y margen.
            $('#CostosList').on('change', '[name$=PorcentajeGanancia],[name$=CostoConIVA]', function () {
                var $row = $(this).closest('tr');

                var costoString = $('[name$=CostoConIVA]', $row).val();
                var porcentajeGananciaString = $('[name$=PorcentajeGanancia]', $row).val();

                if (String.isNullOrEmpty(costoString) || String.isNullOrEmpty(porcentajeGananciaString)) return;

                var costo = Globalize.parseFloat(costoString);
                var porcentajeGanancia = Globalize.parseFloat(porcentajeGananciaString);

                var nuevoPrecio = (costo * (porcentajeGanancia / 100)) + costo;

                var $precioInput = $('#PrecioConIVA', $modalContent);

                $precioInput.val(Globalize.format(nuevoPrecio, 'n2'));
                $precioInput.trigger('change');
            });

            //Actualizar el margen de ganancia con el precio y costo.
            $('#PrecioConIVA,#PrecioSinIVA', $modalContent).change(function () {

                var esPrecioConIva = $(this).prop('name') === 'PrecioConIVA';

                var precioString = $(this).val();

                if (String.isNullOrEmpty(precioString)) return;

                var precio = Globalize.parseFloat(precioString);

                $('#CostosList').find('tr').each(function () {
                    var $row = $(this).closest('tr');

                    var costoString = esPrecioConIva ? $('[name$=CostoConIVA]', $row).val() : $('[name$=CostoSinIVA]', $row).val();

                    if (String.isNullOrEmpty(costoString)) return;

                    var costo = Globalize.parseFloat(costoString);

                    var porcentajeGanancia = ((precio - costo) / costo) * 100;

                    $('[name$=PorcentajeGanancia]', $row).val(Globalize.format(porcentajeGanancia, 'n2'));
                });
            });

        },
        submitExito = function (response) {
            if (response.exito) {
                $modal.modal('hide').on('hidden.bs.modal', function () {
                    //Refresh the list.
                    refreshList();
                });
            } else {
                $modal.modal('hide');
                //});
                $productoErrorModalContent.load('/Productos/CodigoDuplicadoPopup', function () {
                    maxikioscoSpinner.stopSpin();
                    validacion.parse('#ProductoErrorModal');
                    controles.parse('#ProductoErrorModal');
                    $productoErrorModal.modal();
                });
            }
        },
        refreshList = function () {
            $formFiltros.submit();
        },
        editar = function () {
            var url = $(this).attr('href');
            cargarVista(url, vistaEdicionCargada);
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
        agregarCodigo = function () {
            var url = $(this).attr('href');

            $.ajax({
                url: url
            }).done(function (row) {
                var $row = $(row);
                $modalContent.find('#CodigosList').append($row);
                var $btnEliminarCodigo = $row.find('.btn-eliminar-codigo');
                parseConfirmEliminarCodigo($btnEliminarCodigo);
            });

            return false;
        },
        agregarCosto = function () {
            var url = $(this).attr('href');

            $.ajax({
                url: url
            }).done(function (row) {
                var $row = $(row);
                $modalContent.find('#CostosList').append($row);
                var $btnEliminarCosto = $row.find('.btn-eliminar-costo');
                parseConfirmEliminarCosto($btnEliminarCosto);

                //Parse iva textbox
                var $inputConIva = $row.find('input[name$=".CostoConIVA"]');
                var $inputSinIva = $row.find('input[name$=".CostoSinIVA"]');

                iva.parseTextBoxes($inputSinIva, $inputConIva);

                controles.parse('#CostosList');

                $.validator.unobtrusive.parseDynamicContent($row);
            });

            return false;
        },
        eliminarCodigo = function (btnDelete) {
            $(btnDelete)
                .closest('li')
                .remove();
        },
        eliminarCosto = function (btnDelete) {
            $(btnDelete)
                .closest('tr')
                .remove();
        },
        parseConfirmEliminarCodigo = function (element) {

            $(element).confirm({
                text: "¿Esta seguro que desea eliminar el código?",
                title: "Eliminar Código",
                confirm: eliminarCodigo,
                confirmButton: "Aceptar",
                cancelButton: "Cancelar",
            });
        },
        parseConfirmEliminarCosto = function (element) {

            $(element).confirm({
                text: "¿Esta seguro que desea eliminar el costo?",
                title: "Eliminar Costo",
                confirm: eliminarCosto,
                confirmButton: "Aceptar",
                cancelButton: "Cancelar",
            });
        },
        parseIvaInputsFromRow = function (tr) {
            var $inputConIva = $(tr).find('input[name$=".CostoConIVA"]');
            var $inputSinIva = $(tr).find('input[name$=".CostoSinIVA"]');

            iva.parseTextBoxes($inputSinIva, $inputConIva);
        },
        parseIvaTableInputs = function (table) {
            $('#CostosList').find('tr').each(function () {
                parseIvaInputsFromRow(this);
            });
        },
        cargarVista = function (url, callback) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();

                if (callback) {
                    callback();
                }

                $modal.modal();
                util.focusPrimerElemento($modalContent);
                return false;
            });
        },
        formProductosSubmit = function () {

            var $form = $(this);

            var isFistTabWithErrorsActive = false;

            //Focus first tab with errors
            $("#ProductosTabControl").find("div.tab-pane").each(function () {
                var id = $(this).attr("id");
                var $tab = $('a[href="#' + id + '"]');
                $(this).find('input,select').each(function () {
                    if (!$(this).valid()) {
                        $tab.tab('show');
                        isFistTabWithErrorsActive = true;
                        return false;
                    }
                    return true;
                });

                return !isFistTabWithErrorsActive;
            });

            return $form.valid();
        };

    init();
}();

