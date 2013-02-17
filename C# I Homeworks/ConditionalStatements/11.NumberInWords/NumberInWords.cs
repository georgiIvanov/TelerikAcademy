using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.NumberInWords
{
    class NumberInWords
    {
        static void Main(string[] args)
        {
            int number, tempNumber;
            bool isBtw11And19 = false;
            number = int.Parse(Console.ReadLine());
            tempNumber = number;

            StringBuilder sb = new StringBuilder();

            if (number % 1000 >= 100)
            {
                tempNumber = number / 100;
                int tensAndOnes = number % 100;
                GetHundreds(tempNumber, sb, tensAndOnes);
            }
            if (number % 100 >= 10 && number % 100 <= 99)
            {
                if (number % 100 <= 19 && number % 100 >= 10)
                {
                    tempNumber = number % 100;
                    GetTensBtw20And10(tempNumber, sb);
                    isBtw11And19 = true;
                }
                else
                {
                    tempNumber = number % 100;
                    tempNumber /= 10;
                    GetTensAbove20(tempNumber, sb);
                }
            }
            if (number % 10 > 0 && isBtw11And19 == false)
            {
                tempNumber = number % 10;
                GetOnes(tempNumber, sb);
            }

            Console.WriteLine(sb.ToString());


        }
        static void GetHundreds(int tempNumber, StringBuilder sb, int tensAndOnes)
        {
            if (tensAndOnes > 0)
            {
                switch (tempNumber)
                {
                    case 1: sb.Append("One Hundred And "); break;
                    case 2: sb.Append("Two Hundred And "); break;
                    case 3: sb.Append("Three Hundred And "); break;
                    case 4: sb.Append("Four Hundred And "); break;
                    case 5: sb.Append("Five Hundred And "); break;
                    case 6: sb.Append("Six Hundred And "); break;
                    case 7: sb.Append("Seven Hundred And "); break;
                    case 8: sb.Append("Eight Hundred And "); break;
                    case 9: sb.Append("Nine Hundred And "); break;
                }
            }
            else
            {
                switch (tempNumber)
                {
                    case 1: sb.Append("One Hundred "); break;
                    case 2: sb.Append("Two Hundred "); break;
                    case 3: sb.Append("Three Hundred "); break;
                    case 4: sb.Append("Four Hundred "); break;
                    case 5: sb.Append("Five Hundred "); break;
                    case 6: sb.Append("Six Hundred "); break;
                    case 7: sb.Append("Seven Hundred "); break;
                    case 8: sb.Append("Eight Hundred "); break;
                    case 9: sb.Append("Nine Hundred "); break;
                }
            }
        }

        static void GetTensBtw20And10(int tempNumber, StringBuilder sb)
        {
            switch (tempNumber)
            {
                case 10: sb.Append("Ten"); break;
                case 11: sb.Append("Eleven"); break;
                case 12: sb.Append("Twelve"); break;
                case 13: sb.Append("Thirteen"); break;
                case 14: sb.Append("Fourteen"); break;
                case 15: sb.Append("Fifteen"); break;
                case 16: sb.Append("Sixteen"); break;
                case 17: sb.Append("Seventeen"); break;
                case 18: sb.Append("Eighteen"); break;
                case 19: sb.Append("Nineteen"); break;
            }
        }

        static void GetTensAbove20(int tempNumber, StringBuilder sb)
        {
            switch (tempNumber)
            {
                case 2: sb.Append("Twenty "); break;
                case 3: sb.Append("Thirty "); break;
                case 4: sb.Append("Fourty "); break;
                case 5: sb.Append("Fifty "); break;
                case 6: sb.Append("Sixty "); break;
                case 7: sb.Append("Seventy "); break;
                case 8: sb.Append("Eighty "); break;
                case 9: sb.Append("Ninety "); break;
            }

        }

        static void GetOnes(int tempNumber, StringBuilder sb)
        {
            switch (tempNumber)
            {
                case 1: sb.Append("One"); break;
                case 2: sb.Append("Two"); break;
                case 3: sb.Append("Three"); break;
                case 4: sb.Append("Four"); break;
                case 5: sb.Append("Five"); break;
                case 6: sb.Append("Six"); break;
                case 7: sb.Append("Seven"); break;
                case 8: sb.Append("Eight"); break;
                case 9: sb.Append("Nine"); break;
            }
        }
    }

    
}
