using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        int uid;
        string name;

        public Student(string name, int uid)
        {
            this.Name = name;
            this.GetUID = uid;
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }

        }

        public int GetUID
        {
            get
            {
                return this.uid;
            }
            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("uid", "unique id must be between 10000 and 99999");
                }
                this.uid = value;
            }
        }
    }
}
