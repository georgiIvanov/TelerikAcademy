using _02.ConsoleClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DateServiceClient client = new DateServiceClient();

            DateTime date = DateTime.Parse("2013.08.01");

            string result = client.GetDayOfWeek(date);

            Console.WriteLine(result);

            result = client.GetDayOfWeek(DateTime.Now);
            Console.WriteLine("\nTodays day: {0}", result);

            client.Close();
        }
    }
}