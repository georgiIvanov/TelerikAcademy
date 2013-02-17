using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.Scores
{
    class Scores
    {
        static void Main(string[] args)
        {
            int inputScore;

            if (!int.TryParse(Console.ReadLine(), out inputScore))
            {
                Console.WriteLine("Wrong input!");
            }

            switch (inputScore)
            {
                case 1:
                case 2:
                case 3: Console.WriteLine(inputScore*3); break;
                case 4:
                case 5:
                case 6: Console.WriteLine(inputScore * 100); break;
                case 7:
                case 8:
                case 9: Console.WriteLine(inputScore * 1000); break;
            }
        }
    }
}
