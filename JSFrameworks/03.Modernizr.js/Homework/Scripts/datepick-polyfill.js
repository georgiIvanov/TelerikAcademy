/// <reference path="jquery-ui-1.10.3.js" />

var datePickerFallback = (function () {
    function fallback() {
        //var wrapper = document.getElementById("dateTimePicker");

        //var image = document.createElement("img");
        //image.src = "../Scripts/sadpanda.jpg"
        $(function () {
            $("#dateTimePicker").datepicker();
        });
        
        //wrapper.appendChild(image);
    }

    return {
        fallback: fallback
    }
})();

datePickerFallback.fallback();