var Slider = {
    init: function (container, images) {
        this.container = document.getElementById("img-slider");
        this.imgs = images;
        this.imageWrapper = document.createElement("div");
        this.imageWrapper.id = "img-wrapper";
        this.widthWrapper = 216;
        this.imageWrapper.style.width = this.widthWrapper + "px";
        this.nav = document.createElement("div");
        this.nav.id = "nav";
    },
    prevButton: function (id) {
        this.prevButton = Object.create(Button);
        this.prevButton.init(id);
    },
    nextButton: function (id) {
        this.nextButton = Object.create(Button);
        this.prevButton.init(id);
    },
    render: function () {
        this.initImages();
        this.initButton(this.prevButton, this.previous, "Previous");
        this.initButton(this.nextButton, this.next, "Next");
    },
    initButton: function (obj, func, text) {
        var btn = document.createElement("button");
        btn.textContent = text;
        btn.id = obj.id;
        btn.style.cursor = "pointer";
        this.nav.appendChild(btn);
        btn.onclick = func;
    },
    next: function () {
        var slide = document.getElementById("img-slide");
        var wrapper = document.getElementById("img-wrapper");
        var position = parseInt(slide.style.left, 10);
        var right = parseInt(slide.style.width, 10) + 100;
        if (-position +300 < right) {
            position = position - 100;
            slide.style.left = position + "px";
        }
    },
    previous: function () {
        var slide = document.getElementById("img-slide");
        var position = parseInt(slide.style.left, 10);
        if (position < 0) {
            position = position + 100;
            slide.style.left = position + "px";
        }
    },
    initImages: function () {
        var imagePreview = document.createElement("div");
        imagePreview.id = "img-preview";

        var imageLarge = document.createElement("img");
        imageLarge.src = this.imgs[0].url;
        imageLarge.style.height = "400px";
        imagePreview.appendChild(imageLarge);

        this.container.appendChild(imagePreview);
        var imageSlide = document.createElement("div");
        imageSlide.style.left = 0;
        imageSlide.id = "img-slide";
        var width = 0;
        for (var i = 0; i < this.imgs.length; i++) {
            var image = document.createElement("img");
            image.src = this.imgs[i].url;
            this.title = this.imgs[i].imgTitle;
            image.data = this.imgs[i].url;
            image.onclick = function (ev) {
                imageLarge.src = this.data;
                imagePreview.innerHTML = '';
                imagePreview.appendChild(imageLarge);
            };
            image.height = 80;
            width += 100;
            imageSlide.style.width = width + "px";
            imageSlide.appendChild(image);
        }
        this.imageWrapper.appendChild(imageSlide);
        this.nav.appendChild(this.imageWrapper);
        this.container.appendChild(this.nav);
    }
};

var SliderImage = {
    init: function (imgTitle, ulr) {
        this.imgTitle = imgTitle;
        this.url = ulr;
    }
};

var Button = {
    init: function (id) {
        this.id = id;
    }
};

var images = [];
for (var i = 1; i < 8; i++) {
    var img = Object.create(SliderImage);
    img.init(i, "images/img" + i + ".jpg");
    images.push(img);
}

var slider = Object.create(Slider);
slider.init("img-slider", images);
slider.prevButton("prevButton");
slider.nextButton("nextButton");
slider.render();