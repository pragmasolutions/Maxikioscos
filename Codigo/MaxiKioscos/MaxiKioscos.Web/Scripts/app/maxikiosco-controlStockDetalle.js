var controlStockDetalle = function () {
    var $modal = $("#ControlStockDetalleModal"),
        $modalContent = $("#ControlStockDetalleModal .modal-content"),
        $productoModal = $("#ProductosModal"),
        $productoModalContent = $("#ProductosModal .modal-content"),
        _correcciones = [],
        init = function() {
            $('.btn-controlStock-cerrar').click(cerrar);
            $("#ListadoContainer").on('click', 'a.btn-controlStockDetalle-editar', corregir);
            $("#ListadoContainer").on('click', 'a.btn-controlStockDetalle-eliminar', eliminar);
            $("#ListadoContainer").on('click', 'a.btn-producto', detalleProducto);
            $modal.on('submit', 'form', submit);
            
            //Parse auto-submit-input
            controles.parse('#AdminContainer');
            $('.auto-submit').keydown(filtrar);

            $('#ListadoContainer form ul').hide();
            $('#ListadoContainer form li').hide();

        },
        filtrar = function() {
            var descripcion = $('#Descripcion').val();
            $("#TableControlStock tbody tr").removeClass("hideSearch");
            $("#TableControlStock tbody tr td:eq(0):contains('" + descripcion + "')").each(function(i, td) {
                $(td).closest('tbody tr').addClass('hideSearch');
            });

            $("#TableControlStock tbody tr").hide();
            $("#TableControlStock tbody tr.hideSearch").show();
        },
        corregir = function() {
            var url = $(this).attr('href');
            cargarVista(url, function() {
                maxikioscoSpinner.stopSpin();

                //Reparse form.
                validacion.parse('#ControlStockDetalleModal');
                //Reparse form validation.
                controles.parse('#ControlStockDetalleModal');

                $modal.modal();
                refrescarCamposPopup(url);
                return false;
            });
            return false;
        },
        detalleProducto = function () {
            var id = $(this).data().productoid;
            cargarVistaProducto(id);
            return false;
        },
        eliminar = function () {
            $(this).hide();
            var id = $(this).data().id;
            _correcciones = $.grep(_correcciones, function (item) { return item.ControlStockDetalleId != id; });
            var $tr = $("#TableControlStock tr[data-id='" + id + "']");
            $tr.find('td:eq(2)').html('');
            $tr.find('td:eq(3)').html('');
            
            $tr.find('input[name*=".Correccion"]').val('');
            $tr.find('input[name*=".MotivoCorreccionId"]').val('');
            $tr.find('input[name*=".Precio"]').val('');
            return false;
        },
        cargarVista = function(url, callback) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function() {
                maxikioscoSpinner.stopSpin();

                if (callback) {
                    callback();
                }
                $modal.modal();
                util.focusPrimerElemento($modalContent);
                return false;
            });
        },
        cargarVistaProducto = function (id, callback) {
            maxikioscoSpinner.startSpin();
            var url = '/Productos/Detalle/' + id;
            $productoModalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();

                if (callback) {
                    callback();
                }
                $productoModal.modal();
                //util.focusPrimerElemento($modalContent);
                return false;
            });
        },
        refrescarCamposPopup = function (url) {
            var id = url.split('/').pop();
            var detalle = $.grep(_correcciones, function (item) { return item.ControlStockDetalleId == id; })[0];
            if (detalle) {
                $('#Correccion').val(detalle.Correccion);
                $('#MotivoCorreccionId').select2("val", detalle.MotivoCorreccionId);
            }
        },
        submit = function () {
            var detalle = {
                ControlStockDetalleId: $('#ControlStockDetalleId').val(),
                Correccion: $('#Correccion').val(),
                MotivoCorreccionId: $('#MotivoCorreccionId').val(),
                MotivoCorreccionDescripcion: $("#MotivoCorreccionId option:selected").text(),
                Precio: $('#PrecioPorUnidad').val()
            };
            _correcciones = $.grep(_correcciones, function(item) { return item.ControlStockDetalleId != detalle.ControlStockDetalleId; });
            _correcciones.push(detalle);
            reflejarEnListado(detalle);
            $modal.modal('hide');
            return false;
        },
        reflejarEnListado = function (detalle) {
            var $tr = $("#TableControlStock tr[data-id='" + detalle.ControlStockDetalleId + "']");
            $tr.find('td:eq(2)').html(detalle.Correccion);
            $tr.find('td:eq(3)').html(detalle.MotivoCorreccionDescripcion);
            $tr.find('.btn-controlStockDetalle-eliminar').show();

            $tr.find('input[name*=".Correccion"]').val(detalle.Correccion);
            $tr.find('input[name*=".MotivoCorreccionId"]').val(detalle.MotivoCorreccionId);
            $tr.find('input[name*=".Precio"]').val(parseFloat(detalle.Precio) * parseFloat(detalle.Correccion));
        },
        cerrar = function () {
            bootbox.confirm("Está seguro que desea cerrar el control de stock?", function (confirm) {
                if (confirm) {
                    var $form = $('#ListadoContainer form');
                    var url = $form.attr('action');
                    var data = $form.serialize();
                    //Post
                    $.ajax({
                        type: "POST",
                        url: url,
                        data: data
                    }).done(submitExito);
                }
            });

            return false;
        },
        submitExito = function (response) {
            if (response) {
                maxikioscoSpinner.startSpin();
                volverAlListado();
            }
        },
        volverAlListado = function () {
            $('#AdminContainer').load('/ControlStock/Index', maxikioscoSpinner.stopSpin);
        };

    init();
}();

