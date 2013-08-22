/// <reference path="jquery-2.0.3.js" />

var geolocator = (function () {
    function getLocation() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
        }
        else { x.innerHTML = "Geolocation is not supported by this browser."; }
    }
    function showPosition(position) {
        var string = "Latitude: " + position.coords.latitude +
        "<br>Longitude: " + position.coords.longitude;
        $("#content").append(string);
    }

    return {
        getLocation: getLocation,
        showPosition: showPosition,
    }
}());

geolocator.getLocation();