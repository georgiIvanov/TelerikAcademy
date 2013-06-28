var calculator = {
  sum: function (a, b) {
    return a + b;
  },
  substract: function(a, b){
    return a - b;
  },
  divide: function(a, b){
    if(b === 0){
      throw "Division by 0 is not allowed"
    };
    return a / b; 
  },
  multiply: function(a, b){
    return a * b;
  }
}
