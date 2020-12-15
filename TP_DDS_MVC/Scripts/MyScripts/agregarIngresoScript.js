var data = {
    model: {
        descripcion: null,
        monto: null,
        fechaDesde: null,
        fechaHasta: null,
    }
}

$(document).ready(function () {
    $('#error').hide()
});

$("#submit").click(function () {

    data.model.descripcion = $(descripcion).val();
    data.model.monto = $(monto).val();
    data.model.fechaDesde = $(fechaInicio).val();
    data.model.fechaHasta = $(fechaFin).val();
  

    console.log(data.model);

    $.ajax({
        type: "POST",
        url: "/ingreso/add",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(data.model),
        crossDomain: true,
        success: function (data) {
            window.location.href = data;
        },
        error: function (data) {
            $('#error').show();
            $('#error').html(data.responseJSON);
        }
    })
})