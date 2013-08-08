using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.GeneratedProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "PROXXXY";

            string searched = "X";

            StringSearchCountClient client = new StringSearchCountClient();

            using (client)
            {
                int result = client.TimesStringFound(text, searched);
                Console.WriteLine(result);
            }
        }
    }
}
