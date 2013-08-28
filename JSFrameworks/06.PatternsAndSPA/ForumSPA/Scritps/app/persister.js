/// <reference path="../everlive-SDK/everlive.all.js" />
/// <reference path="../everlive-SDK/everlive.js" />
/// <reference path="../everlive-SDK/jstz.js" />
/// <reference path="../everlive-SDK/kendo.data.everlive.js" />
/// <reference path="../everlive-SDK/reqwest.js" />
/// <reference path="../everlive-SDK/rsvp.js" />
/// <reference path="persister.js" />
/// <reference path="../everlive-SDK/underscore.js" />

var persister = (function () {
    var nickname = localStorage.getItem("nickname");
    var sessionkey = localStorage.getItem("sessionkey");
    var principal_id = localStorage.getItem("principal_id");

    var el = new Everlive('DcCELJaGutj8x1f5');

    function getNickname() {
        return nickname;
    }

    function saveUserData(userData, username) {
        localStorage.setItem("principal_id", userData.result.principal_id);
        localStorage.setItem("sessionkey", userData.result.access_token);
        localStorage.setItem("nickname", username);
        nickname = username;
        sessionkey = userData.result.access_token;
    }

    function clearUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionkey");
        localStorage.removeItem("principal_id");
        nickname = "";
        sessionkey = "";
        principal_id = "";
    }

    function isUserLoggedIn() {
        if (sessionkey === null || sessionkey == "null" || sessionkey == ""
            || nickname == "null" || nickname == "") {
            return false;
        }

        return true;
    }

    function loginUser(username, password, success, fail) {
        el.Users.login(username, password).then(function (data) {
            saveUserData(data, username);
            success(data);
            
        }, function (err) {
            fail(err);
        });
    }

    function registerUser(username, password, success, fail) {
        el.Users.register(username, password).then(function (data) {
            saveUserData(data, username);
            success(data);

        }, function (err) {
            fail(err);
        });
    }

    function submitPost(success, fail) {
        var data = Everlive.$.data('Post');
        data.create(
    }

    return {
        isUserLoggedIn: isUserLoggedIn,
        loginUser: loginUser,
        nickname: getNickname,
        clearUserData: clearUserData,
        registerUser: registerUser
    }
})();