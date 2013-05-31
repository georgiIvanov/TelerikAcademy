using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.StepsInLabyrinth
{
    class StepsInLabyrinth
    {
        static void Main(string[] args)
        {
            // uncomment setinput to enter the default field
            // SetInput();
            string[,] inputField = GetFieldFromConsole();

            Labyrinth labyrinth = new Labyrinth(inputField);
            labyrinth.FindSteps();
            Console.WriteLine(labyrinth.ToString());

        }

        private static void SetInput()
        {
            StreamReader sr = new StreamReader("..\\..\\input.txt");

            using (sr)
            {
                var reader = new StringReader(sr.ReadToEnd());
                Console.SetIn(reader);
            }
        }

        private static string[,] GetFieldFromConsole()
        {
            string[,] field = null;
            int rowOnField = 0;
            while (true)
            {
                string inputRow = Console.ReadLine();
                if (inputRow == null || inputRow == "")
                {
                    break;
                }

                string[] cells = inputRow.Split();

                if (field == null)
                {
                    field = new string[cells.Length, cells.Length];
                }

                for (int i = 0; i < cells.Length; i++)
                {
                    field[rowOnField, i] = cells[i];
                }
                rowOnField++;


            }

            return field;
        }
    }
}
