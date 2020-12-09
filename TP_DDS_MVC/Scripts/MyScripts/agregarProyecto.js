var data = {
    model: {
        propuesta: null,
        montoTotal: 0,
        limiteErogacion: null,
        cantidadPresupuestos: null,
        fechaEjecucion: null,
        fechaCierre: null
    }
}

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



