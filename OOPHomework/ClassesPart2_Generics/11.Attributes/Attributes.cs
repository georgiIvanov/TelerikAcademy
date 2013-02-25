using System;
using System.Reflection;

[assembly: AssemblyVersion("2.11")]

namespace _11.Attributes
{
    class Attributes
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Version of this assembly is: {0}", 
                Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}
