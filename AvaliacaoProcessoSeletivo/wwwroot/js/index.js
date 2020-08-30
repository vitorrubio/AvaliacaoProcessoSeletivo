$(function () {
    $("#btnSalvar").on("click", function () {
        var conta = {
            Id: $("#Id").val(),
            Nome: $("#Nome").val(),
            Descricao: $("#Descricao").val()
        };

        let svc = new Services(_apiRoot + "/conta", {
            success: function (retorno) {
                $("#Id").val(retorno.Id)
                alert("Sucesso");
            },
            error: function (xhr, status, erro) {
                console.log(erro);
                alert("Nem");
            }
        });

        svc.post(conta);

    });
});