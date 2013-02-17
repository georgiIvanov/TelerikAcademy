using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _12.RemoveWords
{
    class RemoveWords
    {
        static void Main(string[] args)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("../../../words.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No such file");
                Environment.Exit(1);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
                Environment.Exit(1);
            }

            List<string> wordsToRemove = new List<string>();
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    wordsToRemove.Add(sr.ReadLine());
                }
            }

            try
            {
                sr = new StreamReader("../../../text.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No such file");
                Environment.Exit(1);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
                Environment.Exit(1);
            }

            StringBuilder sb = new StringBuilder();
            using (sr)
            {
                sb.Append(sr.ReadToEnd());
            }

            foreach (var word in wordsToRemove)
            {
                sb.Replace(word, "");
            }

            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("../../../text.txt");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Cannot access this file");
                Environment.Exit(1);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot find file in directory");
                Environment.Exit(1);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("No such directory");
                Environment.Exit(1);
            }

            using (sw)
            {
                sw.Write(sb.ToString());
            }
        }
    }
}


////original text.txt
//dwboo-hooadawd
//wie2i3123 boo-hoo 213215t
//[p[p.1]./.boo-boo/.1] boo-boo 135][][';lszcx.,
//dpwajdwaddawfpogrporjgrpogrpgkor;kgr;okg
//dwaipjffialwjdw
//dwajdipwajdwapiboo-boojdwa
//d
//p
//dwaipgjp421qpowda[oxzckzxkcn.w
//mf,sdnfmsd,nf,mvnxcjboo-mooheljrw  lkjda wkjda wlkjdwalkj