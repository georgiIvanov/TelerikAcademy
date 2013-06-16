/// <reference path="Scripts/jquery-2.0.2.js" />
/// <reference path="Scripts/jquery-2.0.2.intellisense.js" />

var Slider = (function ($) {
     
    function init(time) {
            _self = this;
            this.enlarged = 0;
            this.setOfSlides = [];
            this.time = time;
            this.slider = $('#slider');
        }
    function addSlide(code) {
            this.setOfSlides.push(code);
        }
     function previous() {
            clearInterval(auto);
            auto = setInterval(_self.tick, _self.time);
            if (crnt > 0) {
                current.hide();
                current = current.prev().show();
                crnt -= 1;
            }
            else {
                crnt = _self.setOfSlides.length - 1;
                current.hide();
                current = $('#slides').children().last();
                current.show();
            }
        }
     function next() {
            clearInterval(auto);
            auto = setInterval(_self.tick, _self.time);
            if (crnt < _self.setOfSlides.length - 1) {
                current = current.next().show();
                current.prev().hide();
                crnt += 1;
            }
            else {
                crnt = 0;
                $("#slides").children().last().hide();
                current = $("#slides").children().first();
                current.show();
            }
        }
    function tick() {
            _self.next();
        }
    function initButtons() {
            var prevbtn = $("<button></button>");
            var nextbtn = $("<button></button>");
            prevbtn.attr("id", "btn-prev");
            nextbtn.attr("id", "btn-next");
            prevbtn.on("click", this.previous);
            nextbtn.on("click", this.next);
            this.slider.prepend(prevbtn);
            this.slider.append(nextbtn);
        }
    function render() {
            this.slider.append('<div id="slides"></div>');
            var slides = $("#slides");
            for (var i = 0; i < this.setOfSlides.length; i++) {
                var slide = $('<div id="slide"></div>');
                slide.append($(this.setOfSlides[i])).hide();
                slides.append(slide);
            }
            slides.children().first().show();
            current = slides.children().first();
            crnt = 0;

            this.initButtons();
            auto = setInterval(this.tick, this.time);
        }
    
    return {
        init: init,
        addSlide: addSlide,
        previous: previous,
        next: next,
        tick: tick,
        initButtons: initButtons,
        render: render,
    }
    
})(jQuery);