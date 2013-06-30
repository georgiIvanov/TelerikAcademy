module("Food.init");

test("When food is initialized, should set the correct values", function () {
    var foodPosition = {
        x: 50,
        y: 13
    }
    var foodSize = 10;
    var foodFillColor = "#0000ff";
    var foodStrokeColor = "#00ff00";

    var food = new snakeGame.Food(foodPosition, foodSize);
    equal(food.fcolor, foodFillColor);
    equal(food.scolor, foodStrokeColor);
    equal(food.position.x, foodPosition.x);
    equal(food.position.y, foodPosition.y);
    equal(food.size, foodSize);
});

test("Initializing the food at position 0x0", function () {
    var foodPosition = {
        x: 0,
        y: 0
    }
    var foodSize = 10;
    var food = new snakeGame.Food(foodPosition, foodSize);
    equal(food.position.x, foodPosition.x);
    equal(food.position.y, foodPosition.y);
    equal(food.size, foodSize);
});

test("Initializing the food at position 300x300", function () {
    var foodPosition = {
        x: 300,
        y: 300
    }
    var foodSize = 10;
    var food = new snakeGame.Food(foodPosition, foodSize);
    equal(food.position.x, foodPosition.x);
    equal(food.position.y, foodPosition.y);
    equal(food.size, foodSize);
});