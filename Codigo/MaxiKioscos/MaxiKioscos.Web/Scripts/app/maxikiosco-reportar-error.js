(function () {
    var $reportarErrorModal = $('#ReportarErrorModal');
    var $reportarErrorModalContent = $('#ReportarErrorModal .modal-content');
    var init = function () {
        
        $reportarErrorModal.on('submit', 'form', function () {
            var url = $(this).attr('action');

            var formData = $(this).serialize();

            var options = {
                type: "POST",
                data: formData
            };
            
            maxikioscoSpinner.startSpin();
            
            $.ajax(url, options)
                .done(function (data) {
                    ////Replace the modal body with the data
                    $reportarErrorModalContent.html(data);
                }).always(maxikioscoSpinner.stopSpin);

            return false;
        });

        $('.btn-reportar-error').click(function () {
            var url = $(this).data('reportar-error-url');
            
            $reportarErrorModalContent.load(url, function () {
                maxikioscoSpinner.stopSpin();
                validacion.parse('#ReportarErrorModal');
                controles.parse('#ReportarErrorModal');
                $reportarErrorModal.modal();
                util.focusPrimerElemento($reportarErrorModal);
            });

            return false;
        });
    };
    
    init();
})();


