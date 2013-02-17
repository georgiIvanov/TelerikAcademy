using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _03.LineNumbering
{
    class LineNumbering
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../text.txt");
            StreamWriter sw = new StreamWriter("../../../03.Task.txt");

            int numLine = 1;
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    string line = numLine + ". " + sr.ReadLine();
                    sw.WriteLine(line);
                    numLine++;
                }
            }

            sw.Close();
        }
    }
}
