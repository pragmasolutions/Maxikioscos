var productos = function () {
    var $modal = $("#ProductosModal"),
        $form = $("#ProductosModal form"),
        $modalContent = $("#ProductosModal .modal-content"),
        $agregarMarcaModal = $("#AgregarMarcaModal"),
        $agregarMarcaModalContent = $("#AgregarMarcaModal .modal-content"),
        $agregarRubroModal = $("#AgregarRubroModal"),
        $agregarRubroModalContent = $("#AgregarRubroModal .modal-content"),
        init = function () {
            
            $('.btn-agregar-codigo', $modal).click(agregarCodigo);
            $('.btn-agregar-costo', $modal).click(agregarCosto);
            
            $agregarRubroModal.on('submit', 'form', submitRubro);
            $agregarMarcaModal.on('submit', 'form', submitMarca);
            
            $form.submit(formProductosSubmit);

            parseControls();
        },
        
        parseControls = function () {

            var $btnEliminarCodigo = $('.btn-eliminar-codigo', $modal);
            var $btnEliminarCosto = $('.btn-eliminar-costo', $modal);

            parseConfirmEliminarCodigo($btnEliminarCodigo);
            parseConfirmEliminarCosto($btnEliminarCosto);

            //Reparse form.
            validacion.parse('#ProductosModal');

            //Reparse form validation.
            controles.parse('#ProductosModal');

            //Para validacion de tabs ocultos.
            var validator = $.data($form[0], 'validator');
            validator.settings.ignore = '';

            parseIvaTableInputs();

            var $inputConIva = $('#PrecioConIVA', $modal);
            var $inputSinIva = $('#PrecioSinIVA', $modal);
            iva.parseTextBoxes($inputSinIva, $inputConIva);

            $('a.agregar-marca', $modalContent).click(function () {
                
                var url = $(this).prop('href');
                maxikioscoSpinner.startSpin();
                $agregarMarcaModalContent.load(url, function () {
                    maxikioscoSpinner.stopSpin();
                    
                    controles.parse('#AgregarMarcaModal');

                    validacion.parse('#AgregarMarcaModal');
                    
                    $agregarMarcaModal.modal();
                });

                return false;
            });

            $('a.agregar-rubro', $modalContent).click(function () {

                var url = $(this).prop('href');
                maxikioscoSpinner.startSpin();
                $agregarRubroModalContent.load(url, function () {
                    maxikioscoSpinner.stopSpin();
                    
                    controles.parse('#AgregarRubroModal');
                    
                    validacion.parse('#AgregarRubroModal');
                    
                    $agregarRubroModal.modal();
                });

                return false;
            });

            //Actualizar precio cuando cambia margen de ganancia.
            $('#CostosList').on('change', '[name$=PorcentajeGanancia]', function () {
                var $row = $(this).closest('tr');
                
                var porcentajeGananciaString = $('[name$=PorcentajeGanancia]', $row).val();
                
                var costoString = $('[name$=CostoConIVA]', $row).val();

                if (String.isNullOrEmpty(porcentajeGananciaString) || String.isNullOrEmpty(costoString)) return;

                var costo = Globalize.parseFloat(costoString);
                
                var porcentajeGanancia = Globalize.parseFloat(porcentajeGananciaString);

                var nuevoPrecio = (costo * (porcentajeGanancia / 100)) + costo;

                var $precioInput = $('#PrecioConIVA', $modalContent);

                $precioInput.val(Globalize.format(nuevoPrecio, 'n2'));

                var isManualTrigger = true;
                
                $precioInput.trigger('change', [isManualTrigger]);
            });

            //Actualizar porcentaje de ganania cuando cambia costo.
            $('#CostosList').on('change', '[name$=CostoConIVA],[name$=CostoSinIVA]', function () {
                var $row = $(this).closest('tr');

                var costoString = $('[name$=CostoConIVA]', $row).val();
                
                var precioString = $('#PrecioConIVA').val();

                if (String.isNullOrEmpty(costoString) || String.isNullOrEmpty(precioString)) return;
                
                var costo = Globalize.parseFloat(costoString);

                var precio = Globalize.parseFloat(precioString);
                
                var porcentajeGanancia = ((precio - costo) / costo) * 100;

                var $porcentajeGananciaInput = $('[name$=PorcentajeGanancia]', $row);

                $porcentajeGananciaInput.val(Globalize.format(porcentajeGanancia, 'n2'));
            });

            //Actualizar el margen de ganancia con el precio y costo.
            $('#PrecioConIVA,#PrecioSinIVA', $modalContent).change(function (e, isManualTrigger) {
                if (isManualTrigger) return;

                var precioString = $(this).val();

                if (String.isNullOrEmpty(precioString)) return;

                var precio = Globalize.parseFloat(precioString);

                $('#CostosList').find('tr').each(function () {
                    var $row = $(this).closest('tr');

                    var costoString = $('[name$=CostoConIVA]', $row).val();

                    if (String.isNullOrEmpty(costoString)) return;

                    var costo = Globalize.parseFloat(costoString);

                    var porcentajeGanancia = ((precio - costo) / costo) * 100;

                    $('[name$=PorcentajeGanancia]', $row).val(Globalize.format(porcentajeGanancia, 'n2'));
                });
            });
        },
        
        submitMarca = function() {
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
        },
        
        submitRubro = function() {
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
        },
        
        submitCompleted = function (response) {
            
            $modal.trigger('maxikiosco.productoSubmitCompleted', [response]);
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

            if (!$form.valid()) {
                return false;
            }
            
            var url = $form.attr('action');
            var data = $form.serialize();

            //Post
            maxikioscoSpinner.startSpin();
            $.ajax({
                type: "POST",
                url: url,
                data: data
            })
            .done(submitCompleted)
            .always(function () {
                maxikioscoSpinner.stopSpin();
            });

            return false;
        };

    init();
}();