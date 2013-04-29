function arrJoin(arr, separator) {
  separator = separator || "";
  arr = arr || [];
  arrString = "";
  for (var i = 0; i < arr.length; i += 1) {
    arrString += arr[i];
    if (i < arr.length - 1) arrString += separator;
  }
  return arrString;
}

console.log(arrJoin([1,2,3,4,5]));
console.log((arrString))

