using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _10.TraverseDirsWIthXDoc
{
    class TraverseDirsWIthXDoc
    {
        static void Main()
        {
            string folderLocation = "..\\..\\";
            DirectoryInfo dir = new DirectoryInfo(folderLocation);
            var doc = new XDocument(CreateXML(dir));

            using (StreamWriter writer = new StreamWriter(folderLocation + "directory.xml"))
            {
                doc.Save(writer, SaveOptions.None);
            }

            Console.WriteLine("Directory.xml is created in the project directory.");
        }

        private static XElement CreateXML(DirectoryInfo dir)
        {
            var xmlInfo = new XElement("MyDirectories");


            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
            }


            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);

            foreach (var subDir in subdirectories)
            {
                xmlInfo.Add(CreateSubdirectoryXML(subDir));
            }

            return xmlInfo;
        }

        private static XElement CreateSubdirectoryXML(DirectoryInfo dir)
        {

            var xmlInfo = new XElement("dir", new XAttribute("name", dir.Name));


            foreach (var file in dir.GetFiles())
            {
                xmlInfo.Add(new XElement("file", new XAttribute("name", file.Name)));
            }


            var subdirectories = dir.GetDirectories().ToList().OrderBy(d => d.Name);
            foreach (var subDir in subdirectories)
            {
                xmlInfo.Add(CreateSubdirectoryXML(subDir));
            }

            return xmlInfo;
        }
    }
}
