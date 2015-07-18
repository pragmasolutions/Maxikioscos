var iva = (function () {
    var parseTextBoxes = function(inputSinIva, inputConIva) {
            
        $(inputConIva).filter(':not(.iva-input-parsed)').change(function () {

            var valorConIVAString = $(this).val();
            var valorConIVA = String.isNullOrEmpty(valorConIVAString) ? 0 : Globalize.parseFloat(valorConIVAString);
            var valorSinIVA = valorConIVA / 1.21;
            $(inputSinIva).val(Globalize.format(valorSinIVA, 'n2'));
        }).addClass('iva-input-parsed').trigger('change');

        $(inputSinIva).filter(':not(.iva-input-parsed)').change(function() {

            var valorSinIVAString = $(this).val();
            var valorSinIVA = String.isNullOrEmpty(valorSinIVAString) ? 0 : Globalize.parseFloat(valorSinIVAString);
            var valorConIVA = valorSinIVA * 1.21;
            $(inputConIva).val(Globalize.format(valorConIVA, 'n2'));
        }).addClass('iva-input-parsed');
        
        updateWithCurrentValues(inputSinIva, inputConIva);
    },
    updateWithCurrentValues = function (inputSinIva, inputConIva) {
        //Si uno de los textbox tiene datos y el otro no actualizamos el que no tiene.
        //Hay productos que no tiene cargado el costo con iva o el sin iva.
        
        if (String.isNullOrEmpty($(inputSinIva).val()) &&
        !String.isNullOrEmpty($(inputConIva).val())) {
            $(inputConIva).trigger('change');
        } else if (String.isNullOrEmpty($(inputConIva).val()) &&
            !String.isNullOrEmpty($(inputSinIva).val())) {
            $(inputSinIva).trigger('change');
        }
    };

    return {
        parseTextBoxes: parseTextBoxes
    };
})();