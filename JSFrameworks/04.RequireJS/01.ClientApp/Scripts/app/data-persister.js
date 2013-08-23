define(["httpRequester"], function (httpRequester) {
    function getStudents() {
        var url = this.url + "api/students/";
        return httpRequester.getJSON(url);
    }

    function getMarksByStudentId(studentId) {
        var url = this.url + "api/students/" + studentId + "/marks/";
        return httpRequester.getJSON(url);
    }

    return {
        students: getStudents,
        marks: getMarksByStudentId,
        url: this.url
    }
});