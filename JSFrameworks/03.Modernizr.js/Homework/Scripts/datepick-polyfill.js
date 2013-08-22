/// <reference path="jquery-ui-1.10.3.js" />

var datePickerFallback = (function () {
    function fallback() {
        $(function () {
            $("#dateTimePicker").datepicker();
        });
        
    }

    return {
        fallback: fallback
    }
})();

datePickerFallback.fallback();