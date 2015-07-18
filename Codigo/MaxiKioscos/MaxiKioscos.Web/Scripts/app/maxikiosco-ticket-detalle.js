var maxikioscoAjax = function () {
    var $modal = $("#TicketModal"),
        $modalContent = $("#TicketModal .modal-content"),
        init = function () {
            $('.btn-ticket-abrir').click(abrir);
            $('.btn-ticket-cerrar').click(cerrar);
            $('.btn-ticket-eliminar').click(eliminar);
            
            $('.mensajes').on('submit', 'form', submit);
        },
        submit = function () {
            var $form = $(this);
            var url = $form.attr('action');
            var data = $form.serialize() + '&TicketId=' + $('#Ticket_TicketErrorId').val();
            //Post
            maxikioscoSpinner.startSpin();
            $.ajax({
                type: "POST",
                url: url,
                data: data
            }).done(submitExito);
            
            return false;
        },
        submitExito = function (result) {
            if (result.success) {
                refrescarMensajes();
            } else {
                maxikioscoSpinner.stopSpin();
            }
        },
        refrescarMensajes = function () {
            $('#NuevoMensaje').val('');
            var url = '/Feedback/MensajesListado/' + $('#Ticket_TicketErrorId').val();
            $(".mensajes-container").load(url, function () {
                maxikioscoSpinner.stopSpin();
            });
        },
        abrir = function () {
            maxikioscoSpinner.startSpin();
            $.ajax({
                type: "POST",
                url: '/Feedback/AbrirTicket?id=' + $('#Ticket_TicketErrorId').val()
            }).done(function (response) {
                if (response.exito) {
                    $('.btn-ticket-abrir').attr('disabled', 'disabled');
                    $('.btn-ticket-cerrar').removeAttr('disabled');
                    $('.btn-ticket-eliminar').removeAttr('disabled');
                    $('.estado-td').html('En Progreso');
                }
                maxikioscoSpinner.stopSpin();
            });
            return false;
        },
        cerrar = function () {
            maxikioscoSpinner.startSpin();
            $.ajax({
                type: "POST",
                url: '/Feedback/CerrarTicket/' + $('#Ticket_TicketErrorId').val()
            }).done(function (response) {
                if (response.exito) {
                    $('.btn-ticket-abrir').removeAttr('disabled'); 
                    $('.btn-ticket-cerrar').attr('disabled', 'disabled');
                    $('.btn-ticket-eliminar').removeAttr('disabled');
                    $('.estado-td').html('Cerrado');
                    $('.mensajes form').hide();
                }
                maxikioscoSpinner.stopSpin();
            });
            return false;
        },
        eliminar = function () {
            maxikioscoSpinner.startSpin();
            $.ajax({
                type: "POST",
                url: '/Feedback/EliminarTicket/' + $('#Ticket_TicketErrorId').val()
            }).done(function (response) {
                if (response.exito) {
                    $('.btn-ticket-abrir').removeAttr('disabled');
                    $('.btn-ticket-cerrar').attr('disabled', 'disabled');
                    $('.btn-ticket-eliminar').attr('disabled', 'disabled');
                    $('.estado-td').html('Eliminado');
                    $('.mensajes form').hide();
                }
                maxikioscoSpinner.stopSpin();
            });
            return false;
        },
        cargarVista = function (url) {
            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();
                validacion.parse('#TicketModal');
                controles.parse('#TicketModal');
                $modal.modal();
                return false;
            });
        };
    init();
}();