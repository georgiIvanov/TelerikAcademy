//printMsg("Before declaration");
var printMsg = new Function("msg", "console.log('Message: ' + msg);");
printMsg("After declaration");