/// <reference path="kendoUI/kendo.web.js" />
/// <reference path="app/controller.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="everlive/everlive.js" />
/// <reference path="app/persister.js" />

(function () {
    var router = new kendo.Router();
    
    controller.registerUIEvents();

    router.route("/", function () {
        router.navigate("/home");
        
    });

    router.route("/home", function () {
        controller.preformLogin()
        
    });

    router.route("/about", function () {
        controller.renderAbout();
        console.log(persister.user.username());
    });

    $(function () {
        router.start();
        router.navigate("/home");
    });

})();