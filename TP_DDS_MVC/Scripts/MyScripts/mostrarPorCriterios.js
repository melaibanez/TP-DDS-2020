$("#categoria").on("change", function () {
    var value = this.value.toLowerCase().trim();
    $("#listaItems li").show().filter(function () {
        return $(this).text().toLowerCase().trim().indexOf(value) == -1;
    }).hide();
});