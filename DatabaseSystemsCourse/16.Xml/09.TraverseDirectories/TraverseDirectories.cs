using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _09.TraverseDirectories
{
    class TraverseDirectories
    {
        static void Main()
        {
            string folderLocation = "../../";
            string outpitFile = "../../directory.xml";
            DirectoryInfo dir = new DirectoryInfo(folderLocation);

            using (XmlTextWriter writer = new XmlTextWriter(outpitFile,  Encoding.GetEncoding("windows-1251")))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");
                CreateXML(writer, dir);
                writer.WriteEndDocument();
            }

            Console.WriteLine("Directory.xml is created in the project directory.");
        }
        private static void CreateXML(XmlTextWriter writer, DirectoryInfo dir)
        {

            foreach (var file in dir.GetFiles())
            {
                string xml = new XElement("file", new XAttribute("name", file.Name)).ToString();
                XmlReader reader = XmlReader.Create(new StringReader(xml));
                writer.WriteNode(reader, true);
            }

            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);
            foreach (var subDir in subdirectories)
            {
                CreateSubdirectoryXML(writer, subDir);
            }
        }

        private static void CreateSubdirectoryXML(XmlTextWriter writer, DirectoryInfo dir)
        {

            string xml = new XElement("dir", new XAttribute("name", dir.Name)).ToString();
            XmlReader reader = XmlReader.Create(new StringReader(xml));
            writer.WriteNode(reader, true);

            foreach (var file in dir.GetFiles())
            {
                xml = new XElement("file", new XAttribute("name", file.Name)).ToString();
                reader = XmlReader.Create(new StringReader(xml));
                writer.WriteNode(reader, true);
            }

            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);
            foreach (var subDir in subdirectories)
            {
                CreateSubdirectoryXML(writer, subDir);
            }
        }
    }
}
