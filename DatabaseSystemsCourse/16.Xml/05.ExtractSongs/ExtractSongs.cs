using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _05.ExtractSongs
{
    class ExtractSongs
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Songs titles in the catalogue:");
            using (XmlReader reader = XmlReader.Create("..\\..\\..\\catalogue.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "name"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }
    }
}
