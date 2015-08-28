function inicializarStock(productoId) {
    $('a[href="#TabCostos"]').tab('show');

    $('.btn-stock').click(function () {
        $('.stock-container').load('/Productos/Stock/' + productoId, function () {
            $('.btn-stock').hide();
            $('.fields-container').hide();
            $('.stock-container').show();
            $('.btn-volver').show();
            $('.btn-editar-producto').hide();
        });
    });

    $('.btn-volver').click(function () {
        $('.stock-container').hide();
        $('.btn-stock').show();
        $('.fields-container').show();
        $('.btn-volver').hide();
        $('.btn-editar-producto').show();
    });
}
