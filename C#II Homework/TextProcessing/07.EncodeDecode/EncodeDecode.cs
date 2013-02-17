using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07.EncodeDecode
{
    class EncodeDecode
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string inputText = Console.ReadLine();
            Console.Write("Enter cipher: ");
            string cipher = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            sb.Append(inputText);
            int cipherIndex = 0;

            for (int i = 0; i < sb.Length; i++)
            {
                if (cipherIndex == cipher.Length)
                {
                    cipherIndex = 0;
                }
                sb[i] = (char)(sb[i] ^ cipher[cipherIndex]);
                
                cipherIndex++;
            }
            Console.WriteLine("Encoded: {0}", sb.ToString());

            cipherIndex = 0;
            for (int i = 0; i < sb.Length; i++)
            {
                if (cipherIndex == cipher.Length)
                {
                    cipherIndex = 0;
                }
                sb[i] = (char)(sb[i] ^ cipher[cipherIndex]);

                cipherIndex++;
            }

            Console.WriteLine("Decoded: {0}", sb.ToString());
        }
    }
}
