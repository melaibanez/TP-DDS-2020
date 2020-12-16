var data = {
    model: {
        entidad: {
            nombreFicticio: null,
            descripcion: null,
            idEntidadJuridica: null
        },
        tipoOrganizacion: null,
        actividad: null,
        sector: null,
        promVentas: null,
        cantPersonal: null,
        idEntidadJuridica: null
    }
}

$(document).ready(function () {
    $('#error').hide()
});

$("#tipoOrg").change(function () {
    if ($(this).val() === "OSC") {
        $("#formEmpresa").hide()
    }
    else if ($(this).val() === "Empresa") {
        $("#formEmpresa").show()
    }
});


$("#submit").click(function () {

    data.model.entidad.nombreFicticio = $('#nombreFicticio').val();
    data.model.entidad.descripcion = $('#descripcion').val();
    data.model.entidad.idEntidadJuridica = $("#entidad").val()
    data.model.tipoOrganizacion = $("#tipoOrg").val()
    data.model.actividad = $("#actividad").val()
    data.model.sector = $("#sector").val()
    data.model.promVentas = $("#promVentas").val()
    data.model.cantPersonal = $("#cantPersonal").val()

    $.ajax({
        type: "POST",
        url: "/entidad/entidad-base/add",
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
