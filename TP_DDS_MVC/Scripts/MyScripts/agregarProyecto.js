var data = {
    model: {
        propuesta: null,
        montoTotal: 0,
        ingresos: [],
        limiteErogacion: null,
        cantidadPresupuestos: null,
        fechaEjecucion: null,
        fechaCierre: null,
        presupuestos: []
    }
}


$("#agregarIng").click(function () {
    $('#noIng').hide()

    model.ingresos.push({
        idIngreso: $("#ingreso").val()
    })

    $("#listaIng").append('<li id="i' + $("#ingreso").val() + '" class="list-group-item">' +
        $("#ingreso").val() + '&nbsp;-&nbsp;'+
        '<button id="eliminar" value="i' + $("#ingreso").val() + '" class="btn btn-outline-danger btn-sm" aria-label="Close">Eliminar</button ></li >');

    $("#ingreso").val('');

})

$(document).on("click", "#eliminar", function () {
    const index = data.model.ingresos.findIndex(i => "i"+i.idIngreso === $(this).val());
    data.model.ingresos.splice(parseInt(index), 1);
    $('[id="i' + $(this).val() + '"]').remove();

    if (data.model.ingresos.length === 0) {
        $('#noItems').show()
    }

})


$("#agregarDoc").click(function () {
    $('#noDocs').hide()

    data.model.presupuestos.push({
        idDocComercial: $('#documento').val()
    })

    $("#listaDocs").append('<li id="d' + $("#documento").val() + '" class="list-group-item">' +
        $("#documento").val() + '&nbsp;-&nbsp;' +
        '<button id="eliminarDoc" value="d' + $("#documento").val() + '" class="btn btn-outline-danger btn-sm" aria-label="Close">Eliminar</button ></li >');

    $("#documento").val('');

    console.log(data.model.docsComerciales);
})

$(document).on("click", "#eliminarDoc", function () {
    const index = data.model.presupuestos.findIndex(i => "d" + i.idDocComercial === $(this).val());
    data.model.presupuestos.splice(parseInt(index), 1);
    $('[id="d' + $(this).val() + '"]').remove();

    if (data.model.presupuestos.length === 0) {
        $('#noDocs').show()
    }

})



$("#submit").click(function () {

    data.model.propuesta = $("#propuesta").val();
    data.model.cantidadPresupuestos = $("#cantPresupuestos").val();
    data.model.limiteErogacion = $("#limiteErogacion").val();
    data.model.fechaCierre = $("#fechaCierre").val();
    data.model.fechaEjecucion = $("#fechaEjecucion").val();


    $.ajax({
        type: "POST",
        url: "/proyecto/add",
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



