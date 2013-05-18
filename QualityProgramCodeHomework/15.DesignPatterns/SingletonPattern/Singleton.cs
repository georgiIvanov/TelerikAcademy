using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        private Singleton() 
        {

        }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public string DoSingletonStuff()
        {
            return "sssSsSsS";
        }
    }
}
