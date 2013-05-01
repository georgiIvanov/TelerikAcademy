using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    class OffsiteCourse : Course
    {
        string town;

        public OffsiteCourse(string name, string town = null, string teacherName = null, IList<string> students = null) 
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town 
        {
            get
            {
                return this.town;
            }
            set
            {
                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.Name);

            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }
            result.Append(" }");

            return result.ToString();
        }
    }
}
