using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16.SubsetSum
{
    class SubsetSum
    {
        static void Main(string[] args)
        {
            //************************************
            //Automatic Entry
            //int[] initset = { 3, -2, 1, 1, 8, 4, -5, -1, 6 };         //temporary init set
            //List<int> set = new List<int>(initset);     //set of numbers
            //************************************
            //Manual Entry
            Console.Write("Enter target sum: ");
            int sum = int.Parse(Console.ReadLine());
            Console.Write("Enter size of the array: ");
            int nSize = int.Parse(Console.ReadLine());
            List<int> set = new List<int>();
            Console.WriteLine("Enter {0} numbers: ", nSize);
            for (int i = 1; i <= nSize; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }
            //************************************
            Console.WriteLine("Subset summing up to target sum: ");
            int setCount = set.Count;                   //numbers
            List<int> subSetSum0 = new List<int>();
            bool printOnly1 = true;

            set.Sort();
            foreach (var item in set)
            {
                count(0, sum, setCount, item, 0, subSetSum0, set, true);
                int sumsTo0 = 0;
                foreach (var item2 in subSetSum0)
                {
                    Console.Write(item2 + " ");
                    sumsTo0 += item2;
                    if (sumsTo0 == sum)
                    {
                        Console.WriteLine();
                        if (printOnly1) break;
                    }
                    
                }
                subSetSum0.Clear();
                Console.WriteLine();
                if (printOnly1) break;
            }
        }

        static bool count(int currentSum, int targetSum, int amountNums, int currentNumber, int prevNumber, List<int> subSetSum0, List<int> set, bool isFristPass)
        {
            if (currentSum + currentNumber == targetSum)
            {
                subSetSum0.Add(currentNumber);
                return true;
            }
            else
            {
                for (int i = amountNums; i > 0; i--)
                {
                        if(count(currentSum + currentNumber, targetSum, i - 1, set[i - 1], currentNumber, subSetSum0, set, false) == true)
                        {
                            subSetSum0.Add(currentNumber);
                            if(isFristPass == false)
                            return true;
                        }
                    
                }
            }

            return false;
        }
    }
}
