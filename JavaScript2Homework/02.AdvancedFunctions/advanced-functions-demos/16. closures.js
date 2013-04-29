function outer(x){
  function inner(y){
    return x + " " + y;
  }
  return inner;
}
var f1 = outer(5);
console.log(f1(7)); //outputs 5 7
//in the context of f1, x has value 5
var f2 = outer("Peter");
console.log(f2("Petrov"));  //outputs Peter Petrov
//in the context of f2, x has value "Peter"
