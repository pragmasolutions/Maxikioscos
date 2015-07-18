$(function () {

    $('#side-menu').metisMenu();

    //Configure global js errors
    window.onerror = function (msg, url, linenumber, colno, error) {
        //alert("Ha ocurrido un error.  Por favor cierre la aplicación he intente de nuevo.");
        var stack = '';
        if (error) {
            stack = error.stack;
        }
        alert('Error message: ' + msg + '\nURL: ' + url + '\nLine Number: ' + linenumber + '\nStack: ' + stack);
    };

    //Confiure redirection to login url for ajax requests.
    $(document).ajaxError(function (e, xhr) {
        if (xhr.status == 403) {
            var response = $.parseJSON(xhr.responseText);
            window.location = response.LogOnUrl;
        }
    });
});

//Loads the correct sidebar on window load,
//collapses the sidebar on window resize.
$(function () {
    $(window).bind("load resize", function () {
        if ($(this).width() < 768) {
            $('div.sidebar-collapse').addClass('collapse');
        } else {
            $('div.sidebar-collapse').removeClass('collapse');
        }
    });
});

$.fn.scrollTo = function (target, options, callback) {
    if (typeof options == 'function' && arguments.length == 2) { callback = options; options = target; }
    var settings = $.extend({
        scrollTarget: target,
        offsetTop: 50,
        duration: 500,
        easing: 'swing'
    }, options);
    return this.each(function () {
        var scrollPane = $(this);
        var scrollTarget = (typeof settings.scrollTarget == "number") ? settings.scrollTarget : $(settings.scrollTarget);
        var scrollY = (typeof scrollTarget == "number") ? scrollTarget : scrollTarget.offset().top + scrollPane.scrollTop() - parseInt(settings.offsetTop);
        scrollPane.animate({ scrollTop: scrollY }, parseInt(settings.duration), settings.easing, function () {
            if (typeof callback == 'function') { callback.call(this); }
        });
    });
}
