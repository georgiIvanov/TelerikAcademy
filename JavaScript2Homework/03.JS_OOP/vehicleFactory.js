var AfterburnerState = {
    "ACTIVATED": 1,
    "DEACTIVATED": 2,
};

var RotationDirection = {
    "CLOCKWISE": 1,
    "COUNTERCLOCKWISE": 2,
};

var AmphibianMode = {
    "LAND": 1,
    "WATER": 2,
};

function createVehicleFactory() {

    Function.prototype.inherits = function (parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    };

    Function.prototype.extends = function (parent) {
        for (var i = 1; i < arguments.length; i += 1) {
            var name = arguments[i];
            this.prototype[name] = parent.prototype[name];
        }
        return this;
    }

    function PropulsionUnit() {
    }

    PropulsionUnit.prototype.getAcceleration = function () {
        throw new Error("Not implemented in primary prototype.");
    }

    function Wheel(radius) {
        this.radius = radius;
    }
    Wheel.inherits(PropulsionUnit);
    Wheel.prototype.getAcceleration = function () {
        return parseInt(2 * Math.PI * this.radius);
    }

    function PropellingNozzle(power, afterburnerState) {
        this.power = power;
        this.afterburnerState = afterburnerState;
    }
    PropellingNozzle.inherits(PropulsionUnit);
    PropellingNozzle.prototype.getAcceleration = function () {
        if (this.afterburnerState === AfterburnerState.ACTIVATED) {
            return 2 * this.power;
        } else {
            return this.power;
        }
    }

    function Propeller(bladesNumber, rotationDirection) {
        this.bladesNumber = bladesNumber;
        this.rotationDirection = rotationDirection;
    }
    Propeller.inherits(PropulsionUnit);
    Propeller.prototype.getAcceleration = function () {
        if (this.rotationDirection === RotationDirection.CLOCKWISE) {
            return this.bladesNumber;
        } else {
            return -this.bladesNumber;
        }
    }

    function Vehicle(speed, propulsionUnits) {
        this.speed = speed;
        this.propulsionUnits = propulsionUnits;
    }
    Vehicle.prototype.accelerate = function () {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            this.speed += this.propulsionUnits[i].getAcceleration();
        }
    }

    function LandVehicle(speed, wheels) {
        Vehicle.apply(this, arguments);
    }
    LandVehicle.inherits(Vehicle);

    function Aircraft(speed, propellingNozzles) {
        Vehicle.apply(this, arguments);
    }
    Aircraft.inherits(Vehicle);
    Aircraft.prototype.switchAfterburners = function (afterburnerState) {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof PropellingNozzle) {
                this.propulsionUnits[i].afterburnerState = afterburnerState;
            }
        }
    }
    Aircraft.prototype.setAfterburners = AfterburnerState;

    function Watercraft(speed, propellers) {
        Vehicle.apply(this, arguments);
    }
    Watercraft.inherits(Vehicle);
    Watercraft.prototype.setPropellersRotationDirection = function (rotationDirection) {
        for (var i = 0; i < this.propulsionUnits.length; i++) {
            if (this.propulsionUnits[i] instanceof Propeller) {
                this.propulsionUnits[i].rotationDirection = rotationDirection;
            }
        }
    }
    Watercraft.prototype.propellersDirection = RotationDirection;

    function Amphibian(speed, propellers, wheels, mode) {

        var propulsionUnits = [];
        for (var i = 0; i < propellers.length; i++) {
            propulsionUnits.push(propellers[i]);
        }

        for (var j = 0; j < wheels.length; j++) {
            propulsionUnits.push(wheels[i]);
        }

        Vehicle.call(this, speed, propulsionUnits);
        this.mode = mode;
    }

    Amphibian.inherits(Vehicle);
    Amphibian.extends(Watercraft, "setPropellersRotationDirection");
    Amphibian.prototype.accelerate = function () {
        if (this.mode === AmphibianMode.LAND) {
            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Wheel) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        } else {
            for (var i = 0; i < this.propulsionUnits.length; i++) {
                if (this.propulsionUnits[i] instanceof Propeller) {
                    this.speed += this.propulsionUnits[i].getAcceleration();
                }
            }
        }
    }
    Amphibian.prototype.setMode = AmphibianMode;
    Amphibian.prototype.rotationDirection = RotationDirection;

    return {
        AfterburnerState: AfterburnerState,
        RotationDirection: RotationDirection,
        AmphibianMode: AmphibianMode,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        Aircraft: Aircraft,
        Watercraft: Watercraft,
        Amphibian: Amphibian
    };
}