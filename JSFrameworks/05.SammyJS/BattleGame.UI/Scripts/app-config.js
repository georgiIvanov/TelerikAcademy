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

require(["jquery", "mustache", "underscore", "sammy", "class", "sha1", "persisters", "controller", "ui"], function ($, mustache, underscore, sammy, Class, sha1, persisters, controllers, ui) {

    var controller;

    var arr = [1, 2, 3, ];
    var max = _.max(arr);

    var app = sammy("#wrapper", function () {

        this.get("#/", function () {

            controller = controllers.get();
            $(document).ready(function () {
                controller.loadUI("#wrapper");
            })
        });

        this.get("#/login", function () {

        });
        
        
        this.get("#/register", function () {

        });

        this.get("#/join-game", function () {
            controller.persister.game.open(function (games) {

                var foundGames = {};
                foundGames.games = games;

                var list = ui.openGamesList(foundGames);
                $(controller.selector + " #open-games-container").html(list);
            }, function (err) {
                //alert(err.responseText);
            });
        });

        this.get("#/my-games", function () {
            controller.persister.game.myActive(function (games) {
                var list = ui.activeGamesList(games);
                $(controller.selector + " #active-games-container").html(list);
            }, function (err) {
                //alert(err.responseText);
            });
        });

        this.get("#/battle-in-game", function () {

        });
        
    });

    app.run("#/");
    
    

});