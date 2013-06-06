var Class = (function () {
    function createClass(properties) {
        var createFunction = function () {
            this.init.apply(this, arguments);
        }

        for (var prop in properties) {
            createFunction.prototype[prop] = properties[prop];
        }

        if (!createFunction.prototype.init) {
            createFunction.prototype.init = function () {
            };
        }
        return createFunction;
    }

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        var parentPrototype = new parent();
        this.prototype = Object.create(parentPrototype);
        this.prototype._super = parent;

        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }

    return{
        create: createClass
    }
}());