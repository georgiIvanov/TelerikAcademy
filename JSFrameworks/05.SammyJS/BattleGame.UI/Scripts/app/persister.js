/// <reference path="../libs/class.js" />
/// <reference path="../libs/http-requester.js" />
/// <reference path="../libs/sha1.js" />


define(["class", "http-requester", "sha1"], function (Class, httpRequester, CryptoJS) {
    var persisters = (function () {

        var nickname = localStorage.getItem("nickname");
        var sessionkey = localStorage.getItem("sessionKey");

        function saveUserData(userData) {
            localStorage.setItem("nickname", userData.nickname);
            localStorage.setItem("sessionkey", userData.sessionKey);
            nickname = userData.nickname;
            sessionkey = userData.sessionKey;
        }

        function clearUserData() {
            localStorage.removeItem("nickname");
            localStorage.removeItem("sessionkey");
            nickname = "";
            sessionkey = "";
        }

        var MainPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl;
                this.user = new UserPersister(this.rootUrl);
                this.game = new GamePersister(this.rootUrl);
                this.battle = new BattlePersister(this.rootUrl);
                this.messages = new MessagesPersister(this.rootUrl);
            },
            isUserLoggedIn: function () {
                nickname = localStorage["nickname"];
                sessionkey = localStorage["sessionkey"];
                var isLoggedIn = nickname != "" && nickname != null; //sessionkey != "";
                isLoggedIn = sessionkey != "undefined" && sessionkey != null && sessionkey != "";
                return isLoggedIn;
            },
            nickname: function () {
                return nickname;
            }
        });

        var UserPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl + "user/";
            },
            login: function (user, success, error) {
                var url = this.rootUrl + "login";
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };

                httpRequester.postJSON(url, userData,
                    function (data) {
                        saveUserData(data);
                        success(data);
                    }, error);

            },
            register: function (user, success, error) {
                var url = this.rootUrl + "register";
                var userData = {
                    username: user.username,
                    nickname: user.nickname,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                }

                httpRequester.postJSON(url, userData, function (data) {
                    saveUserData(data);
                    success(data);
                }, error);
            },
            logout: function (success, error) {
                //api/user/logout/"sessionkey"
                var url = this.rootUrl + "logout/" + sessionkey;
                httpRequester.putJSON(url, function () {
                    clearUserData();
                    success();
                }, function () {
                });
            },
            scores: function (success, error) {
                var url = this.rootUrl + "scores/" + sessionkey;
                httpRequester.getJSON(url, success, error);
            }
        });

        var GamePersister = Class.create({
            init: function (url) {
                this.rootUrl = url + "game/";

            },
            create: function (game, success, error) {
                var gameData = {
                    title: game.title,
                };
                if (game.password) {
                    gameData.password = CryptoJS.SHA1(game.password.toString());
                }

                var url = this.rootUrl + "create/" + sessionkey;
                httpRequester.postJSON(url, gameData, success, error);
            },
            join: function (game, success, error) {

                var gameData = {
                    id: game.id,
                };
                if (game.password) {
                    gameData.password = CryptoJS.SHA1(game.password.toString());
                }

                var url = this.rootUrl + "join/" + sessionkey;
                httpRequester.postJSON(url, gameData, success, error);
            },
            start: function (gameId, success, error) {
                var url = this.rootUrl + gameId.id + "/start/" + sessionkey;
                httpRequester.getJSON(url, success, error);
            },
            myActive: function (success, error) {
                var url = this.rootUrl + "my-active/" + sessionkey;
                httpRequester.getJSON(url, success, error);
            },
            open: function (success, error) {
                var url = this.rootUrl + "open/" + sessionkey;
                httpRequester.getJSON(url, success, error);
            },
            field: function (id, success, error) {
                var url = this.rootUrl + id + "/field/" + sessionkey;
                httpRequester.getJSON(url, success, error);
            }
        });

        var BattlePersister = Class.create({
            init: function (url) {
                this.rootUrl = url + "battle/";
            },
            move: function (id, data, success, error) {
                var url = this.rootUrl + id + "/move/" + sessionkey;
                httpRequester.postJSON(url, data, success, error);
            },
            attack: function (id, data, success, error) {
                var url = this.rootUrl + id + "/attack/" + sessionkey;
                httpRequester.postJSON(url, data, success, error);
            },
            defend: function (id, data, success, error) {
                var url = this.rootUrl + id + "/defend/" + sessionkey;
                httpRequester.postJSON(url, data, success, error);
            }
        });

        var MessagesPersister = Class.create({
            init: function (url) {
                this.rootUrl = url + "messages/";
            },
            unread: function (success, error) {
                var url = this.rootUrl + "unread/" + sessionkey;
                httpRequester.getJSON(url, success, error);
            },
            all: function (success, error) {
                var url = this.rootUrl + "all/" + sessionkey;
                httpRequester.getJSON(url, success, error);
            }
        });

        return {
            get: function (url) {
                return new MainPersister(url);
            },
        }

    }());
    return persisters;
});