using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleArticleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = "";
            RequestManager requestManager = new RequestManager("http://api.feedzilla.com/v1/articles/");

            while (true)
            {
                Console.WriteLine("Enter query string or \\end to exit");
                inputLine = Console.ReadLine();

                if (inputLine != "\\end")
                {
                    Console.Write("Enter articles count: ");
                    int count = int.Parse(Console.ReadLine());
                    string articlesJson = requestManager.Get("{0}search.json?q={1}&count={2}", inputLine, count);

                    var articles = ParseArticles(articlesJson);

                    PrintArticles(articles);
                }
                else
                {
                    break;
                }
            }

        }

        static List<ArticleModel> ParseArticles(string articlesAsJsonString)
        {
            JObject json = JObject.Parse(articlesAsJsonString);
            var jsonArticles = json.GetValue("articles");
            List<ArticleModel> articles = new List<ArticleModel>();
            foreach (var item in jsonArticles)
            {
                articles.Add(new ArticleModel(item));
            }

            return articles;
        }

        static void PrintArticles(List<ArticleModel> articles)
        {
            foreach (var item in articles)
            {
                Console.WriteLine("Title: {0}\nLink:{1}\n\n", item.Title, item.Url);
            }
        }

        
    }
}