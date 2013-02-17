using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16.SubsetSum
{
    class SubsetSum
    {
        static int kSize;

        static void Main(string[] args)
        {
            Console.Write("Enter size of the array: ");
            int nSize = int.Parse(Console.ReadLine());
            Console.Write("Enter size of subset: ");
            kSize = int.Parse(Console.ReadLine());
            Console.Write("Enter target sum: ");
            int sum = int.Parse(Console.ReadLine());
            List<int> set = new List<int>();
            Console.WriteLine("Enter {0} numbers: ", nSize);
            for (int i = 1; i <= nSize; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }
            //************************************
            Console.WriteLine("Subset summing up to target sum: ");
            int setCount = set.Count;                   //numbers
            List<int> subSetSum = new List<int>();
            bool printOnly1 = false;

            set.Sort();
            StringBuilder answer = new StringBuilder();
            int currentKElements = 0;
            bool noKSubsetFound = true;
            foreach (var item in set)
            {
                count(0, sum, setCount, item, 0, subSetSum, new List<int>(set), true);
                int sumsTo0 = 0;
                foreach (var item2 in subSetSum)
                {
                    answer.AppendFormat("{0} ", item2);
                    sumsTo0 += item2;
                    currentKElements++;
                    if (sumsTo0 == sum && currentKElements == kSize)
                    {
                        Console.WriteLine(answer.ToString());
                        noKSubsetFound = false;
                        if (printOnly1) break;
                    }

                    if (currentKElements > kSize)
                    {
                        answer.Clear();
                        currentKElements = 0;
                    }
                }
                subSetSum.Clear();
                Console.WriteLine();
                if (printOnly1) break;
            }

            if (noKSubsetFound)
            {
                Console.WriteLine("No K subset found");
            }
        }

        static bool count(int currentSum, int targetSum, int amountNums, int currentNumber, int prevNumber, List<int> subSetSum0, List<int> set, bool isFristPass)
        {
            if (currentSum + currentNumber == targetSum)
            {
                set[set.IndexOf(currentNumber)] = 0;
                subSetSum0.Add(currentNumber);
                return true;
            }
            else
            {
                for (int i = amountNums; i > 0; i--)
                {
                    if (count(currentSum + currentNumber, targetSum, i - 1, set[i - 1], currentNumber, subSetSum0, set, false) == true)
                    {
                        try
                        {
                            set[set.IndexOf(currentNumber)] = 0;
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            return false;
                        }
                        subSetSum0.Add(currentNumber);
                        if (isFristPass == false)
                            return true;
                    }

                }
            }

            return false;
        }
    }
}
