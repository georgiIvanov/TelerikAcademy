using FormatConvert;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // convert xml string to json string
            string personJson = FormatConverter.XmlToJsonAsString(xmlString);
            Console.WriteLine("{0}\n", personJson);


            // convert xml string to JObject
            JObject jobj = FormatConverter.XmlToJsonAsJObject(xmlString);
            Console.WriteLine(jobj);


            // convert json string to XmlDocument
            XmlDocument personXml = FormatConverter.JsonToXml(personJson);
            PrintXML(personXml);

            // convert xml document to json
            string json = FormatConverter.XmlToJsonAsString(personXml);
            Console.WriteLine("\n{0}\n", json);
            

            // convert JObject to Xml Document
            XmlDocument result = FormatConverter.JsonToXml(jobj);
            PrintXML(result);
        }

        private static void PrintXML(XmlDocument personXml)
        {
            foreach (XmlNode node in personXml)
            {
                foreach (XmlNode inner in node.ChildNodes)
                {
                    Console.WriteLine("{0}: {1}", inner.Name, inner.InnerText);
                }
            }
        }

        const string xmlString = @"<person>
  <firstName>John</firstName>
  <lastName>Smith</lastName>
  <age>25</age>
  <address>
    <streetAddress>21 2nd Street</streetAddress>
    <city>New York</city>
    <state>NY</state>
    <postalCode>10021</postalCode>
  </address>
  <phoneNumbers>
    <phoneNumber type=""home"">212 555-1234</phoneNumber>
    <phoneNumber type=""fax"">646 555-4567</phoneNumber>
  </phoneNumbers>
</person>";
    }
}