(function ($) {
    var map;
    var capitals;
    var counter;

    function initialize() {
        var mapOptions = {
            zoom: 6,
            center: new google.maps.LatLng(42.69959515809203, 23.337364196777344),
            mapTypeId: google.maps.MapTypeId.TERRAIN
        };

        map = new google.maps.Map(document.getElementById('map-canvas'),
            mapOptions);

        capitals = [];
        counter = 0;
        $.ajaxSetup({ "async": false });
        $.getJSON("capitalsData.js", function (data) {
            for (var i = 0; i < data.length; i++) {
                var newMarker = new MapMarker(data[i].lat, data[i].long, data[i].info, data[i].title, data[i].color);
                capitals.push(newMarker);
            }
        });
        var navContainer = $('<div id="nav"></div>');
        var nav = $("<ul/>");
        for (var i = 0; i < capitals.length; i++) {
            var item = $('<li></li>');
            item.append(capitals[i].title);
            item.bind('click', { marker: capitals[i], current: i }, function (event) {
                var data = event.data;
                counter = data.current;
                map.panTo((data.marker).getPosition());
            });
            nav.append(item);
        };

        $('body').append(navContainer.append(nav));

        var prevbtn = $('<a class="NavButton">Prev</a>');
        var nextbtn = $('<a class="NavButton">Next</a>');
        prevbtn.attr('id', 'btn-prev');
        nextbtn.attr('id', 'btn-next');
        prevbtn.on('click', previous);
        nextbtn.on('click', next);

        $('#nav').append(prevbtn);
        $('#nav').append(nextbtn);
        
    }

    function next() {
        if (counter < capitals.length - 1) {
            counter += 1;
        } else {
            counter = 0;
        }
        map.panTo(capitals[counter].getPosition());
    }

    function previous() {
        if (counter > 0) {
            counter -= 1;
        } else {
            counter = capitals.length - 1;
        }
        map.panTo(capitals[counter].getPosition());
    }

    var MapMarker = Class.create({
        init: function (latitude, longitude, info, title, color) {
            this.latitude = latitude;
            this.longitude = longitude;
            this.info = info;
            this.title = title;
            this.color = color;
            this.marker = this.createMarker();
        },
        createMarker: function () {
            var marker = new google.maps.Marker({
                position: new google.maps.LatLng(this.latitude, this.longitude),
                map: map,
                title: this.title
            });
            iconFile = 'http://maps.google.com/mapfiles/ms/icons/' + this.color + '-dot.png';
            marker.setIcon(iconFile);

            var infowindow = new google.maps.InfoWindow({
                content: this.info
            });

            google.maps.event.addListener(marker, 'click', function () {
                infowindow.open(map, marker);
                map.panTo(marker.getPosition());
            });

            return marker;
        },
        getPosition: function () {
            return this.marker.getPosition();
        }

    });

    google.maps.event.addDomListener(window, 'load', initialize());
})(jQuery);