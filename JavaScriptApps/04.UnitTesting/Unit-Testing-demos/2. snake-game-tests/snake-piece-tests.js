module("SnakePiece.init");
test("should set correct values",   
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    equal(piece.position, position)
    equal(piece.size, 15);
    equal(piece.speed, speed);
    equal(piece.direction, dir);
  });

module("SnakePiece.move");
test("When direction is 0, decrease x",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    piece.move();
    position.x - speed;
    deepEqual(piece.position, position);
  });
test("When  direction is 1, decrease update y",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    piece.move();
    position.y - speed;
    deepEqual(piece.position, position);
  });
test("When  direction is 2, increase x",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    piece.move();
    position.x + speed;
    deepEqual(piece.position, position);
  });
test("When  direction is 3, should increase x",
  function(){
    var position = {x: 150, y: 150}, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakePiece(position, size, speed, dir);
    piece.move();
    position.y + speed;
    deepEqual(piece.position, position);
  });