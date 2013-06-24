using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MessagesInABottle
{
    struct Item
    {
        public char letter;
        public string code;

        public Item(char letter, string code)
        {
            this.letter = letter;
            this.code = code;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string secretCode = Console.ReadLine();
            string cipher = Console.ReadLine();

            CipherDecoder decoder = new CipherDecoder(secretCode, cipher);
            List<string> originalMessages = decoder.Decode();

            originalMessages.Sort();
            Console.WriteLine(originalMessages.Count);
            foreach (var message in originalMessages)
            {
                Console.WriteLine(message);
            }

        }
    }

    class CipherDecoder
    {
        List<Item> cipherItems;
        string secretCode;
        List<string> originalMessages;
        char[] currentOriginalMessage;

        public CipherDecoder(string secretCode, string cipher)
        {
            cipherItems = new List<Item>();

            StringBuilder currentCipher = new StringBuilder();
            char lastChar = '\0';

            foreach (var ch in cipher)
            {
                if (ch >= 'A' && ch <= 'Z')
                {
                    if (currentCipher.Length > 0)
                    {
                        cipherItems.Add(new Item(lastChar, currentCipher.ToString()));
                        currentCipher.Clear();
                    }
                    lastChar = ch;
                }
                else
                {
                    currentCipher.Append(ch);
                }
            }

            if (currentCipher.Length > 0)
            {
                cipherItems.Add(new Item(lastChar, currentCipher.ToString()));
            }

            this.secretCode = secretCode;
            currentOriginalMessage = new char[100];
        }

        public List<string> Decode()
        {
            originalMessages = new List<string>();
            DecodeWithRecursion(0, 0);
            return originalMessages;
        }


        void DecodeWithRecursion(int index, int wordIndex)
        {
            if (index == secretCode.Length)
            {
                AddSolution(currentOriginalMessage);
                return;
            }

            if (index > secretCode.Length)
            {
                return;
            }

            foreach (var item in cipherItems)
            {
                if (secretCode.Length >= index + item.code.Length &&
                    secretCode.Substring(index, item.code.Length) == item.code)
                {
                    currentOriginalMessage[wordIndex] = item.letter;
                    DecodeWithRecursion(index + item.code.Length, wordIndex + 1);
                    currentOriginalMessage[wordIndex] = '\0';
                }
            }
        }

        void AddSolution(char[] currentOriginalMessage)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in currentOriginalMessage)
            {
                if (c < 'A' || c > 'Z')
                {
                    break;
                }
                sb.Append(c);
            }
            originalMessages.Add(sb.ToString());
        }
    }
}
