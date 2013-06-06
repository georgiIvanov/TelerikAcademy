using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SetImplementation
{
    class SetImplementation
    {
        static void Main(string[] args)
        {
            HashSet<string> hashSet = new HashSet<string>();

            hashSet.Add("ooo");
            hashSet.Add("qqq");
            hashSet.Add("ppp");
            hashSet.Add("iii");

            foreach (var item in hashSet.Items)
            {
                Console.WriteLine(item);
            }

            hashSet.Remove("iii");
            Console.WriteLine("\nCount after removal: {0}", hashSet.Count);


            Console.WriteLine();
            Console.WriteLine(hashSet.Find("ppp"));


            HashSet<string> secondHashSet = new HashSet<string>();
            secondHashSet.Add("www");
            secondHashSet.Add("qqq");
            secondHashSet.Add("yyy");
            secondHashSet.Add("ooo");

            Console.WriteLine("\nUnion: ");
            HashSet<string> union = hashSet.Union(secondHashSet);
            foreach (var item in union.Items)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nIntersection: ");
            HashSet<string> intersection = hashSet.Intersect(secondHashSet);
            foreach (var item in intersection.Items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
