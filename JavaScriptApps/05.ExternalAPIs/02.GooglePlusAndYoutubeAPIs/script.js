/// <reference path="jquery-2.0.2.min.js" />

$('#revokeButton').hide();

function signinCallback(authResult) {
    if (authResult['access_token']) {
        $('#player-border').fadeIn();
        $('#signinButton').hide();
        $('#revokeButton').fadeIn('slow');
        $('#controls').fadeIn('slow');
        gapi.client.load('plus', 'v1', function () {
            var request = gapi.client.plus.people.get({
                'userId': 'me'
            });
            request.execute(function (resp) {
                $('#profile').empty();
                $('#profile').append('<div id="user-info"><img src="' + resp.image.url + '"><h3>' + resp.displayName + '</h3></div>');
                
            });
        });

    } else if (authResult['error']) {
        console.log('There was an error: ' + authResult['error']);
    }
}

function disconnectUser(access_token) {
    var revokeUrl = 'https://accounts.google.com/o/oauth2/revoke?token=' +
        access_token;

    $.ajax({
        type: 'GET',
        url: revokeUrl,
        async: false,
        contentType: "application/json",
        dataType: 'jsonp',
        success: function (nullResponse) {
            $('#player-border').hide();
            $('#signinButton').show();
            $('#revokeButton').hide();
            $('#controls').hide();
            $('#profile').empty();
            player.pauseVideo();
        },
        error: function (e) {
            console.log(e);
        }
    });
}

$('#revokeButton').click(disconnectUser);


var player;
function onYouTubeIframeAPIReady() {
    player = new YT.Player('player', {
        height: '390', 
        width: '640',
        videoId: 'Nco_kh8xJDs',
        events: {
            'onReady': onPlayerReady,
        }
    });
}

function onPlayerReady(event) {
    event.target.pauseVideo();
}

document.getElementById('single-video').addEventListener('click', function () {
    var video = document.getElementById('load-video').value;

    player.loadVideoById(video, 0, "large");
}, false);

document.getElementById('pause').addEventListener('click', function () {
    player.pauseVideo();
}, false);

document.getElementById('play').addEventListener('click', function () {
    player.playVideo();
}, false);

document.getElementById('load-playlist').addEventListener('click', function () {
    var videoPlaylist = document.getElementById('playlist').value.split(',');

    player.loadPlaylist(videoPlaylist, 0, 0, "large");
}, false);

document.getElementById('previous').addEventListener('click', function () {
    player.previousVideo();
}, false);

document.getElementById('next').addEventListener('click', function () {
    player.nextVideo();
}, false);
