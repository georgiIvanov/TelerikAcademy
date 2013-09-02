/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/kendo.web.min.js" />
/// <reference path="../Scripts/app/data.js" />
/// <reference path="libs/kendo.web.min.intellisense.js" />
/// <reference path="app/views.js" />
/// <reference path="app/view-models.js" />

(function () {
    var appLayout = new kendo.Layout('<div id="user-content"></div><div id="main-content"></div>');

    var data = persisters.get("api/");

    vmFactory.setPersister(data);

    var router = new kendo.Router({
        routeMissing: function (ev) {
            alert("are you lost?");
        }
    });

    router.route("/", function () {
        router.navigate("/home");
    });

    router.route("/home", function () {
        viewsFactory.getCarsView()
        .then(function (carsViewHtml) {
            vmFactory.getCarsVM()
            .then(function (vm) {
                var view = new kendo.View(carsViewHtml, { model: vm });
                appLayout.showIn("#main-content", view);
            }, function (err) {
                console.log(err);
            });
        }, function (err) {
            console.log(err);
        });
    });


    router.route("/login", function () {
        $('#main-content').append('in login<br/>');
    });

    router.route("/cars", function () {
        $('#main-content').append('in cars<br/>');
    });

    router.route('/cars/filter', function () {
        $('#main-content').append('in cars - filter<br/>');
    });

    router.route('/cars/rented', function () {
        $('#main-content').append('in cars - rented<br/>');
    });

    router.route('/cars/page/:page/:count', function (page, count) {
        $('#main-content').append('in car pages' + page + count + '<br/>');
    });

    router.route('/stores', function () {
        $('#main-content').append('in stores<br/>');
    });

    $(function () {
        appLayout.render("#app");
        router.start();
        router.navigate("/home");
    });

})();