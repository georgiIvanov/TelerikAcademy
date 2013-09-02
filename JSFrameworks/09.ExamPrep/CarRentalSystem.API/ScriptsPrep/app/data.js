window.persisters = (function () {
    var sessionKey = "";
    var bashUsername = "";

    function getJSON(requestUrl, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "GET",
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function postJSON(requestUrl, data, headers) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            $.ajax({
                url: requestUrl,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                dataType: "json",
                headers: headers,
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    var UsersPersister = (function () {
        var apiUrl = "";
        function init(apiUrl) {
            this.apiUrl = apiUrl;
        }
        function login(username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return postJSON(this.apiUrl + "login", user)
            .then(function (data) {
                localStorage.setItem("username", data.displayName);
                localStorage.setItem("sessionKey", data.sessionKey);

                sessionKey = data.sessionKey;
                bashUsername = data.displayName;
            });
        }
        function register(username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };
            return postJSON(this.apiUrl + "register", user)
				.then(function (data) {
				    localStorage.setItem("username", data.displayName);
				    localStorage.setItem("sessionKey", data.sessionKey);

				    sessionKey = data.sessionKey;
				    bashUsername = data.displayName;
				});
        }

        function logout() {
            if (!sessionKey) {
            }

            var headers = {
                "X-sessionKey": sessionKey
            };

            return putJSON(this.apiUrl + "logout", headers);
        }

        return {
            init: init,
            login: login,
            register: register,
            logout: logout
        }
    })();

    var CarsPersister = (function(){
        function init(apiUrl) {
            this.apiUrl = apiUrl;
        }

        function all() {
            return getJSON(this.apiUrl);
        }

        return{
            init: init,
            all: all
        }
    })();

    var StoresPersister = (function(){
        function init(apiUrl){
            this.apiUrl = apiUrl;
        }

        return {
            init: init,
        }
    })();

    var DataPersister = (function(){
        function init(apiUrl){
            this.apiUrl = apiUrl;
            this.users =  UsersPersister;
            this.users.init(apiUrl + "users/");
            this.cars =  CarsPersister;
            this.cars.init(apiUrl + "cars/");
            this.stores =  StoresPersister;
            this.stores.init(apiUrl + "stores/");
        }

        return {
            init: init
        }
    })();

    return {
        get: function (apiUrl) {
            return new DataPersister.init(apiUrl);
        }
    }

})();