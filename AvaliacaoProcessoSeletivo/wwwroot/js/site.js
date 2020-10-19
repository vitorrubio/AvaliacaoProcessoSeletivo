// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let _apiRoot = "https://localhost:5001/api/";

function Services(url, opt) {


    let _ajaxReq = function (url, metodo, options) {
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
        });
    }


    this.Url = url;
    this.Opt = opt || {};

    this.get = function () {
        return _ajaxReq(this.Url, "GET", this.Opt);
    };

    this.post = function (data) {
        if (data)
            this.Opt.data = data;
        return _ajaxReq(this.Url, "POST",this.Opt);
    };

    this.put = function () {
        return _ajaxReq(this.Url, "PUT", this.Opt);
    };

    this.delete = function () {
        return _ajaxReq(this.Url, "DELETE", this.Opt);
    };
}

