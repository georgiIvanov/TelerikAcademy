using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleArticleApp
{
    class RequestManager
    {
        HttpClient client;
        string baseUrl;

        public RequestManager(string baseUrl)
        {
            client = new HttpClient();
            this.BaseUrl = baseUrl;
        }

        //http://api.feedzilla.com/v1/articles/search.json?q=Google&count=10
        public string Get(string action, string query, int count)
        {
            string reqUrl = string.Format(action, baseUrl, query,count);
            var httpResponce = client.GetAsync(reqUrl).Result;
            var responceMessage = httpResponce.Content.ReadAsStringAsync().Result;


            return responceMessage;
        }

        public string BaseUrl
        {
            get
            {
                return baseUrl;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid URL");
                }
                this.baseUrl = value;
            }
        }
    }
}
