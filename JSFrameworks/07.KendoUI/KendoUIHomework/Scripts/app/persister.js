/// <reference path="../everlive/rsvp.js" />
/// <reference path="../everlive/underscore.js" />
/// <reference path="../kendoUI/kendo.web.js" />
/// <reference path="../everlive/everlive.js" />

window.persister = (function () {
    var ApiKey = 'trdJQFjNZNKspJGT';
    var transactions = [];

    var userViewModel = kendo.observable({
        credentials: {},
        Balance: 0,
        Username: "",

        storeCredentials: function (creds) {
            localStorage.setItem("username", creds.username);
            localStorage.setItem("access_token", creds.access_token);

        },
        loadCredentials: function () {
            var credentials = {
                username: localStorage.getItem("username"),
                access_token: localStorage.getItem("access_token")
            }

            return credentials;
        }
    });

    var credentials = userViewModel.loadCredentials();
    var el = new Everlive({
        apiKey: ApiKey,
        token: credentials.access_token
    });

    var transactionsViewModel = kendo.observable({
        data: transactions,
        createdAt: 'unknown',
        moneyTransacted: 0,
        added: false,
        addTrans: function (add) {
            this.data.push(add);
        }

    });

    var user = (function () {
        

        function isUserLoggedIn() {
            if (credentials.username == "" || credentials.username == null || credentials.access_token == "" || credentials.access_token == null) {
                return false;
            }

            return true;
        }

        function registerUser(usrname, password, success, fail) {
            el.Users.register(usrname, password).then(function (data) {
                username = usrname;
                loginUser(usrname, password, success(data), fail);
                
            }, function (err) {
                fail(err);
            });
        }

        function loginUser(usrname, password, success, fail) {
            el.Users.login(usrname, password, function (data) {
                data.result.username = usrname;
                userViewModel.storeCredentials(data.result);
                userViewModel.Username = data.result.username;
                success(data);
            }, function (err) {
                fail(err);
            });
        }

        function logoutUser(success, fail) {
            el.Users.logout(function (data) {
                userViewModel.credentials = null;
                localStorage.clear();
                success(data);
            }, function (err) {
                fail(data);
            });
            
        }

        function getRestOfUserInformation(success, fail) {
            el.Users.currentUser(function (data) {
                if(data.result.Balance !== void 0)
                    userViewModel.Balance = data.result.Balance;
                userViewModel.Username = data.result.Username;
                success(data);
                

            }, function (err) {
                fail(err);
            });
        }

        function username() {
            return credentials.username;
        }

        function sendTransaction(amount, success, fail) {
            el.Users.update({ 'Balance': userViewModel.Balance + amount },
                { 'Username': credentials.username },
                function (data) {
                    var newB = userViewModel.Balance + amount;
                    userViewModel.set("Balance", newB);
                    success(data);
                    
                    var data = Everlive.$.data('Transactions');

                    data.create({
                        'MoneyTransacted': amount
                    }, function (data) {
                        data.result.moneyTransacted = amount;
                        transactionsViewModel.addTrans(data.result);
                    }, function (err) {

                    });
                    
                }, function (err) {
                    fail(err);
                });
        }

        return {
            isUserLoggedIn: isUserLoggedIn,
            registerUser: registerUser,
            username: username,
            loginUser: loginUser,
            getRestOfUserInformation: getRestOfUserInformation,
            sendTransaction: sendTransaction,
            logoutUser: logoutUser
        }

    })();


    return {
        user: user,
        userViewModel: userViewModel,
        transactionsViewModel: transactionsViewModel
    }
})();