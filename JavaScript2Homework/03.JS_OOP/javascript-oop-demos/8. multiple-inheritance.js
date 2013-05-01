﻿﻿﻿Function.prototype.inherit = function(parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
}

Function.prototype.extend = function(parent) {
    for (var i = 1; i < arguments.length; i += 1) {
        var name = arguments[i];
        this.prototype[name] = parent.prototype[name];
    }
    return this;
}

function Shape(width, height, position) {
    this.width = width;
    this.height = height;
    this.position = position;
}

function Movable() {}

Movable.prototype.move = function move(dx, dy) {
        this.position.x += dx;
        this.position.y += dy;
}


function Rect(width, height, position) {
    Shape.apply(this, arguments);
}

Rect.inherit(Shape);

Rect.prototype.area = function() {
    return this.width * this.height;
}


function MovableRect(width, height, position) {
    Rect.apply(this, arguments);
}

MovableRect.inherit(Rect);

MovableRect.extend(Movable, 'move');

var mRect = new MovableRect(5, 5, {
    x: 15,
    y: 15
});
console.log(mRect);
mRect.move(5,5);
console.log(mRect);
mRect.move(0,15);
console.log(mRect);
