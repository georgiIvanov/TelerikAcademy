/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/mustache.js" />
/// <reference path="../libs/sammy-0.7.4.js" />
/// <reference path="../libs/sha1.js" />
/// <reference path="../libs/class.js" />
/// <reference path="controller.js" />
/// <reference path="../libs/http-requester.js" />
/// <reference path="persister.js" />


(function () {

    function goHome() {
        $("#wrapper").html("");

        controller.renderHomePage();
        
    };

    var app = Sammy("#wrapper", function () {

        controller.registerEvents();
        
        this.get("#/", goHome);

        this.get("#/home", function () {
            this.redirect("#/");
        });
        

        this.get("#/posts", function () {
            controller.renderPosts();
        });

        this.get("#/posts/tags=:tags", function () {
            
            controller.searchByTags();
        });

        this.get("#/posts/:id", function () {
            $("#wrapper").append("posts by id <br/>   ");
            controller.renderPostById();

        });

        this.get("#/posts/:id/comment", function (data) {

            $("#wrapper").append("post a comment<br/>   ");
        });

    });

    app.run("#/");

}());