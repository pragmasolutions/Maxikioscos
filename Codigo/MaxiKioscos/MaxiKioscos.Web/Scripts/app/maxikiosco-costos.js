﻿var maxikioscoAjax = function () {
    var $modal = $("#CostosModal"),
        $modalContent = $("#CostosModal .modal-content"),
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
            var $form = $modal.find('form');
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
            cargarVista(url);
            return false;
        },
        eliminar = function () {
            var url = $(this).attr('href');
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
                return false;
            });
        },
        editar = function () {
            var url = $(this).attr('href');
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