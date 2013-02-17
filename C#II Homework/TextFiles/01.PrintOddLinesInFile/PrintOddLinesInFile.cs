using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _01.PrintOddLinesInFile
{
    class PrintOddLinesInFile
    {
        static void Main(string[] args)
        {
            string filePath = "../../../numbers.txt";

            StreamReader sr = new StreamReader(filePath);

            using (sr)
            {
                for (int i = 0; i <= 10; i++)
                {
                    string line = sr.ReadLine();
                    if ((i & 1) == 0)
                    {
                        Console.WriteLine(line);
                    }
                }
            }


        }
    }
}
