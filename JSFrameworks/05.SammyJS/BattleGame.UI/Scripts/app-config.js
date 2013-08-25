/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/require.js" />
/// <reference path="libs/underscore.js" />
/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="libs/sha1.js" />


require.config({
    paths: {
        underscore: "libs/underscore",
        jquery: "libs/jquery-2.0.3",
        mustache: "libs/mustache",
        sammy: "libs/sammy-0.7.4",
        "class": "libs/class",
        "http-requester": "libs/http-requester",
        sha1: "libs/sha1",
        persisters: "app/persister",
        controller: "app/controller",
        ui: "app/ui"
    }
});

require(["jquery", "mustache", "underscore", "sammy", "class", "sha1", "persisters", "controller"], function ($, mustache, underscore, sammy, Class, sha1, persisters, controllers) {

    var controller;

    var app = sammy("#main", function () {

        this.get("#/", function () {
            //this.redirect("#/login");
            controller = controllers.get();
            $(document).ready(function () {
                controller.loadUI("#wrapper");
            })
        });

        this.get("#/login", function () {
            alert("in login");
            //this.redirect("#/");
        });
        
        

        this.get("#/register", function () {

        });
        
    });

    app.run("#/");
    
    

});