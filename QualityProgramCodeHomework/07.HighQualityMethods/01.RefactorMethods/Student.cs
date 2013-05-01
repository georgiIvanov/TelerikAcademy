using System;
using System.Linq.Expressions;

namespace Methods
{
    class Student
    {
        string firstName, lastName, otherInfo;

        public Student(string firstName, string lastName, string otherInfo = null)
        {
            if (firstName == null || firstName == "")
            {
                throw new ArgumentException("Names cannot be null or empty", "firstName");
            }

            if (lastName == null || lastName == "")
            {
                throw new ArgumentException("Names cannot be null or empty", "lastName");
            }

            this.firstName = firstName;
            this.lastName = lastName;
            this.otherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Names cannot be null or empty", "firstName");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Names cannot be null or empty", "lastName");
                }
                lastName = value;
            }
        }

        public string OtherInfo
        {
            get { return otherInfo; }
            set { otherInfo = value; }
        }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate, secondDate;
            if (DateTime.TryParse(this.OtherInfo.Substring(this.OtherInfo.Length - 10), out firstDate) &&
                DateTime.TryParse(other.OtherInfo.Substring(other.OtherInfo.Length - 10), out secondDate))
            {
                bool isOlderThan = firstDate > secondDate;
                return isOlderThan;
            }
            else
            {
                throw new InvalidOperationException("Could not parse date");
            }
        }
    }
}
