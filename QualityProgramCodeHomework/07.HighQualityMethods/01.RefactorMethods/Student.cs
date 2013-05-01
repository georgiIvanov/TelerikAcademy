using System;

namespace Methods
{
    class Student
    {
        string firstName, lastName, otherInfo;

        public Student(string firstName, string lastName, string otherInfo = "")
        {
            if (firstName == null || firstName == "" ||
                lastName == null || lastName == "")
            {
                throw new ArgumentException("Names cannot be null or empty");
            }

            this.firstName = firstName;
            this.lastName = lastName;
            this.otherInfo = otherInfo;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
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
