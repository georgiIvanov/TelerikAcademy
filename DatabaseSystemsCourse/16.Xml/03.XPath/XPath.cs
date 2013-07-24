using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _03.XPath
{
    class XPath
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            document.Load("..\\..\\..\\catalogue.xml");
            Dictionary<string, int> albumsCount = new Dictionary<string, int>();

            var albums = document.SelectNodes("catalogue/album");

            foreach (XmlElement album in albums)
            {
                string artist = album.SelectSingleNode("artist").InnerText;
                if (albumsCount.ContainsKey(artist))
                {
                    albumsCount[artist]++;
                }
                else
                {
                    albumsCount.Add(artist, 1);
                }
            }

            foreach (var album in albumsCount)
            {
                Console.WriteLine("Artist: {0}, Albums: {1}", album.Key, album.Value);
            }
        }
    }
}
