using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace _11.DeletePrefix
{
    class DeletePrefix
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("../../../delTestPrefix.txt");
            StringBuilder sb = new StringBuilder();

            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (line.IndexOf("test") == 0)
                    {
                        if (line.IndexOf("test ") != 0)
                        {
                            line = line.Substring(4);
                        }
                    }
                    line = Regex.Replace(line, " test", "");
                    sb.AppendLine(line);
                }
            }

            StreamWriter sw = new StreamWriter("../../../delTestPrefix.txt");
            sw.Write(sb.ToString());
            sw.Close();

        }
    }
}

//oidawtest testkdkwad
//testc dwadkjwajdtestkdjwa
//tejdwajdiwajtestidjwad
//dlwakjdwadjwladjwadwij
//testdwadtestdwadtest
//test dwad testdwkdktest kdwkdk test
//dwkadawodkw testdjdjdwjdw
//dwadwa testdjwadjwad
