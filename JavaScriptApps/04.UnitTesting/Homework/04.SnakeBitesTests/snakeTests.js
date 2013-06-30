test("When snake is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    equal(position, snake.position, "Position is set");
    equal(speed, snake.speed, "Speed is set");
    equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    ok(snake.pieces, "SnakePieces are created");
    equal(snake.pieces.length, 5, "Five SnakePieces are created");
    ok(snake.head, "HeadSnakePiece is created");
});


module("Snake.Consume");
test("When object is Food, should grow", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);
    var size = snake.size;
    snake.consume(new snakeGame.Food());
    var actual = snake.size;
    var expected = size + 1;
    equal(actual, expected);
});

test("When object is SnakePiece, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.SnakePiece());
    ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.Obstacle());
    ok(isDead, "The snake is dead");
});

module("Snake.grow");
test("When the snake grow, the new size shoud be greater than old size", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);
    var oldsize = snake.size;
    snake.grow();
    var newsize = snake.size;
    ok(newsize > oldsize, "The snake is grow");
});

module("Snake.grow");
test("When the snake grow, the pieces should be more", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);
    var oldpieces = snake.pieces.length;
    snake.grow();
    var newpieces = snake.pieces.length;
    ok(newpieces = oldpieces + 1, "The snake has more pieces");
});

module("Snake.checkSelfEating");
test("The snake must die, when it bites itself", function () {
    var iniposition = {
        x: 1,
        y: 3
    }
    var snake = new snakeGame.Snake(iniposition, 8, 0);
    snake.pieces[4].position.x = iniposition.x;
    snake.pieces[4].position.y = iniposition.y;
    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.checkSelfEating();
    ok(isDead, "The snake is dead");
});