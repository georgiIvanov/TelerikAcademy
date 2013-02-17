using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.ExtractSentence
{
    class ExtractSentence
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text: ");
            string inputText = Console.ReadLine();
            Console.Write("Enter word: ");
            string wordForSearch = Console.ReadLine();
            wordForSearch = " " + wordForSearch + " ";

            int wordIndex = 0, sentenceEnd = 0, sentenceStart = 0;
            while (wordIndex != -1)
            {
                wordIndex = inputText.IndexOf(wordForSearch, wordIndex);
                if (wordIndex != -1)
                {
                    sentenceEnd = wordIndex;
                    while (inputText[sentenceEnd] != '.')
                    {
                        sentenceEnd++;
                    }

                    sentenceStart = wordIndex;
                    while (sentenceStart > 0 && inputText[sentenceStart] != '.')
                    {
                        sentenceStart--;
                    }
                    wordIndex += wordForSearch.Length;
                    if (sentenceStart != 0) sentenceStart++;
                    Console.WriteLine(inputText.Substring(sentenceStart, sentenceEnd - sentenceStart+ 1).Trim());
                }
                
            }
            



        }
    }
}
