function max (arr) {
  var maxValue = arr[0];
  for 	(var i = 1; i < arr.length; i++) {
    maxValue = Math.max(maxValue, arr[i]);
  }  
  return maxValue;
}

function printMsg(msg){
  console.log(msg);
}

printMsg(max([1,2,3,4,45,5,6,]));