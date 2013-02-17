using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _03.FilePath
{
    class FilePath
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();

            try
            {
                StreamReader sr = new StreamReader(path);
                using (sr)
                {
                    Console.WriteLine(sr.ReadToEnd().ToString());
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong Input");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
            }
            


        }
    }
}
