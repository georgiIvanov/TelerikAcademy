using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04.DeleteAlbums
{
    class DeleteAlbums
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            document.Load("..\\..\\..\\catalogue.xml");

            var albums = document.SelectNodes("catalogue/album");

            foreach (XmlNode item in albums)
            {
                if (decimal.Parse(item["price"].InnerText) > 20)
                {
                    item.ParentNode.RemoveChild(item);
                }
            }

            Console.WriteLine("New xml: ");
            Console.WriteLine(document.OuterXml);

            document.Save("..\\..\\newCatalogue.xml");
        }
    }
}
