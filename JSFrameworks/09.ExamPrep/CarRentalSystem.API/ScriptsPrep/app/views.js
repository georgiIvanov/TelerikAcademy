/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/rsvp.min.js" />

window.viewsFactory = (function () {
    var rootUrl = "ScriptsPrep/partials/";

    var templates = {};

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name])
            }
            else {
                $.ajax({
                    url: rootUrl + name + ".html",
                    type: "GET",
                    success: function (templateHtml) {
                        templates[name] = templateHtml;
                        resolve(templateHtml);
                    },
                    error: function (err) {
                        reject(err);
                    }
                });
            }
        });

        return promise;
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getCarsView() {
        return getTemplate("cars");
    }

    return {
        getLoginView: getLoginView,
        getCarsView: getCarsView
    }

})();