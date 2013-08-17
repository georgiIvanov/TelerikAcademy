using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io.iron.ironmq;

namespace _01.IronMQApp
{
    class MessageSender
    {
        static void Main(string[] args)
        {
            Client client = new Client("520f706527c7200005000001", "JySHBhogfvbKpQ8I5CkUFoY-FnI");

            Queue queue = client.queue("ChatQueue");

            Console.WriteLine("You can start entering messages:");

            while (true)
            {
                string msg = Console.ReadLine();
                queue.push(msg);
                Console.WriteLine("Message sent to IronMQ server.");
            }
        }
    }
}
