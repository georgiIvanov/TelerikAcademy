using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.BinToHex
{
    class BinToHex
    {
        static void Main(string[] args)
        {
            string binNum = Console.ReadLine(), hexNum = null;
            char[] binArr = binNum.ToCharArray(), fourBits = new char[4];
            Array.Reverse(binArr);
            int binLen = binArr.Length, fourthBit = 0;
            StringBuilder sb = new StringBuilder();

            foreach (var item in binArr)
            {
                sb.Append(item);

                if (binLen < 4)
                {
                    if (binLen <= 0) break;
                    for (int i = 0; i < 4; i++)
                    {
                        fourBits[i] = '0';
                    }
                    int binArrIndex = binLen - 1;
                    for (int i = 0; i < binLen; i++)
                    {
                        fourBits[i] = binNum[binArrIndex];
                        binArrIndex--;
                    }
                    fourthBit = 3;
                }

                if (fourthBit == 3)
                {
                    string bits = sb.ToString();
                    if (binLen >= 4)
                    {
                        fourBits = bits.ToCharArray();
                    }
                    Array.Reverse(fourBits);
                    bits = "";
                    foreach (var ch in fourBits)
                    {
                        bits += ch;
                    }

                    switch (bits)
                    {
                        case "0000": hexNum += "0"; break;
                        case "0001": hexNum += "1"; break;
                        case "0010": hexNum += "2"; break;
                        case "0011": hexNum += "3"; break;
                        case "0100": hexNum += "4"; break;
                        case "0101": hexNum += "5"; break;
                        case "0110": hexNum += "6"; break;
                        case "0111": hexNum += "7"; break;
                        case "1000": hexNum += "8"; break;
                        case "1001": hexNum += "9"; break;
                        case "1010": hexNum += "A"; break;
                        case "1011": hexNum += "B"; break;
                        case "1100": hexNum += "C"; break;
                        case "1101": hexNum += "D"; break;
                        case "1110": hexNum += "E"; break;
                        case "1111": hexNum += "F"; break;
                    }
                    fourthBit = -1;
                    binLen -= 4;
                    sb.Clear();
                }
                fourthBit++;
            }

            for (int i = hexNum.Length - 1; i >= 0; i--)
            {
                Console.Write(hexNum[i]);
            }
            Console.WriteLine();

        }
    }
}
