/// <reference path="../libs/kendo.web.min.intellisense.js" />
/// <reference path="../libs/underscore.min.js" />
/// <reference path="../libs/kendo.web.min.js" />
window.vmFactory = (function () {
    var data = null;

    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "123456",
            password: "123456",
            login: function () {
                data.users.login(this.get("username"), this.get("password"))
                .then(function () {

                    if (successCallback) {
                        successCallback();
                    }

                }, function (err) {
                    console.log(err);
                });
            },
            register: function () {
                data.users.register(this.get("username"), this.get("password"))
                .then(function (data) {
                    if (successCallback) {
                        successCallback();
                    }
                }, function (err) {
                    console.log(err);
                });
            }
        }

        return kendo.observable(viewModel);
    }

    function getCarsViewModel() {
        return data.cars.all()
        .then(function (cars) {
            var orderedCars = _.sortBy(cars, function (car) {
                return car.make;
            });
            return kendo.observable({
                cars: orderedCars,
                message: ""
            });
        }, function (err) {
            console.log(err);
        });
    }


    return {
        getLoginVM: getLoginViewModel,
        setPersister: function (persister) {
            data = persister;
        },
        getCarsVM: getCarsViewModel
    }
})();