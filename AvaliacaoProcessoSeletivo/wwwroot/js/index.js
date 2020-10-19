$(function () {
    $("#btnSalvar").on("click", function () {
        var conta = {
            Id: $("#Id").val() == null || $("#Id").val() == "" ? 0 : parseInt($("#Id").val()),
            Nome: $("#Nome").val(),
            Descricao: $("#Descricao").val(),
            DataCriacao: new Date() //data original
        };

        //conta.DataCriacao = new Date(Date.UTC(
        //    conta.DataCriacao.getFullYear(),
        //    conta.DataCriacao.getMonth() + 1,
        //    conta.DataCriacao.getDate(),
        //    conta.DataCriacao.getHours(),
        //    conta.DataCriacao.getMinutes(),
        //    conta.DataCriacao.getSeconds()
        //));

        moment.locale("pt-BR");
        //conta.DataCriacao = moment(conta.DataCriacao).format("YYYY-MM-DDTHH:mm:ss");
        conta.DataCriacao = moment(conta.DataCriacao).format();

        let svc = new Services(_apiRoot + "conta");


        svc.post(JSON.stringify(conta))
            .done(function (result) {
                console.log("done");
                $("#Id").val(result.Id)
            })
            .fail(function (xhr, status, erro) {
                console.log(erro);
            });

    });
});