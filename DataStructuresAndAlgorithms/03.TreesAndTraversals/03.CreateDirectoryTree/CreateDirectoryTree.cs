using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CreateDirectoryTree
{
    class CreateDirectoryTree
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tree is building, please wait for few seconds...");
            DirectoryTree dirTree = new DirectoryTree("C:\\Windows");

            Console.WriteLine("Done.");

            Console.WriteLine("\nTree size: ");
            double sizeInMB = dirTree.CalculateSizeOfTree();
            Console.WriteLine("{0} megabytes", sizeInMB);
            Console.WriteLine("{0} or gigabytes", sizeInMB / 1024);

            //in windows 8 AppCompat exists, you can try any other folder in Windows directory
            Console.WriteLine("\nCalculate size of tree folder and subfolders: ");
            sizeInMB = dirTree.CalculateSizeOfFolder("AppCompat");
            Console.WriteLine("{0} megabytes", sizeInMB);
            Console.WriteLine("{0} or gigabytes", sizeInMB / 1024);

        }
    }
}
