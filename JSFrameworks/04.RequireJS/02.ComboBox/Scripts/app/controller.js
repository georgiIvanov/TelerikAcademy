/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/class.js" />

define(["class", "jquery", "mustache"], function (Class, $, mustache) {
    var controller = controller || {};

    var ComboBox = Class.create({
        init: function (itemsSource) {
            this.itemsSource = itemsSource;
        },
        render: function (template) {
            var comboBoxContainer = document.createElement("div");

            var listItem = document.createElement('div');
            var item = this.itemsSource[0];
            listItem.innerHTML = template(item);

            listItem.className = "selected";

            comboBoxContainer.appendChild(listItem);

            $(comboBoxContainer).on("click", ".selected", function () {
                $(this).removeClass("selected");
                $(comboBoxContainer).children().addClass("shown").show();
            });


            $(comboBoxContainer).on("click", ".shown", function () {
                $(comboBoxContainer).children().removeClass("shown").hide();

                $(this).addClass("selected").show();
            });

            for (var i = 1; i < this.itemsSource.length; i++) {
                var item = this.itemsSource[i];
                var listItem =  document.createElement('div');
                listItem.innerHTML = template(item);
                listItem.style.display = "none";
                comboBoxContainer.appendChild(listItem);
            }

            return comboBoxContainer;
        }
    });

    controller.createComboBox = function (itemsSource) {
        return new ComboBox(itemsSource);
    }

    return controller;
});