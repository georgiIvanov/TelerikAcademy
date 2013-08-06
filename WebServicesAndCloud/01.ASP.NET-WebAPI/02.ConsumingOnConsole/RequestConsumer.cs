using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;


namespace _02.ConsumingOnConsole
{
    class RequestConsumer
    {
        static HttpClient client = new HttpClient();

        public RequestConsumer(string baseUrl)
        {
            this.BaseURL = baseUrl;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string BaseURL { get; set; }

        public string CreateAsJson<T>(T obj, string controller)
        {
            var sent = client.PostAsJsonAsync<T>(BaseURL + controller, obj).Result;

            return sent.Content.ReadAsStringAsync().Result;
        }

        public string CreateAsXML<T>(T obj, string controller)
        {
            var sent = client.PostAsXmlAsync<T>(BaseURL + controller, obj).Result;

            return sent.Content.ReadAsStringAsync().Result;
        }

        public string Read(string controller)
        {
            var recieved = client.GetAsync(BaseURL + controller).Result;

            var recievedString = recieved.Content.ReadAsStringAsync().Result;

            JArray jsonArray = JArray.Parse(recievedString);

            return JsonArrayToString(jsonArray);
        }

        public string Read(string controller, string id)
        {
            var recieved = client.GetAsync(BaseURL + controller + "/" + id).Result;

            var recievedString = recieved.Content.ReadAsStringAsync().Result;

            JObject json = JObject.Parse(recievedString);

            return JsonObjectToString(json);
        }

        public string Delete(string controller, string id)
        {
            var recieved = client.DeleteAsync(BaseURL + controller + "/" + id).Result;

            var recievedString = recieved.Content.ReadAsStringAsync().Result;

            JObject json = JObject.Parse(recievedString);

            return JsonObjectToString(json);
        }

        public string UpdateAsJson<T>(T obj, string controller, string id)
        {
            string reqURL = BaseURL + controller + "/" + id;

            var sent = client.PutAsJsonAsync<T>(reqURL, obj).Result;

            return sent.Content.ReadAsStringAsync().Result;
        }

        public string UpdateAsXML<T>(T obj, string controller, string id)
        {
            string reqURL = BaseURL + controller + "/" + id;

            var sent = client.PutAsXmlAsync<T>(reqURL, obj).Result;

            return sent.Content.ReadAsStringAsync().Result;
        }

        private static string JsonObjectToString(JObject obj)
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.AppendLine("  {");
            foreach (var pair in obj)
            {
                resultBuilder.AppendFormat("    {0}: {1}\n", pair.Key, pair.Value);
            }
            resultBuilder.AppendLine("  }");

            return resultBuilder.ToString();
        }

        private static string JsonArrayToString(JArray jsonArray)
        {
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.AppendLine("[");
            
            foreach (JObject obj in jsonArray)
            {
                resultBuilder.AppendLine("  {");
                foreach (var pair in obj)
                {
                    resultBuilder.AppendFormat("    {0}: {1}\n", pair.Key, pair.Value);
                }
                resultBuilder.AppendLine("  },");
            }

            resultBuilder.Length -= 3;

            resultBuilder.AppendLine("\n]");

            return resultBuilder.ToString();
        }

        
    }
}
