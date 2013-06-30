/// <reference path="jquery-2.0.2.js" />
/// <reference path="q.js" />

var httpRequester = (function(){

    var makeHttpRequest = function (url, type) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: type,
            contentType: "application/json",
            data: (type == "post") ? data : undefined,
            success: function (result) {
                deferred.resolve(result);
            },
            error: function (errorData) {
                deferred.reject(errorData);
            }
        });

        return deferred.promise;
    }

    var makeHttpGetRequest = function (url) {
        return makeHttpRequest(url, "get");
    }

    var makeHttpPostRequest = function (url, data) {
        return makeHttpRequest(url, "post", data);
    }

    return {
        httpPost: makeHttpPostRequest,
        httpGet: makeHttpGetRequest,
    };
}());