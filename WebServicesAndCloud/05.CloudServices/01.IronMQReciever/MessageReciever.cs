using io.iron.ironmq;
using io.iron.ironmq.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.IronMQReciever
{
    class MessageReciever
    {
        static void Main(string[] args)
        {
            Client client = new Client(
            "520f706527c7200005000001",
            "JySHBhogfvbKpQ8I5CkUFoY-FnI");
            Queue queue = client.queue("ChatQueue");
            Console.WriteLine("Listening for new messages from IronMQ server:");
            while (true)
            {
                Message msg = queue.get();
                if (msg != null)
                {
                    Console.WriteLine(msg.Body);
                    queue.deleteMessage(msg);
                }
                Thread.Sleep(100);
            }
        }
    }
}
