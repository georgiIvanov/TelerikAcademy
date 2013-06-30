/// <reference path="snake.js" />
/// <reference path="qunit-1.11.0.js" />
module("MovingObjectTests");

test("Testing constructor correct initialization", function () {
    var position = { x: 5, y: 7 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 42,
        direction = 0;

    var movingObject = new snakeGame.MovingGameObject(
      position, size, fcolor, scolor, speed, direction);

    equal(movingObject.position, position, "Checking position");
    equal(movingObject.size, size, "Checking size");
    equal(movingObject.fcolor, fcolor, "Checking fcolor (fill color)");
    equal(movingObject.scolor, scolor, "Checking scolor (stroke color)");
    equal(movingObject.speed, speed, "Checking speed");
    equal(movingObject.direction, direction, "Checking direction");
});

// o6te 5-6 razli4ni varianta na init
test("Testing constructor correct initialization at position 0x0", function () {
    var position = { x: 0, y: 0 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 42,
        direction = 0;

    var movingObject = new snakeGame.MovingGameObject(
      position, size, fcolor, scolor, speed, direction);

    equal(movingObject.position, position, "Checking position");
});
test("Testing constructor correct initialization at position 200x200", function () {
    var position = { x: 200, y: 200 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 42,
        direction = 0;

    var movingObject = new snakeGame.MovingGameObject(
      position, size, fcolor, scolor, speed, direction);

    equal(movingObject.position, position, "Checking position");
});


module("MovingGameObject.move")
test("Move negative X (direction 0)", function () {
    var position = { x: 0, y: 0 },
        size = 5,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 1,
        direction = 0;

    var movingObject = new snakeGame.MovingGameObject(
      position, size, fcolor, scolor, speed, direction);

    var expected = { x: position.x - speed, y: position.y };
    movingObject.move();
    deepEqual(movingObject.position, expected);
});

test("Move positive X (direction 2)", function () {
    var position = { x: 0, y: 0 },
        size = 1,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 1,
        direction = 2;

    var movingObject = new snakeGame.MovingGameObject(
      position, size, fcolor, scolor, speed, direction);

    var expected = { x: position.x + speed, y: position.y };
    movingObject.move();
    deepEqual(movingObject.position, expected);
});

test("Move negative Y (direction 1)", function () {
    var position = { x: 0, y: 0 },
        size = 1,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 1,
        direction = 1;

    var movingObject = new snakeGame.MovingGameObject(
      position, size, fcolor, scolor, speed, direction);

    var expected = { x: position.x, y: position.y - speed };
    movingObject.move();
    deepEqual(movingObject.position, expected);
});

test("Move positive Y (direction 3)", function () {
    var position = { x: 0, y: 0 },
        size = 1,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 1,
        direction = 3;

    var movingObject = new snakeGame.MovingGameObject(
      position, size, fcolor, scolor, speed, direction);

    var expected = { x: position.x, y: position.y + speed };
    movingObject.move();
    deepEqual(movingObject.position, expected);
});

test("Move positive Y, speed 3", function () {
    var position = { x: 0, y: 0 },
        size = 1,
        fcolor = "#000000",
        scolor = "#000000",
        speed = 3,
        direction = 3;

    var movingObject = new snakeGame.MovingGameObject(
      position, size, fcolor, scolor, speed, direction);

    var expected = { x: position.x, y: position.y + speed };
    movingObject.move();
    deepEqual(movingObject.position, expected);
});


(function () {

    // Inititalizing some objects, common for following tests
    // Invoked before the execution of each test
    QUnit.testStart(function () {
        var position = { x: 0, y: 0 }, size = 1, fcolor = "#000000", scolor = "#000000", speed = 3, direction = 0;
        testedMovingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
    });

    var testedMovingObject;

    module("MovingGameObject.changeDirection, starting from 0")
    test("Change to 1 (should succeed)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 0;
        var newDirection = 1;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 3 (should succeed)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 0;
        var newDirection = 3;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 0 (no change)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 0;
        var oldDirection = movingObject.direction;
        var newDirection = 0;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 2 (no change)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 0;
        var oldDirection = movingObject.direction;
        var newDirection = 2;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    module("MovingGameObject.changeDirection, starting from 1")
    test("Change to 0 (should succeed)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 1;
        var newDirection = 0;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 2 (should succeed)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 1;
        var newDirection = 2;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 3 (no change)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 1;
        var oldDirection = movingObject.direction;
        var newDirection = 3;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 1 (no change)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 1;
        var oldDirection = movingObject.direction;
        var newDirection = 1;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    module("MovingGameObject.changeDirection, starting from 2")
    test("Change to 1 (should succeed)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 2;
        var newDirection = 1;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 3 (should succeed)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 2;
        var newDirection = 3;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 0 (no change)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 2;
        var oldDirection = movingObject.direction;
        var newDirection = 0;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 2 (no change)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 2;
        var oldDirection = movingObject.direction;
        var newDirection = 2;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    module("MovingGameObject.changeDirection, starting from 3")
    test("Change to 0 (should succeed)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 3;
        var newDirection = 0;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 2 (should succeed)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 3;
        var newDirection = 2;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, newDirection);
    });

    test("Change to 1 (no change)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 3;
        var oldDirection = movingObject.direction;
        var newDirection = 1;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    test("Change to 3 (no change)", function () {
        var movingObject = testedMovingObject;
        movingObject.direction = 3;
        var oldDirection = movingObject.direction;
        var newDirection = 3;
        movingObject.changeDirection(newDirection);
        equal(movingObject.direction, oldDirection);
    });

    // Clear previously registered callbacks
    QUnit.testStart(function () { });
}());