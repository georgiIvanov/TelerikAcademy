using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.StudentsForm
{
    public partial class submittedStudent : System.Web.UI.UserControl
    {
        public submittedStudent()
        {
        }

        public submittedStudent(string firstName, string lastName, string facultyNumber, string university, string specialty )
        {
            this.firstName.InnerHtml = firstName;
            this.lastName.InnerHtml = lastName;
            this.facultyNumber.InnerHtml = facultyNumber;
            this.university.InnerHtml = university;
            this.specialty.InnerHtml = specialty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}