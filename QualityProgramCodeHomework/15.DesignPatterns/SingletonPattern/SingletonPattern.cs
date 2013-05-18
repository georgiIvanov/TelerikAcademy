using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class SingletonPattern
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.Instance;

            // can't be instantiated
            // Singleton newS = new Singleton();

            Console.WriteLine(singleton.DoSingletonStuff());
        }
    }
}
