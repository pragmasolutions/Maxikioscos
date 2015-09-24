var util = function() {
    var focusPrimerElemento = function(container) {

        setTimeout(function() {
            $(container).find('input[type!="hidden"]:eq(0)').focus();
        }, 300);
    },
    focusEnControl = function (container, id) {

        setTimeout(function () {
            $(container).find('#' + id).focus();
        }, 300);
    };

    return {
        focusPrimerElemento: focusPrimerElemento,
        focusEnControl: focusEnControl
    };
}();

var formatHelper = function (Globalize) {
    var formarMoney = function (value) {
        return Globalize.format(value, 'c2');
    };

    var formarDecimal = function (value) {
        return Globalize.format(value, 'n2');
    };

    var formatPercentage = function (value) {
        return Globalize.format(value, 'p2');
    };

    return {
        formarMoney: formarMoney,
        formarDecimal: formarDecimal,
        formatPercentage: formatPercentage
    };
}(Globalize)