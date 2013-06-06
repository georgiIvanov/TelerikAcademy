var Person = {
    init: function (fname, lname, age) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
    },
    introduce: function () {
        return "Name: " + this.fname + " " + this.lname +
            ", Age: " + this.age;
    }
};

var Student = Person.extend({
    init: function (fname, lname, age, grade) {
        this._super = Object.create(this._super);
        this._super.init(fname, lname, age);
        this.grade = grade;
    },
    introduce: function () {
        return this._super.introduce() + ", grade: " + this.grade;
    }
});

var Teacher = Person.extend({
    init: function (fname, lname, age, specialty) {
        this._super = Object.create(this._super);
        this._super.init(fname, lname, age);
        this.specialty = specialty;
    },
    introduce: function () {
        return this._super.introduce() + ", specialty: " +
            this.specialty;
    }
});

var School = {
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    },
    introduce: function () {
        var intro = "Name: " + this.name + ", Town: " + this.town +
            ", Classes: ";
        for (var i = 0; i < this.classes.length; i++) {
            intro += this.classes[i].name + " ";
        }
        return intro.substr(0, str.length - 2);
    }
};

var Course = {
    init: function (name, capacity, students, fromTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.fromTeacher = fromTeacher;
    },
    introduce: function () {
        var intro = "Name: " + this.name + ", Capacity: " + this.capacity +
            ", Students: ";
        for (var i = 0; i < this.students.length; i++) {
            intro += this.students[i].introduce() + ", ";
        }
        intro += "Teacher: " + this.fromTeacher.introduce();
        return intro;
    }
};