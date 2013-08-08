using _03.StringSearchCountLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace _03.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/_03.StringSearchCountLib/Service1/");

            ServiceHost selfHost = new ServiceHost(typeof(StringSearchCount), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IStringSearchCount), new WSHttpBinding(), "StringSearchCount Service");
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                using (selfHost)
                {
                    selfHost.Open();
                    Console.WriteLine("Service is ready\nPress any key  to exit");
                    Console.WriteLine();
                    Console.ReadKey();
                }
            }
            catch (CommunicationException ex)
            {
                Console.WriteLine("An exception occured: {0}", ex.Message);
                selfHost.Abort();
            }
        }
    }
}
