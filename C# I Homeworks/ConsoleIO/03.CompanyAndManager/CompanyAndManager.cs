using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.CompanyAndManager
{
    class CompanyAndManager
    {
        static void Main(string[] args)
        {
            List<Company> listOfCompanies = new List<Company>();

            Company veryBigAndImportantCompany = new Company("lala", "NoWhere", "http://lala", 8888888, 323242);
            veryBigAndImportantCompany.AddManager("Petar", "Maimunski", null, 666);

            listOfCompanies.Add(veryBigAndImportantCompany);

            Console.Write("Enter company name: ");
            string searchCompany = Console.ReadLine();
            Console.Write("Enter manager's last name: ");
            string searchManager = Console.ReadLine();

            foreach (var item in listOfCompanies)
            {
                if (item.CheckNameOfCompany(searchCompany) == true
                    && item.CheckManager(searchManager) == true)
                {
                    Console.WriteLine(item.ShowCompany());
                }
            }
        }
    }

    class Company
    {
        string nameOfCompany, address, website;
        int phoneNumber, fax;
        Manager managerOfCompany;
        

        public Company(string nameOfCompany, string address, string website, int phoneNumber, int fax)
        {
            this.nameOfCompany = nameOfCompany;
            this.address = address;
            this.website = website;
            this.phoneNumber = phoneNumber;
            this.fax = fax;
        }

        public void AddManager(string firstName, string lastName, int? age, int? phoneNumber)
        {
            managerOfCompany = new Manager(firstName, lastName, age, phoneNumber);
        }

        public bool CheckManager(string lastName)
        {
            if(string.Compare(managerOfCompany.ManagerLastName(), lastName) == 0)
            {
                return true;
            }
            return false;
        }

        public bool CheckNameOfCompany(string nameOfCompany)
        {
            
            if (string.Compare(this.nameOfCompany, nameOfCompany) == 0)
            {
                return true;
            }
            return false;
        }

        public string ShowCompany()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Company name: ");
            sb.AppendLine(nameOfCompany);
            sb.Append("Company address: ");
            sb.AppendLine(address);
            sb.Append("Website: ");
            sb.AppendLine(website);
            sb.Append("Phone: ");
            sb.AppendLine(phoneNumber.ToString());
            sb.Append("Fax: ");
            sb.AppendLine(fax.ToString());
            sb.AppendLine("---=== Manager ===---");
            sb.Append(managerOfCompany.InfoAboutManager());
            return sb.ToString();
        }
    }

    class Manager
    {
        string firstName, lastName;
        int? age, phoneNumber;

        public Manager()
        {

        }

        public Manager(string firstName, string lastName, int? age, int? phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.phoneNumber = phoneNumber;
        }

        public void AddInfoForManager(string firstName, string lastName, int? age, int? phoneNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.phoneNumber = phoneNumber;
        }

        public string InfoAboutManager()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("First name: ");
            sb.AppendLine(firstName);
            sb.Append("Last name: ");
            sb.AppendLine(lastName);
            sb.Append("Age: ");
            sb.AppendLine(age.ToString());
            sb.Append("Phone: ");
            sb.AppendLine(phoneNumber.ToString());
            return sb.ToString();
        }

        public string ManagerLastName()
        {
            return this.lastName;
        }

    }
}
