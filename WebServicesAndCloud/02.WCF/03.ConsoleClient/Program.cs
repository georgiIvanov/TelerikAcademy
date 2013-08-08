using _03.ConsoleClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "123bla111bla";

            string searched = "bla";

            StringSearchCountClient client = new StringSearchCountClient();

            using (client)
            {
                int result = client.TimesStringFound(text, searched);
                Console.WriteLine(result);
            }
            
            

        }
    }
}
