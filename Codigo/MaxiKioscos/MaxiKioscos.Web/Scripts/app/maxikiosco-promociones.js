var productos = function () {
    var $modal = $("#ProductosModal"),
        $modalContent = $("#ProductosModal .modal-content"),
        $productoErrorModal = $('#ProductoErrorModal'),
        $productoErrorModalContent = $('#ProductoErrorModal .modal-content'),
        $formFiltros = $('#FormularioFiltrosProductos'),
        init = function () {
            
            $('.btn-producto-crear').click(crear);
            $("#ListadoContainer").on('click', 'a.btn-producto-editar', editar);
            $("#ListadoContainer").on('click', 'a.btn-producto-detalle', detalle);
            $("#ListadoContainer").on('click', 'a.btn-producto-eliminar', eliminar);
            
            $modal.on('maxikiosco.productoSubmitCompleted', productoSubmitCompleted);

            //Parse auto-submit-input
            controles.parse('#AdminContainer');
            
            $formFiltros.submit(function() {
                
                var $currentRow = $('#TableProductos tbody tr.highlight');
                var currentRowId = $currentRow.prop('id');
                $formFiltros.find('#CurrentRowId').val(currentRowId);
                $('#TableProductos').cursortable('remove');

            });
            util.focusPrimerElemento('#AdminContainer');
        },
        crear = function() {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        productoSubmitCompleted = function (e, response) {
            
            if (response.exito) {
                $modal.modal('hide').on('hidden.bs.modal', modalHiddenAfterSuccess);

            } else {
                $modal.modal('hide');
                $productoErrorModalContent.load('/Productos/CodigoDuplicadoPopup', function() {
                    maxikioscoSpinner.stopSpin();
                    validacion.parse('#ProductoErrorModal');
                    controles.parse('#ProductoErrorModal');
                    $productoErrorModal.modal();
                });
            }
            
        },
        
        modalHiddenAfterSuccess = function () {
            //Unsubscribe
            $modal.off('hidden.bs.modal', modalHiddenAfterSuccess);
            //Refresh the list.
            refreshList();
        },

        refreshList = function() {
            $formFiltros.submit();
        },
        editar = function() {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        detalle = function() {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        eliminar = function() {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        cargarVista = function(url) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function() {
                maxikioscoSpinner.stopSpin();
                $modal.modal();
                util.focusPrimerElemento($modalContent);
                return false;
            });
        };

    init();
}();

