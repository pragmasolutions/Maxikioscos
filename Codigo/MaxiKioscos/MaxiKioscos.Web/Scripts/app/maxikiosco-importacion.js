var maxikioscoAjax = function () {
    var $modal = $("#ImportacionModal"),
        $error = $("#ErrorImportacionModal"),
        $modalContent = $("#ImportacionModal .modal-content"),
        init = function() {
            $('.btn-importar').click(importar);
            $modal.on('submit', 'form', submit);
            
            //Parse inputs -datepickers
            controles.parse('#AdminContainer');
        },
        submit = function () {
            var $form = $modal.find('form');
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
        submitExito = function (response) {
            if (response.exito) {
                $modal.modal('hide').on('hidden.bs.modal', function () {
                    //Refresh the list.
                    refreshList();
                });
            } else {
                $modal.modal('hide');
                $error.find('.span-message').html(response.error);
                $error.modal();
            }
        },
        importar = function () {
            var url = $(this).attr('href');
            cargarVista(url);
            return false;
        },
        refreshList = function () {
            var url = '/Sincronizacion/LogImportacion';
            maxikioscoSpinner.startSpin();
            $("#AdminContainer").load(url, function () {
                maxikioscoSpinner.stopSpin();
            });
        },
        cargarVista = function (url) {

            maxikioscoSpinner.startSpin();
            $modalContent.load(url, function () {
                
                maxikioscoSpinner.stopSpin();

                //Reparse form.
                validacion.parse('#ImportacionModal');
                //Reparse form validation.
                controles.parse('#ImportacionModal');
                $('#NombreArchivo').attr('readonly', 'readonly');
                $('#fileupload').fileupload({
                    add: function (e, data) {
                        var uploadErrors = [];
                        var acceptFileTypes = /(zip)$/i;
                        if (data.originalFiles[0]['type'].length && !acceptFileTypes.test(data.originalFiles[0]['type'])) {
                            uploadErrors.push('Solamente puede cargar archivos de extension ".zip"');
                        }
                        if (uploadErrors.length > 0) {
                            alert(uploadErrors.join("\n"));
                        } else {
                            data.submit();
                        }
                    },
                    url: '/Sincronizacion/ZipUpload',
                    dataType: 'json',
                    acceptFileTypes: /(zip)$/i,
                    done: function (e, data) {
                        $('#NombreArchivo').val(data.result.name);
                    },
                    fail: function (e, data) {
                        $.each(data.messages, function (index, error) {
                            $('<p style="color: red;">Upload file error: ' + error + '<i class="elusive-remove" style="padding-left:10px;"/></p>')
                            .appendTo('#div_files');
                        });
                    },
                    progressall: function (e, data) {
                        var progress = parseInt(data.loaded / data.total * 100, 10);
                        $('#progress .progress-bar').css(
                            'width',
                            progress + '%'
                        );
                    }
                }).prop('disabled', !$.support.fileInput)
        .parent().addClass($.support.fileInput ? undefined : 'disabled');

                $modal.modal();
                return false;
            });
        };
    init();
}();