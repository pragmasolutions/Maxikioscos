var maxikioscoAjax = function () {
    var $modal = $("#CostosModal"),
        $modalContent = $("#CostosModal .modal-content"),
        operation,
        init = function () {
            $('.btn-costo-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-costo-aprobar', aprobar);
            $("#ListadoContainer").on('click', 'a.btn-costo-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-costo-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-costo-eliminar', eliminar);
            $modal.on('submit', 'form', submit);
            
            //Parse auto-submit-input
            controles.parse('#AdminContainer');
        },
        crear = function () {
            var url = $(this).attr('href');
            operation = 'crear';
            cargarVista(url);
            return false;
        },
        submit = function () {
            var $form = $(this);
            var url = $form.attr('action');
            var data = $form.serialize();
            //Post
            $.ajax({
                type: "POST",
                url: url,
                data: data
            }).done(submitExito);
            
            return false;
        },
        submitExito = function (result) {
            if (result.exito) {
                $modal.modal('hide').on('hidden.bs.modal', function () {
                    //Refresh the list.

                    refreshList();
                });
            } else {
                $modalContent.html(result);
                validacion.parse('#CostosModal');
                controles.parse('#CostosModal');
                $('#EsGastoGeneral').change(checkGastoGeneral).change();
            }
        },
        refreshList = function () {
            var $form = $('#frmGastos');
            var url = '/Costos/Listado';
            var data = $form.serialize();

            maxikioscoSpinner.startSpin();
            $("#ListadoContainer").load(url + "?" + data, function () {
                maxikioscoSpinner.stopSpin();
            });
        },
        aprobar = function () {
            var url = $(this).attr('href');
            maxikioscoSpinner.startSpin();
            $.ajax({
                type: "POST",
                url: url
            }).done(refreshList);
            return false;
        },
        detalle = function () {
            var url = $(this).attr('href');
            operation = 'detalle';
            cargarVista(url);
            return false;
        },
        eliminar = function () {
            var url = $(this).attr('href');
            operation = 'eliminar';
            cargarVista(url);
            return false;
        },
        cargarVista = function (url) {
            
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();

                //Reparse form.
                validacion.parse('#CostosModal');
                //Reparse form validation.
                controles.parse('#CostosModal');

                $modal.modal();

                $('#EsGastoGeneral').change(checkGastoGeneral).change();

                $('#CategoriaPadreId').change(categoriaPadreChanged);

                if (operation == 'crear') {
                    $modalContent.find("#CategoriaCostoId").html('<option value="">Seleccione Sub-Categoría</option>');
                }
                return false;
            });
        },
        categoriaPadreChanged = function () {
            var padreId = $('#CategoriaPadreId').val();
            $modalContent.find("#CategoriaCostoId").html('<option value="">Seleccione Sub-Categoría</option>');
            if (padreId) {
                $.getJSON('/CategoriasCostos/ListadoPorPadre/' + padreId, function (hijas) {
                    
                    for (var i = 0; i < hijas.length; i++) {
                        var hija = hijas[i];
                        $modalContent.find("#CategoriaCostoId").append('<option value="' + hija.id + '">' + hija.text + '</option>');
                    }
                });
            } 
            
        },
        editar = function () {
            var url = $(this).attr('href');
            operation = 'editar';
            cargarVista(url);
            return false;
        },
        checkGastoGeneral = function() {
            if ($(this).prop('checked')) {
                $modalContent.find('.para-gasto-general').hide();
                $modalContent.find('#MaxikioscoId').val("");
            } else {
                $modalContent.find('.para-gasto-general').show();
            }
        };
    init();
}();