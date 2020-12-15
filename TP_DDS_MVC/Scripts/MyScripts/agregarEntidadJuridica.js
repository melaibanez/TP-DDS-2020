var data = {
    model: {
        entidad: {
            nombreFicticio: null,
            razonSocial: null,
            codInscripDefinitiva: null,
            CUIT: null,
            direccionPostal: {
                calle: null,
                numero: null,
                piso_depto: null,
                ciudad: null,
                provincia: null,
                pais: null
            }
        },
        tipoOrganizacion: null,
        actividad: null,
        sector: null,
        promVentas: null,
        cantPersonal: null,
        cargarBase: 0
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
    data.model.entidad.razonSocial = $('#razonSocial').val();
    data.model.entidad.codInscripDefinitiva = $('#codIGJ').val();
    data.model.entidad.CUIT = $('#CUIT').val();
    data.model.entidad.direccionPostal.calle = $('#calle').val();
    data.model.entidad.direccionPostal.numero = $('#numero').val();
    data.model.entidad.direccionPostal.piso_depto = $('#pisoDepto').val();
    data.model.entidad.direccionPostal.pais = $('#pais').val();
    data.model.entidad.direccionPostal.provincia = $('#provincia').val();
    data.model.entidad.direccionPostal.ciudad = $('#ciudad').val();
    data.model.tipoOrganizacion = $("#tipoOrg").val()
    data.model.actividad = $("#actividad").val()
    data.model.sector = $("#sector").val()
    data.model.promVentas = $("#promVentas").val()
    data.model.cantPersonal = $("#cantPersonal").val()
    data.model.cargarBase = cargarBase

    $.ajax({
        type: "POST",
        url: "/entidad/entidad-juridica/add",
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

