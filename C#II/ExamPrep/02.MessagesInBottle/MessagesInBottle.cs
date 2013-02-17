using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.MessagesInBottle
{
    class MessagesInBottle
    {
        static void Main(string[] args)
        {
            List<State> states = new List<State>();
            string code = Console.ReadLine();
            string cipherToDecode = Console.ReadLine();

            List<CipherElement> cipher = BuildCipher(cipherToDecode);
            List<string> results = new List<string>();
            states.Add(new State() { left = code, obtained = "" });
            int index = 0;
            while (index < states.Count)
            {
                State currentState = states[index];
                index++;
                foreach (var cipherElement in cipher)
                {
                    if (currentState.left.StartsWith(cipherElement.digits))
                    {
                        State newState = new State();
                        newState.obtained = currentState.obtained + cipherElement.letter;
                        newState.left = currentState.left.Remove(0, cipherElement.digits.Length);

                        if (newState.left == "")
                        {
                            results.Add(newState.obtained);
                        }
                        else
                        {
                            states.Add(newState);
                        }
                    }
                }
            }
            results.Sort();
            Console.WriteLine(results.Count);
            foreach (var decodedLetters in results)
            {
                Console.WriteLine(decodedLetters);
            }
        }

        private static List<CipherElement> BuildCipher(string cipherToDecode)
        {
            List<CipherElement> elements = new List<CipherElement>();
            char? letter = null;
            StringBuilder digits = new StringBuilder();
            foreach (var ch in cipherToDecode)
            {
                if (char.IsLetter(ch))
                {
                    if (letter != null)
                    {
                        CipherElement newElement = new CipherElement();
                        newElement.letter = letter.Value;
                        newElement.digits = digits.ToString();
                        elements.Add(newElement);
                        digits.Clear();
                    }
                    letter = ch;
                }
                else
                {
                    digits.Append(ch.ToString());
                }

            }
            CipherElement element = new CipherElement();
            element.letter = letter.Value;
            element.digits = digits.ToString();
            elements.Add(element);
            digits.Clear();

            return elements;
        }
    }

    class State
    {
        public string obtained { get; set; }
        public string left { get; set; }
    }

    class CipherElement
    {
        public char letter { get; set; }
        public string digits { get; set; }
    }
}
