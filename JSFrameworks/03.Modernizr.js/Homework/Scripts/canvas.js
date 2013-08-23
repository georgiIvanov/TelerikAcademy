var canvasCreator = (function () {
    function initFunction() {
        var canvas = document.getElementById('canvas');
        var ctx = canvas.getContext('2d');
        ctx.fillStyle = '#FF6000';
        ctx.fillRect(0, 0, 300, 100);
    }

    return {
        init: initFunction
    }
})();

canvasCreator.init();
