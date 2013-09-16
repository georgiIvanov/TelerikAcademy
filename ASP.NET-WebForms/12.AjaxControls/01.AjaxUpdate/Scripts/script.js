/// <reference path="jquery-2.0.3.js" />
(function () {
    $("#EmployeesUpdatePanel").on("click", ".selectButton a", function () {
        $("#OrdersGridView").remove("#OrdersGridView");

    });
})();