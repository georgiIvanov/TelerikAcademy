/// <reference path="libs/class.js" />
/// <reference path="libs/jquery-2.0.3.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/require.js" />


require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        "class": "libs/class",
        mustache: "libs/mustache",
        controller: "app/controller"
    }
});

require(["jquery", "controller", "mustache"], function ($, controller, mustache) {

    var people = [
  { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "../Images/minkov.jpg" },
  { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "../Images/joreto.jpg" },
    { id: 3, name: "Leela", age: 21, avatarUrl: "../Images/leela.jpg" }];

    var comboBox = controller.createComboBox(people);

    var peopleTemplate = mustache.compile(document.getElementById("person-template").innerHTML);

    var comboBoxHTML = comboBox.render(peopleTemplate);

    $("#comboBox").append(comboBoxHTML);

});