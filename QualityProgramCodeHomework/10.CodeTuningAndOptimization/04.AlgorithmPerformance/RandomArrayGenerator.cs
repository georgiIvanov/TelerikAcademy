using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AlgorithmPerformance
{
    class RandomArrayGenerator
    {
        static string symbolsToSort = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~`!@#$%^&*()-_=+[{]}\\|;:'\",<.>/?";

        public static string[] RandomStringArray(int arrayLength, int minimum, int maximum)
        {
            string[] stringArray = new string[arrayLength];
            StringBuilder arrValue = new StringBuilder();
            Random rng = new Random();

            for (int i = 0; i < arrayLength; i++)
			{
                int valueLength = rng.Next(minimum, maximum);

                for (int j = 0; j < valueLength; j++)
			    {
                    arrValue.Append(symbolsToSort[rng.Next(0, symbolsToSort.Length)]);
			    }
                stringArray[i] = arrValue.ToString();
                arrValue.Clear();
			}

            return stringArray;
        }

        public static T[] RandomArray<T>(int length, int minimum, int maximum)
        {
            Random rng = new Random();
            T[] generatedArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                generatedArray[i] = (T)(object)rng.Next(minimum, maximum);
            }

            return generatedArray;
        }

        public static T[] RandomArray<T>(int length, double minimum, double maximum)
        {
            Random rng = new Random();
            T[] generatedArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                generatedArray[i] = (T)(object)(rng.NextDouble() * (maximum - minimum) + minimum);
            }

            return generatedArray;
        }
    }
}
