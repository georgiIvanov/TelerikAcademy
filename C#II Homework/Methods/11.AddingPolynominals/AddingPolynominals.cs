using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.AddingPolynominals
{
    class AddingPolynominals
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter polynominal coefficients\nin the following format {0}x^2 + {1}x + {2}, each on new line");
            int[] polyn1 = new int[3];
            polyn1[0] = int.Parse(Console.ReadLine());
            polyn1[1] = int.Parse(Console.ReadLine());
            polyn1[2] = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Enter polynominal coefficients\nin the following format {0}x^2 + {1}x + {2}, each on new line");
            int[] polyn2 = new int[3];
            polyn2[0] = int.Parse(Console.ReadLine());
            polyn2[1] = int.Parse(Console.ReadLine());
            polyn2[2] = int.Parse(Console.ReadLine());

            int[] additionResult = Adding2Polynominals(polyn1, polyn2);

            Console.WriteLine();
            Console.WriteLine("Result is: {0}x^2 + {1}x + {2}", additionResult[0], additionResult[1], additionResult[2]);
        }

        static int[] Adding2Polynominals(int[] poly1, int[] poly2)
        {
            int[] newPoly = new int[3];
            newPoly[0] = poly1[0] + poly2[0];
            newPoly[1] = poly1[1] + poly2[1];
            newPoly[2] = poly1[2] + poly2[2];

            return newPoly;
        }
    }
}
