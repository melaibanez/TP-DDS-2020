var data = {
    model: {
        documentoComercial: {
            nroIdentificacion: null,
            tipo_enlace: null,
            idEgreso: null
        },
        presupuesto: {
            nroIdentificacion: null,
            tipo_enlace: null,
            idEgreso: null,
            idMedioDePago: null,
            idPrestadorDeServicios: null,
            montoTotal: 0,
            idCompra: null,
            idProyecto: null,
            items: []
        },
        setEgreso: false     
    }
}

$("#tipoDoc").change(function () {

    if ($(this).val() === "DocumentoComercial") {
        $("#formDoc").show()
        $("#formPresupuesto").hide()
        $('#tipo_enlace').val("")
    }
    else if ($(this).val() === "Presupuesto") {
        $("#formPresupuesto").show()
        $("#formDoc").hide()
        $('#tipo_enlace').val("Presupuesto")
    }
});

$("#agregarItem").click(function () {
    $('#noItems').hide()
    
    data.model.presupuesto.items.push({
        cant: $("#cantItem").val(),
        descripcion: $("#descripcionItem").val(),
        valor: $("#valorItem").val(),
        categorias: $('#categoria').val().map(idCat => {
            return {
                idCategoria: parseInt(idCat)
            }
        })
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

    console.log(data.model.presupuesto.items);
})

$(document).on("click", "#eliminar", function () {
    const index = data.model.presupuesto.items.findIndex(i => i.descripcion === $(this).val());
    data.model.presupuesto.items.splice(parseInt(index), 1);
    $('[id="' + $(this).val() + '"]').remove();

    if (data.model.presupuesto.items.length === 0) {
        $('#noItems').show()
    }

    console.log(data.model.presupuesto.items);
})



$("#submit").click(function () {

    if ($('#tipoDoc').val() == "Presupuesto") {
        data.model.presupuesto.tipo_enlace = "Presupuesto";
        data.model.documentoComercial = null;
        data.model.presupuesto.nroIdentificacion = $('#nroIdentificacion').val();
        data.model.presupuesto.idMedioDePago = parseInt($("input[id=medioDePago]").val());
        data.model.presupuesto.idPrestadorDeServicios = parseInt($("input[id=proveedor]").val());
        data.model.presupuesto.montoTotal = data.model.presupuesto.items.reduce((a, b) => a + b.valor * b.cant, 0);
        data.model.presupuesto.idCompra = $('#compra').val();
        if ($('#checkEgreso').is(":checked")) {
            data.model.setEgreso = true;
        }
    } else {
        data.model.documentoComercial.tipo_enlace = "Documento Comercial";
        data.model.presupuesto = null;
        data.model.documentoComercial.nroIdentificacion = $('#nroIdentificacion').val();
        data.model.documentoComercial.idEgreso = $('#asociarEgreso').val();

    }

    console.log(data.model);

    $.ajax({
        type: "POST",
        url: "/presupuesto/add",
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




