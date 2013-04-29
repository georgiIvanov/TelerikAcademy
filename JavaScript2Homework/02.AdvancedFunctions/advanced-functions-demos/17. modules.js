var school = (function() {
    var students = [];
    var teachers = [];
    function addStudent(name, grade) {
        students.push({name:name,grade:grade});
    }
    function addTeacher(name, specialty) {
        students.push({name:name,specialty:specialty});    
    }
    function getTeachers(speciality) {
        var selected = [];
        for (var i = 0; i < teachers.length; i++) {
            if((specialy && specialty == teachers[i].specialty) || (!specialty) ){
                selected.push(teachers[i]);
            }
        };
        return selected;
    }
    function getStudents(grade) {
        var selected = [];
        for (var i = 0; i < students.length; i++) {
            if((grade && grade == students[i].grade) || (!grade) ){
                selected.push(students[i]);
            }
        };   
        return selected;
   }
    return {
        addStudent: addStudent,
        addTeacher: addTeacher,
        getTeachers: getTeachers,
        getStudents: getStudents
    };
})();

school.addStudent("Peter",2);
school.addStudent("Georgi",4);
school.addStudent("Maria",3);
school.addStudent("Stamat",2);

console.log(school.getStudents());
console.log(school.getStudents(2));

