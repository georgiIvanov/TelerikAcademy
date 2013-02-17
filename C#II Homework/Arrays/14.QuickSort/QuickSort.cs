using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _14.QuickSort
{
    class QuickSort
    {
        static Random rng = new Random();

        static void Main(string[] args)
        {
            Console.Write("Enter size of the array: ");
            int nSize = int.Parse(Console.ReadLine());
            List<string> strings = new List<string>();

            Console.WriteLine("Enter {0} strings: ", nSize);
            for (int i = 0; i < nSize; i++)
            {
                strings.Add(Console.ReadLine());
            }

            Partition(strings);

            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }


        }

        private static List<string> Partition(List<string> partition)
        {
            List<string> left = new List<string>();
            List<string> right = new List<string>();

            if (partition.Count > 0)
            {
                int pivot = GetPivot(partition.Count);
                string pivotString = partition[pivot];

                for (int i = 0; i < partition.Count; i++)
                {
                    if(i != pivot)
                    {
                        if (string.Compare(partition[i], partition[pivot]) >= 0)
                        {
                            right.Add(partition[i]);
                        }
                        else
                        {
                            left.Add(partition[i]);
                        }
                    }
                }

                left = Partition(left);
                right = Partition(right);

                partition.Clear(); 
                partition.AddRange(left);
                partition.Add(pivotString);
                partition.AddRange(right);
            }

            return partition;
        }

        public static int GetPivot(int count)
        {
            return rng.Next(0, count);
        }

    }
}
