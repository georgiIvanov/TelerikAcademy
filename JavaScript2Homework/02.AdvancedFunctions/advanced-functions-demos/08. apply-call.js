var numbers = [1,3,4,5,6,2,1,3,4,5,6];

function printMsg(msg){
  console.log("Message: " + msg);  
}
printMsg.apply(null, ["Important message"]);
var max = Math.max.apply (null, numbers);

console.log(max);
//here this is null, since it is not used anywhere in //the function
//more about this in OOP
