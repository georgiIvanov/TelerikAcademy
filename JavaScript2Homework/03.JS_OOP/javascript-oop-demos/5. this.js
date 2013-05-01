function Person(name) {
	//var self = this;
	//self.name = name;
  this.name = name;
  //self.getName =
  this.getName = 
  	function getPersonName() {
    	return this.name;
    	//return self.name;
  	}
} 
var p = new Person("Gosho");
var getName = p.getName;
console.log(p.getName()); //Gosho
console.log(getName()); //undefined