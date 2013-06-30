/// <reference path="class.js" />

var BullsAndCows = BullsAndCows || {};

BullsAndCows.persisters = (function () {

    var BasePersister = Class.create({
        init: function (serviceUrl) {
                this.serviceUrl = serviceUrl;
                this.users = new UserPersister(serviceUrl + "user/");
            }
        
    });

    var UserPersister = Class.create({
        init: function(serviceUrl){
            this.serviceUrl = serviceUrl;
        },
        register: function (username, nickname, password) {
            this.serviceUrl + "register";
        },
        login: function(username, password){

        },
        logout: function () {

        },
        scores: function () {

        }
    });

    return {
        getPersister: function (url) {
            return new BasePersister(url);
        },
    };
}());

var localPersister = BullsAndCows.persisters.getPersister("http://localhost:40643/api/");
localPersister.users.register("pesho", "Pesho Trybata", "gosho");

