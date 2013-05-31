using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.TraverseDirectory
{
    class TraverseDirectory
    {
        static int unauthorizedAccesses = 0;

        static void Main(string[] args)
        {
            string windowsPath = "C:\\Windows";

            TraverseDirectories(windowsPath);
        }

        static void TraverseDirectories(string path)
        {
            string[] subDirectories = null;

            try
            {
                subDirectories = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException)
            {
                unauthorizedAccesses++;
                Console.WriteLine("Unauthorized Access {0}", unauthorizedAccesses);
                return;
            }

            PrintExecutables(path);

            foreach (var subDir in subDirectories)
            {
                TraverseDirectories(subDir);
            }

        }

        private static void PrintExecutables(string path)
        {
            string[] files = null;
            files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (file.EndsWith(".exe"))
                {
                    Console.WriteLine(file);
                }
            }
        }

    }
}
