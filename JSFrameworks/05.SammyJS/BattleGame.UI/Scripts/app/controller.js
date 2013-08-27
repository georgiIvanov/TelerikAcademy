/// <reference path="../libs/class.js" />
/// <reference path="../libs/http-requester.js" />
/// <reference path="../libs/sha1.js" />
/// <reference path="../libs/mustache.js" />
/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="persister.js" />
/// <reference path="../libs/underscore.js" />

define(["class", "jquery", "mustache", "persisters", "sammy", "ui"], function (Class, $, mustache, persisters, sammy, ui) {
    var controllers = (function () {
        var rootUrl = "http://localhost:22954/api/";

        var Controller = Class.create({
            init: function () {
                this.persister = persisters.get(rootUrl);
                this.selector = "";
            },
            loadUI:
                function (selector) {
                    this.selector = selector;
                    if (this.persister.isUserLoggedIn()) {
                        this.loadGameUI(selector);
                    }
                    else {
                        this.loadLoginFormUI(selector);
                    }

                    this.attachUIEventHandlers(selector);
                },
            loadLoginFormUI:
                function (selector) {
                    
                    var askForCredentials = mustache.render($("#loginOrRegister")[0].innerHTML, "");
                    // type="password"
                    $(selector).html(askForCredentials);
                },
            loadGameUI:
                function (selector) {
                    var html = ui.gameUI(this.persister);


                    $(selector).html(html);

                    this.persister.user.scores(function (data) {
                        ui.userScore(data);
                    }, function (err) {
                        //alert(err.responseText);
                    });

                    
                },
            attachUIEventHandlers: function (selector) {
                var wrapper = $(selector);
                var self = this;

                wrapper.on("click", "#loginForm", function () {
                    var loginForm = mustache.render($("#login-template")[0].innerHTML, "");
                    wrapper.html(loginForm);
                });

                wrapper.on("click", "#registerForm", function () {
                    var loginForm = mustache.render($("#register-template")[0].innerHTML, "");
                    wrapper.html(loginForm);
                });

                wrapper.on("click", '#btn-login', function () {
                    var user = {
                        username: $(selector + " #tb-login-username").val(),
                        password: $(selector + " #tb-login-password").val(),
                    }

                    self.persister.user.login(user, function () {
                        self.loadGameUI(selector);
                    }, function () {
                        wrapper.html("Please input username and password");
                    });
                    return false;
                });

                wrapper.on("click", '#btn-register', function () {
                    var user = {
                        username: $(selector + " #tb-register-username").val(),
                        nickname: $(selector + " #tb-register-nickname").val(),
                        password: $(selector + " #tb-register-password").val(),
                    }
                    self.persister.user.register(user, function (data) {
                        //alert(data);
                    }, function (err) {
                        //alert(err.responseText);
                    });

                    return false;
                });

                wrapper.on("click", '#btn-logout', function () {
                    self.persister.user.logout(function () {
                        self.loadUI(selector);
                    }, function (err) {
                        self.persister.clearUserData();
                    });
                });

                wrapper.on("click", "#user-nickname a", function () {
                    $("#all-scores").toggle();
                });

                wrapper.on("click", "#open-games-container a", function () {
                    $('#game-join-input').remove();
                    var html =
                        '<div id="game-join-input">' +
                        'Password: <input type="text" id="tb-game-pass"/>' +
                        '<button id="btn-join-game">Enter</button>' +
                        '</div>';
                    $(this).after(html);
                });

                wrapper.on("click", "#btn-join-game", function () {

                    var game = {
                        id: $(this).parents("li").first().data("game-id"),
                    }
                    var password = $('#tb-game-pass').val();

                    if (password) {
                        game.password = password;
                    }

                    self.persister.game.join(game, function (data) {

                    }, function (err) {
                        alert(err.responseText);
                    });
                });

                wrapper.on("click", "#btn-create-game", function () {

                    var game = {
                        title: $('#tb-create-title').val(),
                    }
                    var password = $('#tb-create-password').val();

                    if (password) {
                        game.password = password;
                    }

                    self.persister.game.create(game, function (data) {

                    }, function (err) {
                        alert(err.responseText);
                    });
                });

                wrapper.on("click", "#active-games-container a", function () {
                    $('#game-input').remove();
                    $('#game-status').remove();
                    var html = "";


                    var li = $(this).parent();
                    if (li.data("game-status") == "in-progress") {
                        html += '<div id="game-input">' +
                        'ID: <input type="text" id="tb-id-move"/>' + '<br/>' +
                        'Y X: <input type="text" id="tb-position-move"/>' + '<br/>' +
                        '<button id="btn-make-move">Move</button>' +
                        '<button id="btn-make-attack">Attack</button>' +
                        '<button id="btn-make-defend">Defend</button>' +
                        '</div>';
                        html += '<div id="game-status">';
                        self.persister.game.field(li.data("gameId"), function (data) {
                            //alert(data);
                            var html = $("#game-status");
                            var string = "In turn: " + ((data.inTurn == "blue") ? data.blue.nickname : data.red.nickname);

                            string += '<div>' + data.turn + ' turn';
                            string += ui.buildField(data);

                            string += '</div>';

                            html.append(string);

                            self.persister.messages.unread(function (data) {
                                var text = "";
                                for (var i = 0; i < data.length; i++) {
                                    text += '<p class="gameId-msg">' + data[i].gameId + '</p>';
                                    text += '<p class="gameTitle-msg">' + data[i].gameTitle + ' type:' + data[i].type + '</p>';
                                    text += '<p class="gameText-msg">' + data[i].text + '</p><br/>';
                                }
                                if (text != "") {
                                    $("#messagesWrapper #messages").html(text);
                                }
                            }, function (err) {
                                alert(err.responseText);
                            });

                        }, function () {
                        });

                        html += '</div>';
                    } else {
                        html += '<div id="game-input">' +
                        '</div>';
                    }
                    li.after(html);
                });

                wrapper.on("click", "#btn-make-move", function () {
                    var coords = $("#tb-position-move").val().split(' ');

                    var pos = {
                        y: parseInt(coords[0]),
                        x: parseInt(coords[1])
                    };
                    var data = {
                        position: pos,
                        unitId: $("#tb-id-move").val()
                    }
                    var id = $(this).parent().prev().data("game-id");

                    self.persister.battle.move(id, data, function (data) {
                        //alert(data);
                    }, function (err) {
                        alert(err.responseText);
                    });
                });

                wrapper.on("click", "#btn-make-attack", function () {
                    var coords = $("#tb-position-move").val().split(' ');

                    var pos = {
                        y: parseInt(coords[0]),
                        x: parseInt(coords[1])
                    };
                    var data = {
                        position: pos,
                        unitId: $("#tb-id-move").val()
                    }
                    var id = $(this).parent().prev().data("game-id");

                    self.persister.battle.attack(id, data, function (data) {
                        //alert(data);
                    }, function (err) {
                        alert(err.responseText);
                    });
                });

                wrapper.on("click", "#btn-make-defend", function () {

                    var data = parseInt($("#tb-id-move").val());

                    var id = $(this).parent().prev().data("game-id");

                    self.persister.battle.defend(id, data, function (data) {
                        //alert(data);
                    }, function (err) {
                        alert(err.responseText);
                    });
                });

                wrapper.on("click", "#btn-start-game", function () {
                    var data = {
                        id: $(this).parent().data("game-id"),
                    }
                    self.persister.game.start(data, function (data) {
                        //alert(data);
                    }, function (err) {
                        alert(err.responseText);
                    });
                });

                $("#messagesWrapper").on("click", "#btn-all-messages", function () {

                    self.persister.messages.all(function (data) {
                        var text = "";
                        for (var i = 0; i < data.length; i++) {
                            text += '<p class="gameId-msg">' + data[i].gameId + '</p>';
                            text += '<p class="gameTitle-msg">' + data[i].gameTitle + ' type:' + data[i].type + '</p>';
                            text += '<p class="gameText-msg">' + data[i].text + '</p><br/>';
                        }
                        $("#messagesWrapper #messages").html(text);
                    }, function (err) {
                        alert(err.responseText);
                    });
                });

            }
        });



        return {
            get: function () {
                return new Controller();
            },
        }

    }());

    return controllers;
});