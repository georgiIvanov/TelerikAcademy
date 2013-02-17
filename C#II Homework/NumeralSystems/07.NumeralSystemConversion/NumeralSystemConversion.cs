using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.NumeralSystemConversion
{
    class NumeralSystemConversion
    {
        static void Main(string[] args)
        {
            Console.Write("Enter s: ");
            int s = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number with {0} base: ", s);
            string n = Console.ReadLine();
            Console.WriteLine("Enter base to transform in: ");
            int d = int.Parse(Console.ReadLine());

            int number = 0;
            string result = "";

            number = ConvertTo10Base(s, n, number);

            while (number > 0)
            {
                switch (number % d)
                {
                    case 0: result = "0" + result; break;
                    case 1: result = "1" + result; break;
                    case 2: result = "2" + result; break;
                    case 3: result = "3" + result; break;
                    case 4: result = "4" + result; break;
                    case 5: result = "5" + result; break;
                    case 6: result = "6" + result; break;
                    case 7: result = "7" + result; break;
                    case 8: result = "8" + result; break;
                    case 9: result = "9" + result; break;
                    case 10: result = "a" + result; break;
                    case 11: result = "b" + result; break;
                    case 12: result = "c" + result; break;
                    case 13: result = "d" + result; break;
                    case 14: result = "e" + result; break;
                    case 15: result = "f" + result; break;
                    default: result += ""; break;
                }
                number = number / d;
            }

            Console.WriteLine(result);
            
        }

        static int ConvertTo10Base(int s, string n, int resultTemp)
        {
            for (int i = 0; i < n.Length; i++)
            {
                int exp = Pow(s, n.Length - 1 - i);
                resultTemp += Convert.ToInt32(n.Substring(i, 1)) * exp;
            }
            return resultTemp;
        }

        static int Pow(int numBase, int exp)
        {
            int result = 1;
            for (int i = 0; i < exp; i++)
            {
                result *= numBase;
            }
            return result;
        }
    }
}
