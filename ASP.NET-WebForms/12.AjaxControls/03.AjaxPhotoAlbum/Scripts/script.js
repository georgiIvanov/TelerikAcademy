/// <reference path="jquery-2.0.3.js" />
(function () {
    $("#form1").on("click", ".Image", function (ev) {
        var attr = $("#img1").attr("src");
        
        window.open(attr, 'Popup', 'toolbar=no, location=yes, status=no, menubar=no,scrollbars=yes,resizable=no, width=500,height=750,left=430,top=23');

    });
})();