$(function () {
    $("#btnSalvar").on("click", function () {
        var conta = {
            Id: $("#Id").val() == null || $("#Id").val() == "" ? 0 : parseInt($("#Id").val()),
            Nome: $("#Nome").val(),
            Descricao: $("#Descricao").val()
        };

        let svc = new Services(_apiRoot + "conta");


        svc.post(JSON.stringify(conta))
            .done(function (result) {
                console.log("done");
                $("#Id").val(result.Id)
                alert("Sucesso");
            })
            .fail(function (xhr, status, erro) {
                console.log(erro);
                alert("Nem");
            });

    });
});