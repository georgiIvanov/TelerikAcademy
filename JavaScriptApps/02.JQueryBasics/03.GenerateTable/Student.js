var Student = (function () {
    function init(fname, lname, grade) {
        this.fname = fname;
        this.lname = lname;
        this.grade = grade;
    }

    return {
        init: init,
    }
})();