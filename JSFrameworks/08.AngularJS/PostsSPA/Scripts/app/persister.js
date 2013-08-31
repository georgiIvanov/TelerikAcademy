/// <reference path="../everlive/everlive.all.js" />
/// <reference path="controller.js" />
/// <reference path="../everlive/rsvp.js" />
/// <reference path="../libs/jquery-2.0.3.js" />


window.persister = (function () {
    var el = new Everlive('3sdsMBDvafIYve0q');

    function getPosts(success, fail) {
        var data = Everlive.$.data('Post');

        data.get()
        .then(function (data) {
            success(data);
        }, function (err) {
            fail(err);
        });
    }

    function sendPost(post, success, fail) {
        var data = Everlive.$.data('Post');

        data.create({
            'PostedByUser': post.username,
            'Category': post.category,
            'Content': post.content
        }, function (data) {
            success(data);
        }, function (err) {
            fail(err);
        });

    }

    return {
        getPosts: getPosts,
        sendPost: sendPost
    }

})();