var controlStock = function () {
    var $modal = $("#ControlStockModal"),
        $modalContent = $("#ControlStockModal .modal-content"),
        $formFiltros = $('#FormularioFiltrosControlStock'),
        init = function () {
            controles.parse('#AdminContainer');
            $("#ListadoContainer").on('click', 'a.btn-controlStrock-eliminar', eliminar);

            $modal.on('submit', 'form', submit);
        },
        eliminar = function () {
            var url = $(this).attr('href');
            cargarVista(url);
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
            .done(function (response) {
                if (response.success) {
                    $modal.modal('hide').on('hidden.bs.modal', function () {
                        $modal.off('hidden.bs.modal');
                        $formFiltros.submit();
                    });
                } else {
                    alert('Ha ocurrido un error al eliminar el control de stock');
                }
            })
            .always(function () {
                maxikioscoSpinner.stopSpin();
            });

            return false;
        },
        cargarVista = function (url) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();
                $modal.modal();
                util.focusPrimerElemento($modalContent);
                return false;
            });
        };
    init();
}();

