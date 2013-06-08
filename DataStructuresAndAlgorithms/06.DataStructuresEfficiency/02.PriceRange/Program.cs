using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _02.PriceRange
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderedMultiDictionary<double, Article> articles = new OrderedMultiDictionary<double, Article>(true);

            //this takes a few seconds
            for (int i = 0; i < 2000000; i++)
            {
                double price = i / 100.3;
                Article article = new Article(i * 971, Math.Round(price, 2), i.ToString(), i.ToString());
                articles.Add(new KeyValuePair<double,
                ICollection<Article>>(price, new Article[] { article }));
            }

            foreach (var node in GetArticlesInPriceRange(articles, 1d, 3d))
            {
                foreach (var item in node.Value)
                {
                    Console.WriteLine("{0}: {1}",item.Title, item.Price );
                }
            }
        }

        static OrderedMultiDictionary<double, Article>.View GetArticlesInPriceRange(OrderedMultiDictionary<double, Article> articles, double low, double high)
        {
            var aa = articles.Range(low, true, high, false);
            return aa;
        }
    }
}
