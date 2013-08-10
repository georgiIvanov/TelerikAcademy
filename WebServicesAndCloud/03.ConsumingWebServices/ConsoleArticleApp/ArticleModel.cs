using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleArticleApp
{
    class ArticleModel
    {
        public ArticleModel()
        {

        }

        public ArticleModel(JToken token)
        {
            this.Url = token.Value<string>("source_url");
            this.Title = token.Value<string>("title");

        }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
