define(["class", "jquery", "dataPersister", "mustache"], function (Class, $, data, mustache) {
    var controller = controller || {};

    var Students = Class.create({
        init: function (itemsSource) {
            this.itemsSource = itemsSource;
        },
        render: function (template) {
            var studentContainer = document.createElement("div");
            studentContainer.className = "studentContainer";
            for (var i in this.itemsSource) {
                var listItem = document.createElement("div");

                var item = this.itemsSource[i];
                listItem.innerHTML = template(item);
                studentContainer.appendChild(listItem);
            }


            $(studentContainer).on("click", '.student', function () {
                var parent = $(this).parent().parent();
                var marksContainer = $('.marksContainer');
                marksContainer.empty();

                if (parent.hasClass('studentContainer')) {

                    var studentId = $(this).data('id');

                    var marks = data.marks(studentId).then(function (data) {
                        var markTemplate = mustache.compile(document.getElementById("mark-template").innerHTML);
                        var marksView = controller.getMarks(data);

                        var marksHTML = marksView.render(markTemplate);


                        
                        marksContainer.append(marksHTML);
                    });

                    parent.toggle();
                    marksContainer.toggle();
                }
            });

            $('.marksContainer').bind("click", function () {
                $('.studentContainer').toggle();
                $('.marksContainer').toggle();
            });

            return $(studentContainer);
        }
    });

    var Marks = Class.create({
        init: function (itemsSource) {
            this.itemsSource = itemsSource;
        },
        render: function (template) {
            var select = document.createElement('div');
            for (var i in this.itemsSource) {
                var item = this.itemsSource[i];
                select.innerHTML += template(item);
            }
            return select.outerHTML;
        }
    });

    controller.getStudents = function (itemsSource) {
        return new Students(itemsSource);
    }

    controller.getMarks = function (itemsSource) {
        return new Marks(itemsSource);
    }

    return controller;
});