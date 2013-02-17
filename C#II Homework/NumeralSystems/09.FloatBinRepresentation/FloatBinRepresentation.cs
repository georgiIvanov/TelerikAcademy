using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace _09.FloatBinRepresentation
{
    class FloatBinRepresentation
    {
        static void Main(string[] args)
        {
            Console.Write("Enter float: ");
            float number = Single.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            string result = GetBytes(number);
            string binaryFloat = "";

            for (int i = 0; i < result.Length; i++)
            {
                switch (result[i])
                {
                    case '0': binaryFloat += "0000"; break;
                    case '1': binaryFloat += "0001"; break;
                    case '2': binaryFloat += "0010"; break;
                    case '3': binaryFloat += "0011"; break;
                    case '4': binaryFloat += "0100"; break;
                    case '5': binaryFloat += "0101"; break;
                    case '6': binaryFloat += "0110"; break;
                    case '7': binaryFloat += "0111"; break;
                    case '8': binaryFloat += "1000"; break;
                    case '9': binaryFloat += "1001"; break;
                    case 'A': binaryFloat += "1010"; break;
                    case 'B': binaryFloat += "1011"; break;
                    case 'C': binaryFloat += "1100"; break;
                    case 'D': binaryFloat += "1101"; break;
                    case 'E': binaryFloat += "1110"; break;
                    case 'F': binaryFloat += "1111"; break;
                }
            }

            Console.WriteLine();
            for (int i = 0; i < binaryFloat.Length; i++)
            {
                
                if (i == 0)
                {

                    Console.WriteLine("Sign: {0}",binaryFloat[i]);
                }
                else if (i == 1)
                {
                    Console.Write("Exponent: {0}", binaryFloat[i]);
                }
                else if (i <= 8)
                {
                    Console.Write(binaryFloat[i]);
                }
                else if (i == 9)
                {
                    Console.Write("\nMantissa: {0}", binaryFloat[i]);
                }
                else
                {
                    Console.Write(binaryFloat[i]);
                }
            }

            Console.WriteLine();
        }

        static string GetBytes(float number)
        {
            byte[] byteArray = BitConverter.GetBytes(number);
            Array.Reverse(byteArray);
            string result = BitConverter.ToString(byteArray);
            return result;
        }
    }
}
