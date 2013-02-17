using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20.KVariations
{
    class KVariations
    {
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            Console.Write("Enter n: ");
            int nSize = int.Parse(Console.ReadLine());
            Console.Write("Enter variation's elements k: ");
            int kSize = int.Parse(Console.ReadLine());
            int[] variations = new int[kSize];
            Variations(variations, 0, nSize);

            Console.WriteLine(result.ToString());
        }

        static void Variations(int[] array, int index, int nSize)
        {
            if (index == array.Length)
            {
                PrintArray(array);
            }
            else
            {
                for (int i = 1; i <= nSize; i++)
                {
                    array[index] = i;
                    Variations(array, index + 1, nSize);
                }
            }
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                result.AppendFormat("{0} ", array[i]);
            }
            result.AppendLine();
        }
    }
}
