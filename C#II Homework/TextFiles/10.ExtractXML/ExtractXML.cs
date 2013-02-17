using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace _10.ExtractXML
{
    class ExtractXML
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../file.xml");

            XmlElement docElement = doc.DocumentElement;

            foreach (XmlNode childNode in docElement.ChildNodes)
            {
                Console.WriteLine(childNode.InnerText);
            }

        }
    }
}
