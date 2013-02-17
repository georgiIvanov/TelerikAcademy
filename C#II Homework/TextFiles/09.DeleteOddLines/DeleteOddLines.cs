using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _09.DeleteOddLines
{
    class DeleteOddLines
    {
        static void Main(string[] args)
        {
            string filePath = "../../../delOddLines.txt";

            StreamReader sr = new StreamReader(filePath);

            StringBuilder newText = new StringBuilder();

            using (sr)
            {
                for (int i = 0; i <= 10; i++)
                {
                    string line = sr.ReadLine();
                    if ((i & 1) == 0)
                    {
                        newText.AppendLine(line);
                    }
                }
            }

            StreamWriter sw = new StreamWriter(filePath);
            sw.Write(newText.ToString());
            sw.Close();
        }
    }
}
//File ^_^
//0 dlkwadjwa\
//1 d
//2
//3 kjdaw;dka
//4 ;djwada
//5 dlkawjdak
//6 l;kdjawdwa
//7 jdawdwa
//8
//9dwajdjdjdjd
//10 idowadiwaoid
