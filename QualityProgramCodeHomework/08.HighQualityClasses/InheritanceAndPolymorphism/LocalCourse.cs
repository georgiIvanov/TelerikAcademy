using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class LocalCourse : Course
    {
        string lab;

        public LocalCourse(string name, string lab = null, string teacherName = null, IList<string> students = null)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab 
        {
            get
            {
                return this.lab;
            }
            set
            {
                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(this.Name);

            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");
            return result.ToString();
        }
    }
}
