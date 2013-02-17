using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _02.Concatenate2Files
{
    class Concatenate2Files
    {
        static void Main(string[] args)
        {
            string filePath1 = "../../../numbers.txt";
            string filePath2 = "../../../text.txt";

            StreamReader sr = new StreamReader(filePath1);
            StreamWriter sw = new StreamWriter("../../../02.Task.txt");
            
            using (sw)
            {
                sw.Write(sr.ReadToEnd());
                sr.Close();
                sr = new StreamReader(filePath2);
                sw.Write(sr.ReadToEnd());
                sr.Close();
            }

        }
    }
}
