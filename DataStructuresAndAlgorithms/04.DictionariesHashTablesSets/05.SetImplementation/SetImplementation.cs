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

            hashSet.Remove("qqq");
            Console.WriteLine("\nCount after removal: {0}", hashSet.Count);


            Console.WriteLine();
            Console.WriteLine(hashSet.Find("iii"));

            hashSet.Clear();
            Console.WriteLine("\nCount after clear(): {0}", hashSet.Count);

        }
    }
}
