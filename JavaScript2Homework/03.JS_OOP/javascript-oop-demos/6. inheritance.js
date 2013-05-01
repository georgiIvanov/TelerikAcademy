function Person(name, age){ 
  this.name = name; 
  this.age = age; 
}

function Student(name, age, grade){
  Person.apply(this, arguments); 
  //Person.call(this, name, age);
  this.grade = grade;
}

Student.prototype = new Person();
Student.prototype.constructor = Student; 

