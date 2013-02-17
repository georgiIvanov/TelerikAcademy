using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.NumbersAsArrays
{
    class NumbersAsArrays
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first number: ");
            string n1 = Console.ReadLine();

            Console.WriteLine("Enter second number: ");
            string n2 = Console.ReadLine();

            int[] number1 = new int[n1.Length + 1];
            int[] number2 = new int[n2.Length + 1];

            for (int i = 0; i < n1.Length; i++)
            {
                number1[i] = int.Parse(n1[n1.Length - i - 1].ToString());
            }

            for (int i = 0; i < n2.Length; i++)
            {
                number2[i] = int.Parse(n2[n2.Length - i - 1].ToString());
            }

            int[] newNumber = AddNumbers(number1, number2);

            Console.WriteLine("New number: ");
            for (int i = newNumber.Length - 1; i >= 0; i--)
            {
                if (newNumber[i] == 0 && i == newNumber.Length - 1)
                {

                }
                else 
                Console.Write(newNumber[i]);
            }
            Console.WriteLine();

        }

        static int[] AddNumbers(int[] number1, int[] number2)
        {
            int tens = 0, newNumLength = 0, cellNumber = 0;

            if (number1.Length > number2.Length)
            {
                newNumLength = number1.Length;
            }
            else if (number1.Length < number2.Length)
            {
                newNumLength = number2.Length;
            }
            else
            {
                newNumLength = number1.Length;
            }

            int[] newNumber = new int[newNumLength];

            for (int i = 0; i < newNumLength; i++)
            {
                cellNumber = 0;
                if (i < number1.Length)
                {
                    cellNumber += number1[i];
                }
                if (i < number2.Length)
                {
                    cellNumber += number2[i];
                }

                if (cellNumber > 9)
                {
                    newNumber[i] += cellNumber - 10;
                    newNumber[i + 1] += cellNumber / 10;
                }
                else
                {
                    newNumber[i] += cellNumber;
                }
                
            }

            return newNumber;
        }
    }
}
