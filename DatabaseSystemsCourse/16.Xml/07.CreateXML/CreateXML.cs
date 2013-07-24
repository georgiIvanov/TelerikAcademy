using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _07.CreateXML
{
    class CreateXML
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("..\\..\\contacts.txt");
            XElement personXml = new XElement("contacts");

            while (!sr.EndOfStream)
            {

                string name = sr.ReadLine();
                string address = sr.ReadLine();
                string phone = sr.ReadLine();

                personXml.Add(
                    new XElement("contact",
                        new XElement("name", name),
                        new XElement("address", address),
                        new XElement("phone", phone)
                        ));
            }

            Console.WriteLine(personXml);
            personXml.Save("..\\..\\contacts.xml");
        }
    }
}
