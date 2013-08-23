var polyfillCanvas = (function(){
    function initCanvas() {
        var el = document.getElementById('canvas');
        var ctx = el.getContext('2d');

        ctx.fillStyle = '#FF60A0';
        ctx.fillRect(0, 0, 300, 200);

        var body = document.getElementById("content");
        body.appendChild(el);
    }

    return {
        init: initCanvas
    }
})();

polyfillCanvas.init();