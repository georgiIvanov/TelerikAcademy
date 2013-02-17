using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _06.SortStrings
{
    class SortStrings
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../text.txt");
            List<string> lines = new List<string>();

            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    lines.Add(sr.ReadLine());
                }
            }

            lines.Sort();

            StreamWriter sw = new StreamWriter("../../../06.SortedText.txt");
            using (sw)
            {
                foreach (var item in lines)
                {
                    sw.WriteLine(item);
                }
            }

        }
    }
}
