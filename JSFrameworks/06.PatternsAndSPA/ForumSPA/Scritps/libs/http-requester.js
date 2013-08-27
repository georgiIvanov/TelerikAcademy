define(["jquery"], function ($) {
    function getJSON(url, success, error) {
        $.ajax({
            url: url,
            type: "GET",
            timeout: 5000,
            contentType: "application/json",
            success: success,
            error: error
        });
    };

    function postJSON(url, data, success, error) {
        $.ajax({
            url: url,
            type: "POST",
            data: JSON.stringify(data),
            timeout: 5000,
            contentType: "application/json",
            success: success,
            error: error
        });
    };

    function putJSON(url, success, error) {
        $.ajax({
            url: url,
            type: "PUT",
            timeout: 5000,
            contentType: "application/json",
            success: success,
            error: error
        });
    };

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        putJSON: putJSON
    }
});