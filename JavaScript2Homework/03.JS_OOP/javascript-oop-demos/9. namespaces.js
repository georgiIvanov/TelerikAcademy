var schoolNS = (function() {﻿﻿﻿
    Function.prototype.inherit = function(parent) {
        this.prototype = new parent();
        this.prototype.constructor = parent;
    };

    function Person(name, age) {
        var self = this;
        var _name = name;
        var _age = age;

        self.getName = function getPersonName() {
            return _name;
        };

        self.getAge = function getPersonAge() {
            return _age;
        };
    }

    function Student(name, age, grade) {
        var self = this;
        Person.call(self, name, age);
        
        var _grade = grade;
        var _marks = [];

        self.getGrade = function getStudentGrade() {
            return _grade;
        };

        self.addMark = function addStudentMark(subject, score) {
            _marks.push({
                subject: subject,
                score: score
            });
        };
        self.getMarks = function getStudentMarks() {
            return _marks.slice(0);
        };
    }

    Student.inherit(Person);

    function Teacher(name, age, specialty) {
        var self = this;
        Person.call(self, name, age);
      
        var _specialty = specialty;

        self.getSpecialty = function() {
          return _specialty;
        };
    }
    Teacher.inherit(Person);

    function Class(name) {
        var self = this;
        var _name = name;
        var _students = [];

        self.getName = function getSchoolName() {
            return _name;
        };  

        self.addStudent = function(student) {
            _students.push(student);
        };

        self.getStudents = function getClassStudents() {
            return _students.slice(0);
        };
    }

    function School(name) {
        var self = this;
        var _name = name;
        var _classes = [];

        self.getName = function getSchoolName() {
            return _name;
        };

        self.addClass = function(cl) {
            _classes.push(cl);
        };

        self.getClasses = function getSchoolClasses() {
            return _classes.slice(0);
        };
    }

    return {
        Person: Person,
        Student: Student,
        Teacher: Teacher,
        Class: Class,
        School: School
    };
}());


var student = new schoolNS.Person("Gosho",23);