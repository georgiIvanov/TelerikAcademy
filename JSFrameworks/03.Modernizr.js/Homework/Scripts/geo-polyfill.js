/// <reference path="jquery-2.0.3.js" />
var geolocatorFallback = (function () {
    function fallback() {
        var image = document.createElement("img");
        image.src = "../Scripts/sadpanda.jpg"

        var wrapper = document.getElementById("content");
        wrapper.appendChild(image);
    }

    return {
        fallback: fallback
    }
})();

geolocatorFallback.fallback();