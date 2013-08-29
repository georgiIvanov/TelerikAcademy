/// <reference path="../everlive-SDK/everlive.all.js" />
/// <reference path="../everlive-SDK/everlive.js" />
/// <reference path="../everlive-SDK/jstz.js" />
/// <reference path="../everlive-SDK/kendo.data.everlive.js" />
/// <reference path="../everlive-SDK/reqwest.js" />
/// <reference path="../everlive-SDK/rsvp.js" />
/// <reference path="persister.js" />
/// <reference path="../everlive-SDK/underscore.js" />
/// <reference path="../libs/jquery-2.0.3.js" />

var persister = (function () {
    var nickname = localStorage.getItem("nickname");
    var sessionkey = localStorage.getItem("sessionkey");
    var principal_id = localStorage.getItem("principal_id");
    var appKey = 'DcCELJaGutj8x1f5';
    var el = new Everlive(appKey);
    
    function assignTokenIfMissing() {
        if (el.setup.token == null) {
            el.setup.token = sessionkey;
        }
    }

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
        el.Users.logout(function (data) {
        }, function (err) {
        });
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
            el.setup.token = data.result.access_token;
            success(data);
            
        }, function (err) {
            fail(err);
        });
    }

    function registerUser(username, password, success, fail) {
        el.Users.register(username, password).then(function (data) {
            loginUser(username, password,
            saveUserData(data, username), function () {
            });
            
            success(data);

        }, function (err) {
            fail(err);
        });
    }

    function submitPost(title, content, tags, success, fail) {
        var data = Everlive.$.data('Post');
        assignTokenIfMissing();

        data.create({
            'Title': title,
            'Content': content,
            'CreatedBy': principal_id,
            'PostedBy': nickname,
            'ArrayOfTags': tags
        }, function (data) {
            success(data);
        }, function (err) {
            fail(err);
        });
    }

    function submitComment(postId, content, success, fail) {
        var data = Everlive.$.data('Comment');
        assignTokenIfMissing();

        data.create({
            'CommentBy': nickname,
            'OnPost': postId,
            'Content': content
        }, function (data) {
            success(data);
        }, function (err) {
            fail(err);
        });
    }

    function getPosts(success, fail) {
        var data = Everlive.$.data('Post');
        assignTokenIfMissing();

        var query = new Everlive.Query();
        query.orderDesc('CreatedAt');

        data.get(query)
        .then(function (data) {
            success(data);
        },
        function (err) {
            fail(err);
        });
    }

    function getComments(postId, success, fail) {
       
        var data = Everlive.$.data('Comment');
        assignTokenIfMissing();

        var query = new Everlive.Query();
        query.where().eq('OnPost', postId);

        data.get(query)
        .then(function (data) {
            success(data);
        }, function (err) {
            fail(err);
        });
    }

    function getPostById(id, success, fail) {
        var data = Everlive.$.data('Post');
        assignTokenIfMissing();

        data.getById(id)
        .then(function (data) {
            success(data);
        }, function (err) {
            fail(err);
        });
    }

    function searchByTags(tags, success, fail) {
        var data = Everlive.$.data('Post');
        assignTokenIfMissing();

        var query = new Everlive.Query();
        query.where().all('ArrayOfTags', tags);
        data.get(query)
        .then(function (data) {
            success(data);
        }, function (err) {
            fail(err);
        });
    }

    return {
        isUserLoggedIn: isUserLoggedIn,
        loginUser: loginUser,
        nickname: getNickname,
        clearUserData: clearUserData,
        registerUser: registerUser,
        submitPost: submitPost,
        getPosts: getPosts,
        getPostById: getPostById,
        searchByTags: searchByTags,
        submitComment: submitComment,
        getComments: getComments
    }
})();