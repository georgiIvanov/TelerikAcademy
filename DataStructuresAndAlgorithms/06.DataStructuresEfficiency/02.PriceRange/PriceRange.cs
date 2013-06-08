using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _02.PriceRange
{
    class PriceRange
    {
        static void Main(string[] args)
        {
            OrderedMultiDictionary<double, Article> articles = new OrderedMultiDictionary<double, Article>(true);

            //filling the dictionary takes a few seconds
            for (int i = 0; i < 2000000; i++)
            {
                double price = i / 100.3;
                Article article = new Article(i * 971, Math.Round(price, 2), i.ToString(), i.ToString());
                articles.Add(new KeyValuePair<double,
                ICollection<Article>>(price, new Article[] { article }));
            }

            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var articlesInRange = GetArticlesInPriceRange(articles, 1d, 300000d);
            stopwatch.Stop();

            //Uncomment to see found items title and price
            StringBuilder sb = new StringBuilder();
            //foreach (var node in articlesInRange)
            //{
            //    foreach (var item in node.Value)
            //    {
            //        sb.AppendFormat("{0}: {1}\n", item.Title, item.Price);

            //    }
            //}

            Console.WriteLine(sb.ToString());
            Console.WriteLine("Found count: {0}", articlesInRange.Count);
            Console.WriteLine("Items in range found in: {0}", stopwatch.Elapsed);
        }

        static OrderedMultiDictionary<double, Article>.View GetArticlesInPriceRange(OrderedMultiDictionary<double, Article> articles, double low, double high)
        {
            return articles.Range(low, true, high, false);
        }
    }
}
