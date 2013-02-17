using System;
using System.Text;
class Program
{
    static StringBuilder result = new StringBuilder();

    static void Main(string[] args)
    {
        Console.Write("Enter n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter k: ");
        int k = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = i + 1;
        }
        FindCombinations(numbers, k);
        Console.WriteLine(result.ToString());
    }

    static void FindCombinations(int[] numbers, int k)
    {
        StringBuilder str = new StringBuilder();
        int limit = (int)Math.Pow(2, numbers.Length) - 1;
        for (int i = limit; i >= 0; i--)
        {
            string temp = Convert.ToString(i, 2).PadLeft(numbers.Length, '0');
            for (int j = 0; j < temp.Length; j++)
            {
                if (temp[j] == '1')
                {
                    str.AppendFormat("{0} ", numbers[j]);
                }
            }
            string[] split = str.ToString().Split(null as string[], StringSplitOptions.RemoveEmptyEntries);
            if (split.Length == k)
            {
                result.AppendLine(str.ToString());
            }
            str.Clear();
        }
    }
}