

function mysortTable() {
    var tables, rows, sorting, c, a, b, tblsort;
    tables = document.getElementById("sortingTable");
    sorting = true;
    while (sorting) {
        sorting = false;
        rows = tables.rows;
        for (c = 1; c < (rows.length - 1); c++) {
            tblsort = false;
            a = rows[c].getElementsByTagName("TD")[0];
            b = rows[c + 1].getElementsByTagName("TD")[0];
            if (Number(a.innerHTML) > Number(b.innerHTML)) {
                tblsort = true;
                break;
            }
        }
        if (tblsort) {
            rows[c].parentNode.insertBefore(rows[c + 1], rows[c]);
            sorting = true;
        }
    }
}
function mysortTable2() {
    var tables, rows, sorting, c, a, b, tblsort;
    tables = document.getElementById("sortingTable2");
    sorting = true;
    while (sorting) {
        sorting = false;
        rows = tables.rows;
        for (c = 1; c < (rows.length - 1); c++) {
            tblsort = false;
            a = rows[c].getElementsByTagName("TD")[0];
            b = rows[c + 1].getElementsByTagName("TD")[0];
            if (Number(a.innerHTML) > Number(b.innerHTML)) {
                tblsort = true;
                break;
            }
        }
        if (tblsort) {
            rows[c].parentNode.insertBefore(rows[c + 1], rows[c]);
            sorting = true;
        }
    }
}

var criterio;

$("#ovpe").click(function () {

      criterio = parseInt($(ovpe).val());
      console.log(criterio);

})

$("#ovpi").click(function () {

    criterio = parseInt($(ovpi).val());
    console.log(criterio);

})

$("#of").click(function () {

    criterio = parseInt($(of).val());
    console.log(criterio);
})

$("#vincular").click(function () {

    var json = {}
    json["idCriterio"] = criterio;

    $.ajax({
        type: "POST",
        url: "/vinculador",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(json),
        crossDomain: true,
         success: function (data) {
             window.location.href = data;
         },
        error: function (err) {
            console.log(err)
        }
    })
});

