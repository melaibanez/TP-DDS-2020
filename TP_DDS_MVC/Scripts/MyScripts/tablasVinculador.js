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
var data = {criterio: null}

$("#OVPE").click(function () {

    data.criterio = $(OVPE).val();
    
})

$("#vincular").click(function () {

    $.ajax({
        type: "POST",
        url: "/vinculador",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(data.criterio),
        crossDomain: true,
        success: function (data) {
            window.location.href = data;
        },
        error: function (err) {
            console.log(err)
        }
    })
})

