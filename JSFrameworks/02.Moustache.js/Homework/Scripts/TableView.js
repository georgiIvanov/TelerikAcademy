/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
    var TableView = Class.create({
        init: function (itemsSource) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of TableView must be an array!";
            }
            this.itemsSource = itemsSource;
        },
        render: function (template) {
            var table = document.createElement("table");
            for (var i = 0; i < this.itemsSource.length; i++) {
                var listItem = document.createElement("tr");
                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                table.appendChild(listItem);

            }
            return table.outerHTML;
        }
    });

    c.getTableView = function (itemsSource) {
        return new TableView(itemsSource);
    }

}(controls || {}));