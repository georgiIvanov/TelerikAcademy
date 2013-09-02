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

	function createHeader() {
	    var headers = {
	        "X-sessionKey": sessionKey
	    };

	    return headers;
	}

	var UsersPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		login: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString()
			};
			return postJSON(this.apiUrl + "login", user)
				.then(function (data) {
					//save to localStorage
					sessionKey = data.sessionKey;
					bashUsername = data.displayName;
					//return data;
				});
		},
		register: function (username, password) {
			var user = {
				username: username,
				authCode: CryptoJS.SHA1(password).toString()
			};
			return postJSON(this.apiUrl + "register", user)
				.then(function (data) {
					//save to localStorage
					sessionKey = data.sessionKey;
					bashUsername = data.displayName;
					return data.displayName;
				});
		},
		logout: function () {
			if (!sessionKey) {
				//gyrmi
			}
			var headers = {
				"X-sessionKey": sessionKey
			};
			//clear sessionKey
			sessionKey = "";
			return putJSON(this.apiUrl + "logout", createHeader());
		},
		currentUser: function () {
			return bashUsername;
		}
	});

	var CarsPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
		},
		all: function () {
			return getJSON(this.apiUrl);
		}
	});

	var StoresPersister = Class.create({
	})

	var DataPersister = Class.create({
		init: function (apiUrl) {
			this.apiUrl = apiUrl;
			this.users = new UsersPersister(apiUrl + "users/");
			this.cars = new CarsPersister(apiUrl + "cars/");
			this.stores = new StoresPersister(apiUrl + "stores/");
		}
	});


	return {
		get: function (apiUrl) {
			return new DataPersister(apiUrl);
		}
	}
}());