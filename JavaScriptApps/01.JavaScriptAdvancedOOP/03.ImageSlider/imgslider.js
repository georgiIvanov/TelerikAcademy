var sliderController = (function(){
    var imageBarElement;

    function init(selectorBar, imageSelector){
        this.imagesSrc = [];
        this.imagesContainer = [];
        this.imageBarElement = document.querySelector(selectorBar);

        var img = document.createElement("img");
        img.style.height = "300px";
        img.style.width = "300px";
        this.enlarged = document.querySelector(imageSelector);
        this.enlarged.appendChild(img);
    }

    function loadImages(path, names) {
        for (var i = 0; i < names.length; i++) {

            this.imagesSrc.push(path + names[i]);
        }

        var img = document.createElement("img");
        img.height = 90;
        img.width = 90;
        var imgContainer = document.createElement("span");
        imgContainer.style.padding = "2px";
        
        for (var i = 0; i < 4; i++) {
            img.src = this.imagesSrc[i];
            imgContainer.appendChild(img);
            this.imagesContainer.push(img.cloneNode(true));
            this.imageBarElement.appendChild(imgContainer.cloneNode(true));
        }
        this.enlarged.firstChild.src = this.imagesSrc[0];
    }

    function setClickEvents(slideSelector, nextSelector, prevSelector) {

        var button = document.querySelector(slideSelector);
        button.addEventListener("click", enlargeImage, false);

        button = document.querySelector(nextSelector);
        button.addEventListener("click", nextImage, false);
    }

    function enlargeImage(ev) {

        var clickedItem = ev.target;
        if (!(clickedItem instanceof HTMLImageElement)) {
            return;
        }

        var enlargedImg = document.getElementById("enlargedImage").firstChild;
        enlargedImg.src = clickedItem.src;
    }

    function nextImage(ev){
        var clickedItem = ev.target;
        if (!(clickedItem instanceof HTMLAnchorElement)) {
            return;
        }

        sliderController.imagesContainer


    }

    return{
        init: init,
        loadImages: loadImages,
        setClickEvents: setClickEvents,
    }
})();

var imageNames = ["img1.jpg", "img2.jpg", "img3.jpg", "img4.jpg", "img5.jpg", "img6.jpg", "img7.jpg", "img8.jpg", ];



var sliderController = Object.create(sliderController);