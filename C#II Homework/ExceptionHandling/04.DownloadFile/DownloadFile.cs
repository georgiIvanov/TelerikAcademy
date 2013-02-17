using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace _04.DownloadFile
{
    class DownloadFile
    {
        static void Main(string[] args)
        {
            string url = "http://www.devbg.org/img/Logo-BASD.jpg";

            WebClient client = new WebClient();

            try
            {
                client.DownloadFile(url, "pic.jpg");
            }
            catch (WebException)
            {
                Console.WriteLine("Possible problem with internet connection");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Operation not supported");
            }

            
        }
    }
}
