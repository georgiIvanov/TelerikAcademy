using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _08.Album
{
    class Album
    {
        static void Main()
        {
            string fileName = "../../album.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            XmlTextWriter writer = new XmlTextWriter(fileName, encoding);
            using (writer)
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("albums");

                string name = string.Empty;
                using (XmlReader reader = XmlReader.Create("..\\..\\..\\catalogue.xml"))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "name"))
                        {
                            name = reader.ReadElementString();
                        }
                        else if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "artist"))
                        {
                            string artist = reader.ReadElementString();
                            WriteBook(writer, name, artist);
                        }
                    }
                }
                writer.WriteEndDocument();
                Console.WriteLine("Album.xml is created in the project directory.");
            }
        }
        private static void WriteBook(XmlWriter writer, string name, string artist)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteEndElement();
        }
    }
}
