//var factoria; = function calcFactorial(n)
var factorial = function (n) {
  if (n == 1) {
    return 1;
  }
  return n * factorial (n - 1);
};

console.log(factorial(5)); //logs 120 - correct
var factorial2 = factorial;
console.log(factorial2(5)); //logs 120 - correct
factorial = 5;
console.log(factorial2(5)); //TypeError
