using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.URLParse
{
    class URLParse
    {
        static void Main(string[] args)
        {
            Console.Write("Enter URL: ");
            string url = Console.ReadLine();
            int urlIndex = url.IndexOf(':');
            string protocol = url.Substring(0, urlIndex);
            int serverEndIndex = url.IndexOf('/', urlIndex + 3);
            string server = url.Substring(urlIndex + 3, serverEndIndex - urlIndex - 3);
            string resource = url.Substring(serverEndIndex,
                url.Length - serverEndIndex);

            Console.WriteLine("Protocol: {0}",protocol);
            Console.WriteLine("Server: {0}", server);
            Console.WriteLine("Resource: {0}", resource);


        }
    }
}
