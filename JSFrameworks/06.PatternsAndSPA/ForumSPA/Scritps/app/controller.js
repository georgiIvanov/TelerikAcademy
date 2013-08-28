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
            if ($('#user-menubar').length == 0) {
                createUserMenuBar($(wrapperId));
                createPostBar($(wrapperId));
            }
        }
        else {
            var loginTemplate = Mustache.render($("#login-register-template").html());
            $(wrapperId).html(loginTemplate);
        }
    }

    function renderPostById() {
        var tokens = window.location.href.split('/');

        persister.getPostById(tokens[tokens.length - 1], function (data) {
            createPosts(data);
        }, function (err) {

        });
    }

    function searchByTags() {
        var tokens = window.location.href.split('=')[1].split(',');

        persister.searchByTags(tokens, function (data) {
            createPosts(data);
        }, function (err) {

        });
    }

    function createPosts(data) {
        if (data.result.length !== void 0) {
            for (var i = 0; i < data.result.length; i++) {
                if (data.result[i].ArrayOfTags !== void 0) {
                    var splitTags = data.result[i].ArrayOfTags;
                    data.result[i].ArrayOfTags = [];
                    for (var j = 0; j < splitTags.length; j++) {
                        data.result[i].ArrayOfTags.push({
                            tag: splitTags[j]
                        });
                    }
                }
            }
        }
        else {
            if (data.result.AllTags !== void 0) {
                var splitTags = data.result.AllTags.split(' ');
                data.result.AllTags = [];
                for (var j = 0; j < splitTags.length; j++) {
                    data.result.AllTags.push({
                        tag: splitTags[j]
                    });
                }
            }
        }
        var postsTemplate = Mustache.render($("#posts-template").html(), data);
        $(wrapperId).html(postsTemplate);
    }

    function renderPosts() {
        persister.getPosts(function (data) {
            createPosts(data);
        }, function (err) {
        });
    }

    function createUserMenuBar(wrapper) {
        var obj = { nickname: persister.nickname() }
        var userTemplate = Mustache.render($('#user-menubar-template').html(), obj);
        wrapper.append(userTemplate);
    }

    function createPostsDiv(wrapper) {
        var posts = Mustache.render($('#posts-template').html());

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
            var title = $('#post-title').val();
            var content = $('#post-content').val();
            var tags = $("#post-tags").val().split(' ', 10);
            persister.submitPost(title, content, tags, function (data) {
                $('#post-title').val("");
                $('#post-content').val("");
                $("#post-tags").val("");
            }, function (err) {
                alert(err);
            });
        });
    }

    return {
        renderHomePage: renderHomePage,
        renderPosts: renderPosts,
        registerEvents: registerEvents,
        renderPostById: renderPostById,
        searchByTags: searchByTags,
    };
})();