var Person = Class.create({
    init: function (fname, lname, age) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
    },
    introduce: function () {
        return "Name: " + this.fname + " " + this.lname +
            ", Age: " + this.age;
    }
});

var Student = Class.create({
    init: function (fname, lname, age, grade) {
        this._super = new this._super(arguments);
        this._super.init(fname, lname, age);
        this.grade = grade;
    },
    introduce: function () {
        return this._super.introduce() + ", grade: " + this.grade;
    }
});

Student.inherit(Person);

var Teacher = Class.create({
    init: function (fname, lname, age, specialty) {
        this._super = new this._super(arguments);
        this._super.init(fname, lname, age);
        this.specialty = specialty;
    },
    introduce: function () {
        return this._super.introduce() + ", specialty: " + this.specialty;
    }
});

Teacher.inherit(Person);

var School = Class.create({
    init: function (name, town, classes) {
        this.name = name;
        this.town = town;
        this.classes = classes;
    },
    introduce: function () {
        var str = "Name: " + this.name + ", Town: " + this.town + ", Classes:";
        for (var i = 0; i < this.classes.length; i++) {
            str += this.classes[i].name + ", ";
        }
        return str.substr(0, str.length - 2);
    }
});

var Course = Class.create({
    init: function (name, capacity, students, fromTeacher) {
        this.name = name;
        this.capacity = capacity;
        this.students = students;
        this.fromTeacher = fromTeacher;
    },
    introduce: function () {
        var str = "Name: " + this.name + ", Capacity: " + this.capacity +
        ", Students: ";
        for (var i = 0; i < this.students.length; i++) {
            str += this.students[i].introduce() + ", ";
        }
        str += "From teacher: " + this.fromTeacher.introduce();
        return str;
    }
});