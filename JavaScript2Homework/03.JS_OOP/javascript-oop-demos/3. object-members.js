function Person(name,age){
  this.name = name;
  this.age = age;
  this.sayHello = function(){
    console.log("My name is " + this.name + " and I am " + 
          this.age + "-years old");
  }
}
var maria = new Person("Maria",18);
maria.sayHello();
