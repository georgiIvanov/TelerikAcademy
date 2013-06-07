using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;
using System.Diagnostics;

namespace _02.ElementsInRange
{
    class ElementsInRange
    {
        static void Main(string[] args)
        {
            StringBuilder allProductsToString = new StringBuilder();
            Stopwatch stopWatch = new Stopwatch();
            OrderedBag<Product> orderedBag = new OrderedBag<Product>();
            int ranges = 10000;

            stopWatch.Start();
            AddProductsToBag(orderedBag, 500001);

            for (int i = 0; i < ranges; i++)
            {
                stopWatch.Start();
                List<Product> found = FindFirst20(orderedBag, 100000, 100000 + i*2);

                //time for adding to stringbuilder not included
                stopWatch.Stop();
                allProductsToString.Append(found.GetProductsToString());
            }

            // uncomment to see all ranges found
            // Console.WriteLine(allProductsToString.ToString());
            Console.WriteLine("Adding products and range searching done in: {0}", stopWatch.Elapsed);
        }

        public static void AddProductsToBag(OrderedBag<Product> orderedBag, int numberOfItems)
        {
            for (int i = 1; i < numberOfItems; i++)
            {
                orderedBag.Add(new Product(i.ToString(), i));
            }
        }

        public static List<Product> FindFirst20(OrderedBag<Product> orderedBag, int lowPrice, int highPrice)
        {
            var result = orderedBag.Range(new Product("searchItem", highPrice), true,
                new Product("searchItem", lowPrice), true);

            List<Product> listResult = new List<Product>();

            if (result.Count == 0)
            {
                return listResult;
            }

            for (int i = 0; i < 20 && i < result.Count; i++)
            {
                listResult.Add(result[i]);
            }

            return listResult;
        }

    }
}
