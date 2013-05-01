 Function.prototype.inherit = function(parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
};

function Person(name,age){
	this.name = name;
	this.age = age;

	this.toString = function(){
		var str ="";
		for (var prop in this){
			if(this.hasOwnProperty(prop) && (typeof this[prop]!=='function')){
				str+= "{"+prop+": "+this[prop]+"}, ";
			}
		}

		return str.substring(0,str.length-2);
	};
}

function Student(name,age,grade){
	Person.apply(this,arguments);
	this.grade = grade;
}


Student.inherit(Person);

var st = new Student("Pesho",22,4);
console.log(st.toString());
console.log(st instanceof Student);
console.log(st instanceof Person);