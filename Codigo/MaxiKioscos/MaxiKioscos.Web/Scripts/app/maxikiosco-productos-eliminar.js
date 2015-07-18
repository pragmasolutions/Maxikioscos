(function() {
    var $modal = $("#ProductosModal"),
        $form = $("#ProductosModal form"),
        init = function() {
            $form.submit(formProductosSubmit);
        },
        formProductosSubmit = function() {

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
                .always(function() {
                    maxikioscoSpinner.stopSpin();
                });

            return false;
        },
        submitCompleted = function(response) {

            $modal.trigger('maxikiosco.productoSubmitCompleted', [response]);
        };

    init();
})();