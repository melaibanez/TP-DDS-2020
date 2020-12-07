var data = {
    model: {
        egreso: {
            fechaEgreso: null,
            idMedioDePago: null,
            montoTotal: 0,
            idPrestadorDeServicios: null,
            detalle: []
        },
        docsComerciales: []
        
    }
}

$("#agregarItem").click(function () {
    $('#noItems').hide()

    data.model.egreso.detalle.push({
        cant: $("#cantItem").val(),
        descripcion: $("#descripcionItem").val(),
        valor: $("#valorItem").val(),

    })

    $("#listaItems").append('<li id="' + $("#descripcionItem").val() + '" class="list-group-item">' +
        $("#descripcionItem").val() + '&nbsp;-&nbsp;' +
        '$' + $("#valorItem").val() + '&nbsp;-&nbsp;' +
        $("#cantItem").val() + ' unidades&nbsp;' +
        '<button id="eliminarItem" value="' + $("#descripcionItem").val() + '" class="btn btn-outline-danger btn-sm" aria-label="Close">Eliminar</button ></li >');

    $("#descripcionItem").val('');
    $("#valorItem").val(1);
    $("#cantItem").val(1);

    console.log(data.model.egreso.detalle);
})

$(document).on("click", "#eliminarItem", function () {
    const index = data.model.egreso.detalle.findIndex(i => i.descripcion === $(this).val());
    data.model.egreso.detalle.splice(parseInt(index), 1);
    $('[id="' + $(this).val() + '"]').remove();

    if (data.model.egreso.detalle.length === 0) {
        $('#noItems').show()
    }

    console.log(data.model.egreso.detalle);
})

$("#agregarDoc").click(function () {
    $('#noDocs').hide()

    data.model.docsComerciales.push($('#documento').val())

    $("#listaDocs").append('<li id="' + $("#documento").val() + '" class="list-group-item">' +
        $("#documento").val() + '&nbsp;-&nbsp;' +
        '<button id="eliminarDoc" value="' + $("#documento").val() + '" class="btn btn-outline-danger btn-sm" aria-label="Close">Eliminar</button ></li >');

    $("#documento").val('');

    console.log(data.model.docsComerciales);
})

$(document).on("click", "#eliminarDoc", function () {
    const index = data.model.docsComerciales.findIndex(i => i === $(this).val());
    data.model.docsComerciales.splice(parseInt(index), 1);
    $('[id="' + $(this).val() + '"]').remove();

    if (data.model.docsComerciales.length === 0) {
        $('#noDocs').show()
    }

    console.log(data.model.docsComerciales);
})



$("#submit").click(function () {

    data.model.egreso.fecha = $('#fecha').val();
    data.model.egreso.idMedioDePago = parseInt($("input[id=medioDePago]").val());
    data.model.egreso.idPrestadorDeServicios = parseInt($("input[id=proveedor]").val());
    data.model.egreso.montoTotal = data.model.egreso.detalle.reduce((a, b) => a + b.valor * b.cant, 0);

    console.log(data);

    $.ajax({
        type: "POST",
        url: "/compra/egreso/add",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(data.model),
        crossDomain: true,
        success: function (data) {
            window.location.href = data;
        },
        error: function (err) {
            console.log(err)
        }
    })
})
