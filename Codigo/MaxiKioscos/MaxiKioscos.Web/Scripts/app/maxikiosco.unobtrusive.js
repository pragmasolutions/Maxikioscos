
var controles = function () {

    parse = function (contenedorSelector) {

        var nombre = '';

        if (contenedorSelector) {
            nombre = contenedorSelector + ' ';
        }

        $.each($(nombre + 'select[data-searchable]'), function (i, item) {
            var options = { allowClear: true };
            if ($(item).attr("multiple")) {
                options.multiple = true;
            }
            $(item).select2(options);
        });

        $.each($(nombre + 'select[data-multi]'), function (i, item) {
            var options = { selectAllText: true };
            if ($(item).data().sercheable) {
                options.enableFiltering = true;
                options.maxHeight = 175;
            }

            if ($(item).data().nonselectedtext) {
                options.nonSelectedText = $(item).data().nonselectedtext;
            }
            $(item).multiselect(options);
        });

        $.each($(nombre + 'input.autonumeric'), function (i, item) {
            $(item).autoNumeric('init');
        });

        //Parse timepicker.
        $.each($(nombre + 'div.bootstrap-timepicker input[type="text"]'), function (i, item) {
            $(item).timepicker({ showMeridian: false })
                .on('changeTime.timepicker', function (e) {
                    if ($(this).valid) {
                        $(this).valid();
                    }
                });
        });

        //Parse datepicker.
        $.each($(nombre + 'div.bootstrap-datepicker'), function (i, item) {
            $(item).datepicker({
                autoclose: true,
                todayHighlight: true,
                language: "es-AR"
            }).on('changeDate', function (ev) {
                $(this).datepicker('hide');
                
                if ($(this).find('input[type="text"]').valid) {
                    $(this).find('input[type="text"]').valid();
                }
            });
        });
        
        //Parse auto-submit-input.
        $.each($(nombre + 'input.auto-submit-input'), function (i, item) {
            var $input = $(item);
            $input.keyup(function (e) {
                if (e.which == 32) {
                    $(this).closest('form').submit();
                }
            });
        });
        
        //Parse autocomplete en formularios.
        $.each($(nombre + 'form'), function (i, item) {
            $(this).attr('autocomplete', 'off');
        });

        //Parse typeahead.
        $.each($(nombre + 'input.typeahead'), function (i, item) {
            var $input = $(item);
            var typeaheadRemoteUrl = $input.data('url') + '?q=%QUERY';
            var typeaheadData = new Bloodhound({
                datumTokenizer: function (d) {
                    return Bloodhound.tokenizers.whitespace(d.value);
                },
                queryTokenizer: Bloodhound.tokenizers.whitespace,
                remote: {
                    url: typeaheadRemoteUrl,
                    rateLimitWait: 250,
                    ajax: { cache: false }
                }
            });

            typeaheadData.initialize();

            $input.typeahead({
                autoselect: true,
                highlight: true,
                hint: true,
                minLength: 1
            }, {
                source: typeaheadData.ttAdapter(),
                name: 'TypeaheadDataset',
                displayKey: $input.data('display-key')
            }).on('typeahead:selected', function (event, data) {
                $input.data('selected-value', data[$input.data('value-key')]);
            });
        });
        
    };
    return {
        parse: parse
    };
}();

var validacion = function () {

    parse = function (contenedorSelector) {

        var container = $(document);

        if (contenedorSelector) {
            container = $(contenedorSelector);;
        }

        var form = $("form", container)
            .removeData("validator") /* added by the raw jquery.validate plugin */
            .removeData("unobtrusiveValidation"); /* added by the jquery unobtrusive plugin */

        if (form.length > 0) {
            $.validator.unobtrusive.parse(form);
        }
    };
    return {
        parse: parse
    };
}();

