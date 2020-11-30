var data = {
    model: {
        nroIdentificacion: null,
        tipo_enlace: "Presupuesto",
        idEgreso: null,
        idMedioDePago: null,
        idPrestadorDeServicios: null,
        montoTotal: 0,
        idCompra: null,
        items: []
    }
}


$("#agregarItem").click(function () {
    $('#noItems').hide()
    
    data.model.items.push({
        cant: $("#cantItem").val(),
        descripcion: $("#descripcionItem").val(),
        valor: $("#valorItem").val(),
        
    })

    $("#listaItems").append('<li id="' + $("#descripcionItem").val() + '" class="list-group-item">' +
        $("#descripcionItem").val() + '&nbsp;-&nbsp;' +
        '$' + $("#valorItem").val() + '&nbsp;-&nbsp;' +
        $("#cantItem").val() + ' unidades&nbsp;' +
        '<button id="eliminar" value="' + $("#descripcionItem").val() + '" class="btn btn-outline-danger btn-sm" aria-label="Close">Eliminar</button ></li >');

    $("#descripcionItem").val('');
    $("#valorItem").val(1);
    $("#cantItem").val(1);

    //idItem++;

    console.log(data.model.items);
})

$(document).on("click", "#eliminar", function () {
    const index = data.model.items.findIndex(i => i.descripcion === $(this).val());
    data.model.items.splice(parseInt(index), 1);
    $('[id="' + $(this).val() + '"]').remove();

    if (data.model.items.length === 0) {
        $('#noItems').show()
    }

    console.log(data.model.items);
})



$("#submit").click(function () {

    data.model.nroIdentificacion = $(nroIdentificacion).val();
    data.model.idMedioDePago = parseInt($("input[id=medioDePago]").val());
    data.model.idPrestadorDeServicios = parseInt($("input[id=proveedor]").val());
    data.model.montoTotal = data.model.items.reduce((a, b) => a + b.valor * b.cant, 0);

    console.log(data.model);

    $.ajax({
        type: "POST",
        url: "/compra/presupuesto/add",
        contentType: "application/json; charset=utf-8",
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




