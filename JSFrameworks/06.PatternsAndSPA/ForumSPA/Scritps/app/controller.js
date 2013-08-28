/// <reference path="../libs/mustache.js" />
/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/sha1.js" />
/// <reference path="../everlive-SDK/everlive.all.js" />
/// <reference path="../everlive-SDK/everlive.js" />
/// <reference path="../everlive-SDK/jstz.js" />
/// <reference path="../everlive-SDK/kendo.data.everlive.js" />
/// <reference path="../everlive-SDK/reqwest.js" />
/// <reference path="../everlive-SDK/rsvp.js" />
/// <reference path="persister.js" />
/// <reference path="../everlive-SDK/underscore.js" />

var controller = (function () {
    var wrapperId = "#wrapper";



    function renderHomePage() {
        if (persister.isUserLoggedIn()) {
            createUserMenuBar($(wrapperId));
            createPostBar($(wrapperId));
        }
        else {
            var loginTemplate = Mustache.render($("#login-register-template").html());
            $(wrapperId).html(loginTemplate);
        }
    }

    function createUserMenuBar(wrapper) {
        var obj = { nickname: persister.nickname() }
        var userTemplate = Mustache.render($('#user-menubar-template').html(), obj);
        wrapper.append(userTemplate);
    }

    function createPostBar(wrapper) {
        var userTemplate = Mustache.render($('#submit-post-template').html());
        wrapper.append(userTemplate);
    }

    function registerEvents() {
        var self = this;
        var wrapper = $(wrapperId);

        wrapper.on("click", "#login-button", function () {
            var username = $('#username-field').val();
            var password = $('#password-field').val();
            password = CryptoJS.SHA1(username + password).toString();
            persister.loginUser(username, password, function (data) {
                $('#login-register-form').remove();
                createUserMenuBar(wrapper);
                createPostBar(wrapper);

            }, function (err) {
                alert(err.message);
            });
        });

        wrapper.on("click", "#register-button", function () {
            var username = $('#username-field').val();
            var password = $('#password-field').val();
            password = CryptoJS.SHA1(username + password).toString();
            persister.registerUser(username, password, function (data) {
                $('#login-register-form').remove();
                createUserMenuBar(wrapper);
                createPostBar(wrapper);

            }, function (err) {
                alert(err.message);
            });
        });

        wrapper.on("click", "#logout-user", function () {
            persister.clearUserData();
            $('#user-menubar').remove();
            $('#submit-post').remove();
        });

        wrapper.on("click", "#submit-post-button", function () {

        });
    }

    return {
        renderHomePage: renderHomePage,
        registerEvents: registerEvents,
    };
})();