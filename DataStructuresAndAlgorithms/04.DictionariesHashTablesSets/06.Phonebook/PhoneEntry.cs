using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Phonebook
{
    class PhoneEntry
    {
        string firstName, middleName, lastName;
        string town;
        string phoneNumber;

        public PhoneEntry(string firstName, string city, string phoneNumber, string lastName = "", string middleName = "")
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Town = city;
            this.PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            string entryToString = string.Empty;

            if (middleName == "" && lastName == "")
            {
                entryToString = string.Format("{0} {1} {2}", firstName, town, phoneNumber);
            }
            else if (middleName == "")
            {
                entryToString = string.Format("{0} {1} {2} {3}", firstName, lastName, town, phoneNumber);
            }
            else
            {
                entryToString = string.Format("{0} {1} {2} {3} {4}", firstName, middleName, lastName, town, phoneNumber);
            }

            return entryToString;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                this.lastName = value;
            }
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            private set
            {
                this.town = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            private set
            {
                this.phoneNumber = value;
            }
        }
    }
}
