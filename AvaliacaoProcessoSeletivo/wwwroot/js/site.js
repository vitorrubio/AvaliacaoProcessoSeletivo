// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let _apiRoot = "https://localhost:44364/api/";
function sendAjax(url, metodo, options) {
    $.support.cors = true;
    options = options || {};

    return $.ajax({
        type: metodo,
        url: url,
        data: options.data,
        cache: options.cache === undefined ? false : options.cache,
        contentType: "application/json",
        context: options.context,
        success: (options.success === null || options.success === undefined) ? null : options.success,
        error: (options.error === null || options.error === undefined) ? null : options.error,
        complete: (options.complete === null || options.complete === undefined) ? null : options.complete,
        processData: (options.processData !== null && options.processData !== undefined) ? options.processData : true,
        beforeSend: function (xhr) {

            if (options && options.token) {
                xhr.setRequestHeader("Authorization", "Bearer " + options.token);
            }

            if (options.beforeSend) {
                options.beforeSend();
            }

        }
    })
        .done(function (data) {
            if (options && options.done)
                options.done(data);
        })
        .always(function () {


            if (options && options.always)
                options.always();
        })
        .fail(function (xhr, status, erro) {

            if (options && options.fail)
                options.fail(xhr, status, erro);

            console.log("Status do Erro: " + xhr.status + '\n' + "Descrição do Erro: " + JSON.stringify(xhr));
        });
}

function ajaxGet(url, options) {
    return sendAjax(url, "GET", options);
}

function ajaxPost(url, options) {
    return sendAjax(url, "POST", options);
}

function ajaxPut(url, options) {
    return sendAjax(url, "PUT", options);
}

function ajaxDelete(url, options) {
    return sendAjax(url, "DELETE", options);
}



function Services(url, opt) {

    this.Url = url;
    this.Opt = opt || {};

    this.get = function () {
        return ajaxGet(this.Url, this.Opt);
    };

    this.post = function (data) {
        if (data)
            this.Opt.data = data;
        return ajaxPost(this.Url, this.Opt);
    };

    this.put = function () {
        return ajaxPut(this.Url, this.Opt);
    };

    this.delete = function () {
        return ajaxDelete(this.Url, this.Opt);
    };
}

