test("calculator.sum, when 5 and 6, should return 11", function() {
  var a = 5;
  var b = 6;
  var actual = calculator.sum(a, b);
  var expected = a + b;
  equal(actual, expected);
});

test("calculator.substract, when 5 and 6, should return -1", function() {
  var a = 5;
  var b = 6;
  var actual = calculator.substract(a, b);
  var expected = a - b;
  equal(actual, expected);
});

test("calculator.divide, when 6 and 5, should return 1.2", function() {
  var a = 5;
  var b = 6;
  var actual = calculator.divide(a, b);
  var expected = a / b;
  equal(actual, expected);
});

test("calculator.divide, when 5 and 0, should throw exception", 
  function() {
  var a = 5;
  var b = 0;
  throws(function(){
    calculator.divide(a, b);
  });
});

test("calculator.multiply, when 5 and 0, should return 0", function() {
  var a = 5;
  var b = 0;
  var actual = calculator.multiply(a, b);
  var expected = 0;
  equal(actual, expected);
});

test("calculator.multiply, when 5 and 6, should return 30", function() {
  var a = 5;
  var b = 6;
  var actual = calculator.multiply(a, b);
  var expected = a * b;
  equal(actual, expected);
});