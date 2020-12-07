﻿var data = {
    model: {
        descripcion: null,
        monto: null,
        fechaDesde: null,
        fechaHasta: null,
        entidad: null,
        egresosAsociados: []
    }
}


$("#submit").click(function () {

    data.model.descripcion = $(descripcion).val();
    data.model.monto = $(monto).val();
    data.model.fechaDesde = $(fechaInicio).val();
    data.model.fechaHasta = $(fechaFin).val();
    data.model.egresosAsociados = $("input[id=]")
  

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