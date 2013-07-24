using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace _14.CreateXMLFromXSL
{
    class CreateXMLFromXSL
    {
        static void Main(string[] args)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../cat.xslt");
            xslt.Transform("../../catalogue.xml", "../../catalogue.html");
        }
    }
}
