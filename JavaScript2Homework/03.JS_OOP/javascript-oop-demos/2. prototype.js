//adding a method to arrays to sum their number elements
Array.prototype.sum = function(){
  var sum = 0;
  for(var i = 0; i < this.length; i++){
    if(typeof this[i] === "number"){
      sum += this[i];
    }
  }
  return sum;
}

var numbers = [1,2,3,4,5];
console.log(numbers.sum());
//logs 15
