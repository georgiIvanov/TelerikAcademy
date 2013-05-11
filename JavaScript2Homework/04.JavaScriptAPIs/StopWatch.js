function StopWatch() {

    var startTime = null;
    var stopTime = null;
    var running = false;

    function getTime() {
        var day = new Date();
        return day.getTime();
    }

    this.start = function () {

        if (running == true) {
            return;
        }
        else if (startTime != null) {
            stopTime = null;
        }

        running = true;
        startTime = getTime();
    }

    this.stop = function () {
        if (running == false) {
            return;
        }

        stopTime = getTime();
        running = false;
    }

    this.duration = function () {
        if (startTime == null || stopTime == null) {
            return 'Undefined';
        }
        else {
            return (stopTime - startTime) / 1000;
        }
    }
}