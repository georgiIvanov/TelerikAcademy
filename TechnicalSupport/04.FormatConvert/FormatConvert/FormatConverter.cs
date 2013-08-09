using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FormatConvert
{
    /// <summary>
    /// Provides static methods for convertion from json to xml and vice-versa
    /// </summary>
    public static class FormatConverter
    {
        /// <summary>
        /// Converts JSON to Xml Document
        /// </summary>
        /// <param name="documentToConvert">JSON as string</param>
        /// <returns>XML Document object</returns>
        public static XmlDocument JsonToXml(string documentToConvert)
        {
            if (string.IsNullOrWhiteSpace(documentToConvert))
            {
                throw new InvalidOperationException("You must first provide document as string");
            }

            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(documentToConvert);

            return doc;
        }

        /// <summary>
        /// Converts JSON to Xml Document
        /// </summary>
        /// <param name="jsonObject">JSON as JObject</param>
        /// <returns>XML Document object</returns>
        public static XmlDocument JsonToXml(JObject jsonObject)
        {
            if (jsonObject == null)
            {
                throw new InvalidOperationException("You must first provide document as JObject");
            }

            return JsonToXml(jsonObject.ToString());
        }


        /// <summary>
        /// Converts XML string to JSON
        /// </summary>
        /// <param name="documentToConvert">XML as string</param>
        /// <returns>JSON as string</returns>
        public static string XmlToJsonAsString(string documentToConvert)
        {
            if (string.IsNullOrWhiteSpace(documentToConvert))
            {
                throw new InvalidOperationException("You must first provide document as string");
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(documentToConvert);
            string jsonText = JsonConvert.SerializeXmlNode(doc);


            return jsonText;
        }

        /// <summary>
        /// Converts XML string to JSON
        /// </summary>
        /// <param name="documentToConvert">XML Document</param>
        /// <returns>JSON as string</returns>
        public static string XmlToJsonAsString(XmlDocument doc)
        {
            if (doc == null)
            {
                throw new InvalidOperationException("You must first provide document as XmlDocument");
            }
            string jsonText = JsonConvert.SerializeXmlNode(doc);

            return jsonText;
        }

        /// <summary>
        /// Converts XML string to JObject
        /// </summary>
        /// <param name="documentToConvert">XML as XmlDocument</param>
        /// <returns>JObject</returns>
        public static JObject XmlToJsonAsJObject(XmlDocument doc)
        {
            if (doc == null)
            {
                throw new InvalidOperationException("You must first provide document as XmlDocument");
            }
            string jsonText = JsonConvert.SerializeXmlNode(doc);

            return JObject.Parse(jsonText);
        }

        /// <summary>
        /// Converts XML string to JObject
        /// </summary>
        /// <param name="documentToConvert">XML as string</param>
        /// <returns>JObject</returns>
        public static JObject XmlToJsonAsJObject(string documentToConvert)
        {
            if (string.IsNullOrWhiteSpace(documentToConvert))
            {
                throw new InvalidOperationException("You must first provide document as XmlDocument");
            }
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(documentToConvert);
            string jsonText = JsonConvert.SerializeXmlNode(doc);

            return JObject.Parse(jsonText);
        }

    }
}
