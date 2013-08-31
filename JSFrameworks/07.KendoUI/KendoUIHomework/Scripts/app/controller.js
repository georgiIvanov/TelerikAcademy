/// <reference path="../libs/class.js" />
/// <reference path="persister.js" />
/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../kendoUI/kendo.web.js" />

window.controller = (function () {

    var wrapper = $('#wrapper');

    function renderLoginRegister() {
        $('#user-menu').remove();
        var template = $('#login-register-template').html();

        wrapper.html(template);

        $('#login-register').kendoValidator();
    }

    function renderAbout() {
        var template = $('#about-template').html();
        wrapper.html(template);
    }

    function renderHome() {
        $('#user-menu').remove();
        $('#login-register').remove();
        var template = $('#user-menu-template').html();
        wrapper.before(template);
        kendo.bind($('#user-menu'), persister.userViewModel);
        wrapper.html($('#banking-operations-template').html());

        $('#banking-operations').kendoValidator();

        var a = persister.transactionsViewModel.data;

        var dta = [{ name: "lol", age: 7 }, { name: "fu", age: 5 }];

        var kendoDS = new kendo.data.DataSource({
            data: persister.transactionsViewModel.data
        });

        kendoDS.read();


        $('#transactions-operations').kendoGrid({
            dataSource: kendoDS,
            columns:[
                {
                    field: 'CreatedAt',
                    title: 'Transacted At'
                },
                {
                    field: 'moneyTransacted',
                    title: 'Money transfered'
                },
                {
                    field: 'Id',
                    title: 'Transaction Id'
                }
            ]
        });

    }
    
    function preformLogin() {


        if (!persister.user.isUserLoggedIn()) {
            controller.renderLoginRegister();
        }
        else {

            persister.user.getRestOfUserInformation(function (data) {

                renderHome();
            }, function (err) {
                controller.renderLoginRegister();
            });
        }

    }

    function getValidator() {
        return this.validator;
    }


    function registerUIEvents() {
        var self = this;

        wrapper.on("click", "#register-button", function () {
            var username = $('#username-field').val();
            var password = $('#password-field').val();
            password = CryptoJS.SHA1(password).toString();
            persister.user.registerUser(username, password, function (data) {
                $('#login-register').remove();
                console.log(data);
            }, function (err) {
                console.log(err);
            });
        });

        wrapper.on("click", "#login-button", function () {
            var username = $('#username-field').val();
            var password = $('#password-field').val();
            password = CryptoJS.SHA1(password).toString();
            persister.user.loginUser(username, password, function (data) {
                renderHome();
            }, function (err) {
                console.log(err);
            });
        });

        wrapper.on("click", "#logout", function () {
            persister.user.logoutUser(function () {
                renderLoginRegister();
            }, function () {
            });
        });

        wrapper.on("click", '#withdraw-money-button', function () {
            //persister.userViewModel.set("Balance", 10);

            if ($('#banking-operations').kendoValidator().data('kendoValidator').validate()) {
                var money = $('#money-field').val();
                persister.user.sendTransaction(-money, function (data) {
                    $('#money-field').val("");
                }, function (err) {

                });
            }
        });

        wrapper.on("click", '#deposit-money-button', function () {

            if ($('#banking-operations').kendoValidator().data('kendoValidator').validate()) {
                var money = parseFloat($('#money-field').val());
                persister.user.sendTransaction(money, function (data) {
                    $('#money-field').val("");
                }, function (err) {

                });
            }
        });
    }

    return {
        renderLoginRegister: renderLoginRegister,
        renderAbout: renderAbout,
        registerUIEvents: registerUIEvents,
        preformLogin: preformLogin
    }
})();