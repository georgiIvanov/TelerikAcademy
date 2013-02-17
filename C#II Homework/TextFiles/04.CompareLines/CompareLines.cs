using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _04.CompareLines
{
    class CompareLines
    {
        static void Main(string[] args)
        {
            StreamReader sr1 = new StreamReader("../../../numbers.txt");
            StreamReader sr2 = new StreamReader("../../../text.txt");

            using(sr1)
            {
                using (sr2)
                {
                    while (!sr1.EndOfStream || !sr2.EndOfStream)
                    {
                        if (sr1.ReadLine().Length == sr2.ReadLine().Length)
                        {
                            Console.WriteLine("Line length is equal");
                        }
                        else
                        {
                            Console.WriteLine("Line length is different");
                        }
                    }
                }
            }
        }
    }
}
