using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _08.WordReplace
{
    class SubstringReplace
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../startText.txt");
            StreamWriter sw = new StreamWriter("../../../08.Task.txt");
            using (sr)
            {
                string line;
                using (sw)
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        line = line.Replace(" start ", " finish ");
                        sw.WriteLine(line);
                    }
                }
            }



        }
    }
}
