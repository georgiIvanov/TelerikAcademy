var iife = function(){
	console.log("invoked!");
}();

(function(){
	console.log("invoked!");
}());

(function(){
	console.log("invoked!");
})();

!function(){
	console.log("invoked!");
}();