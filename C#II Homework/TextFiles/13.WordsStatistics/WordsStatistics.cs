using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _13.WordsStatistics
{
    ////ORIGINAL TEXT FILE
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

    class WordsStatistics
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

            List<Word> wordsToFind = new List<Word>();
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    wordsToFind.Add(new Word(sr.ReadLine()));
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

            string text;
            using (sr)
            {
                text = sr.ReadToEnd();
            }

            foreach (var word in wordsToFind)
            {
                int index = 0;
                while (text.IndexOf(word.word, index) != 0)
                {
                    word.frequency++;
                    index = text.IndexOf(word.word, index) + 1;
                    if (index == 0)
                    {
                        word.frequency--;
                        break;
                    }
                }
            }

            List<Word> orderedWords =
                (from w in wordsToFind
                 orderby w.frequency descending
                 select w).ToList();

            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("../../../13.Task.txt");
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
                foreach (var word in orderedWords)
                {
                    sw.WriteLine(word.frequency + ". " + word.word);
                }
            }


        }
    }

    class Word
    {
        public string word { get; set; }
        public int frequency { get; set; }

        public Word(string word)
        {
            this.word = word;
            frequency = 0;
        }
    }
}
