$(".ddlMarca").change(function () {

    $.ajax({
        type: "POST",
        url: "CarregarModelo",
        dataType: "json",
        data: "IdMarca=" + $(".ddlMarca").val(),
        success: function (dados) {
            $("#Modelo").empty();
            for (var i = 0; i < dados.length; i++) {
                $("#Modelo").append("<option value='" + dados[i].Id + "'> " + dados[i].Name + "</option>");
            }
        }
    })
});

$("#Modelo").change(function () {

    $.ajax({
        type: "POST",
        url: "CarregarVersao",
        dataType: "json",
        data: "IdModelo=" + $("#Modelo").val(),
        success: function (dados) {

            $("#Versao").empty();
            for (var i = 0; i < dados.length; i++) {
                $("#Versao").append("<option value='" + dados[i].Id + "'> " + dados[i].Name + "</option>");
            }
        }
    })
});









    