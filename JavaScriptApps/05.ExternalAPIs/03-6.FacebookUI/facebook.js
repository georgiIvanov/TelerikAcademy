var token;
window.fbAsyncInit = function () {
    FB.init({
        appId: '166748376839883',
        channelUrl: '//http://localhost:21851/index.html',
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true // parse XFBML
    });

    FB.login(function (response) {
        if (response.authResponse) {
            token = response.authResponse.accessToken;
            getProfileInfo();
            getFriends();
            $('#fbLogout').css("display", "inline-block");
        } else {
            console.log('User cancelled login or did not fully authorize.');
        }
    }, { scope: 'read_friendlists,user_photos, user_birthday, user_location' });
};

(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));


function getProfileInfo() {
    FB.api('/me', function (response) {
        var holder = $("#profile");
        var name = response.name;
        var birthday = response.birthday;
        var location = response.location.name;
        var url = "https://graph.facebook.com/" + response.id + "/picture";
        holder.append("<img src =" + url + "/>");
        holder.append("<p>" + name + "</p>");
        holder.append("<p>" + birthday + "</p>");
        holder.append("<p>" + location + "</p>");
    });
    $("#log").css("display", "none");
}

function getFriends() {
    FB.api('/me/friends?access_token=' + token, function (response) {
        var friendsHolder = $('#friends');
        for (i = 0; i < response.data.length; i++) {
            var friendPictureUrl = 'https://graph.facebook.com/' + response.data[i].id + '/picture?width=200&height=200';
            var friendName = response.data[i].name;
            friendsHolder.append("<img src =" + friendPictureUrl + " title=" + friendName + "/>");
        }
    });
}

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=395337783908870";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

function fbLogout() {
    FB.logout(function (response) {
        $('#disconnect').hide('slow');
        $('#profile').hide('slow');
        $('#friends').hide('slow');
        $('#log').show();
        $('#fbLogout').css("display", "none");
        window.location.reload();
    });
}