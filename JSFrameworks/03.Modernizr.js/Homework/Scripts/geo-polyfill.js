/// <reference path="jquery-2.0.3.js" />
var geolocatorFallback = (function () {
    (function (geolocation) {

        if (geolocation) return;

        var cache;

        geolocation = window.navigator.geolocation = {};
        geolocation.getCurrentPosition = function (callback) {

            if (cache) callback(cache);

            $.getScript('//www.google.com/jsapi', function () {

                // sometimes ClientLocation comes back null
                if (google.loader.ClientLocation) {
                    cache = {
                        coords: {
                            "latitude": google.loader.ClientLocation.latitude,
                            "longitude": google.loader.ClientLocation.longitude
                        }
                    };
                }

                callback(cache);
            });

        };

        geolocation.watchPosition = geolocation.getCurrentPosition;

    })(navigator.geolocation);



    // usage
    
   

    function fallback() {
        var image = document.createElement("img");
        image.src = "../Scripts/sadpanda.jpg"

        navigator.geolocation.watchPosition(function (pos) {
            var element = document.createElement('div');
            var string = "I'm located at " + pos.coords.latitude + ' and ' + pos.coords.longitude;

            

            var wrapper = document.getElementById("content");
            wrapper.appendChild(image);
            wrapper.innerHTML += string;
        })
        };

   
    return {
        fallback: fallback
    }
})();

geolocatorFallback.fallback();

