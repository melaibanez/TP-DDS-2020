var data = {
    model: {
        compra: {
            descripcion: null,
            cantMinimaPresupuestos: 0,
            compraValidada: false,
            egreso: {
                fechaEgreso: null,
                idMedioDePago: null,
                montoTotal: 0,
                descripcion: null,
                idMoneda: null;
                idPrestadorDeServicios: null,
                detalle: []

            },
            revisores: []
        }

    }
}

$(document).ready(function () {
    $('#error').hide()
});

$("#agregarUsu").click(function () {
    $('#noUsu').hide()

    data.model.compra.revisores.push({
        idUsuario:parseInt($("#revisor").val())
    })

    $("#listaUsu").append('<li id="u' + $("#revisor").val() + '" class="list-group-item">' +
        $("#revisor").val() + '&nbsp;-&nbsp;' +
        '<button id="eliminar" value="u' + $("#revisor").val() + '" class="btn btn-outline-danger btn-sm" aria-label="Close">Eliminar</button ></li >');

    $("#revisor").val('');

})

$(document).on("click", "#eliminar", function () {
    const index = data.model.revisores.findIndex(i => "u" + i.idUsuario === $(this).val());
    data.model.revisores.splice(parseInt(index), 1);
    $('[id="' + $(this).val() + '"]').remove();

    if (data.model.revisores.length === 0) {
        $('#noUsu').show()
    }

})


$("#agregarItem").click(function () {
    $('#noItems').hide()

    data.model.compra.egreso.detalle.push({
        cant: $("#cantItem").val(),
        descripcion: $("#descripcionItem").val(),
        valor: $("#valorItem").val(),
        categorias: $('#categoria').val().map(idCat => {
            return {
                idCategoria: parseInt(idCat)
            }
        })
    })

    //data.model.compra.egreso.categorias.push($('#categoria').val())

    $("#listaItems").append('<li id="' + $("#descripcionItem").val() + '" class="list-group-item">' +
        $("#descripcionItem").val() + '&nbsp;-&nbsp;' +
        '$' + $("#valorItem").val() + '&nbsp;-&nbsp;' +
        $("#cantItem").val() + ' unidades&nbsp;' +
        '<button id="eliminarItem" value="' + $("#descripcionItem").val() + '" class="btn btn-outline-danger btn-sm" aria-label="Close">Eliminar</button ></li >');

    $("#descripcionItem").val('');
    $("#valorItem").val(1);
    $("#cantItem").val(1);

    console.log(data.model.compra.egreso.detalle);
})

$(document).on("click", "#eliminarItem", function () {
    const index = data.model.compra.egreso.detalle.findIndex(i => i.descripcion === $(this).val());
    data.model.compra.egreso.detalle.splice(parseInt(index), 1);
    //data.model.itemsCategorias.splice(parseInt(index), 1);
    $('[id="' + $(this).val() + '"]').remove();

    if (data.model.compra.egreso.detalle.length === 0) {
        $('#noItems').show()
    }

    console.log(data.model.compra.egreso.detalle);
})


$("#submit").click(function () {


    data.model.compra.egreso.fechaEgreso = $('#fecha').val();
    data.model.compra.egreso.idMedioDePago = parseInt($("input[id=medioDePago]").val());
    data.model.compra.egreso.idPrestadorDeServicios = parseInt($("input[id=proveedor]").val());
    data.model.compra.egreso.montoTotal = data.model.compra.egreso.detalle.reduce((a, b) => a + b.valor * b.cant, 0);
    data.model.compra.descripcion = $('#descripcion').val();
    data.model.compra.cantMinimaPresupuestos = $('#cantMinPres').val();
    data.model.compra.egreso.idMoneda = $('#moneda').val();
    data.model.compra.egreso.descripcion = $('#descripcion').val();


    $.ajax({
        type: "POST",
        url: "/compra/add",
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
