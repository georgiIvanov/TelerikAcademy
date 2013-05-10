using System;

namespace RefactorMatrix
{
    class RefactorMatrixProgram
    {
        static void Main(string[] args)
        {
            int size = GetInput();

            WalkInMatrix walk = new WalkInMatrix(size);
            
            walk.FillMatrix();

            Console.WriteLine(walk.ToString());

        }

        private static int GetInput()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            int n = 0;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }
            return n;
        }
    }
}
