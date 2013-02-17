using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.RectangleArea
{
    class RectangleArea
    {
        static void Main(string[] args)
        {
            int height = new int();
            int width = new int();
            int areaOfRec = new int();

            Console.Write("Enter height of rectangle: ");
            int.TryParse(Console.ReadLine(), out height);
            Console.Write("Enter width of rectangle: ");
            int.TryParse(Console.ReadLine(), out width);
            areaOfRec = height * width;
            Console.WriteLine(areaOfRec);

        }
    }
}
