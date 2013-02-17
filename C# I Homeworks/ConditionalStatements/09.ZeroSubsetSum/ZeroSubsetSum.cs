using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.ZeroSubsetSum
{
    class ZeroSubsetSum
    {

        static void Main(string[] args)
        {
            //************************************
            //Automatic Entry
            //int[] initset = { 3, -2, 1, 1, 8, 4, -5, -1, 6 };         //temporary init set
            //List<int> set = new List<int>(initset);     //set of numbers
            //************************************
            //Manual Entry
            List<int> set = new List<int>();
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter " + i + " number: ");
                set.Add(int.Parse(Console.ReadLine()));
            }
            //************************************

            int setCount = set.Count;                   //numbers
            int sum = 0;                                //target sum
            List<int> subSetSum0 = new List<int>();

            set.Sort();
            foreach (var item in set)
            {
                if (item >= 0) continue; 
                count(0, 0, setCount, item, 0, subSetSum0, set, true);
                int sumsTo0 = 0;
                foreach (var item2 in subSetSum0)
                {
                    Console.Write(item2 + " ");
                    sumsTo0 += item2;
                    if(sumsTo0 == 0)
                        Console.WriteLine();
                    
                }
                subSetSum0.Clear();
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
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
                        if(count(currentSum + currentNumber, 0, i - 1, set[i - 1], currentNumber, subSetSum0, set, false) == true)
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
