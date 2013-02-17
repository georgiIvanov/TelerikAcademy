using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.GetType
{
    class GetType
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            int choice;
            Console.WriteLine("Enter: \n1 for int\n2 for double \n3 for string");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You have entered 1, integer");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine(a + 1);
                        break;
                    case 2:
                        Console.WriteLine("You have entered 2, double");
                        double b = double.Parse(Console.ReadLine());
                        Console.WriteLine(b + 1d);
                        break;
                    case 3:
                        Console.WriteLine("You have entered 3, string");
                        string str = Console.ReadLine();
                        str = str + "*";
                        Console.WriteLine(str);
                        break;
                    default:
                        Console.WriteLine("Wrong choice"); break;
                }
            }
            else
            {
                Console.WriteLine("Wrong choice");
            }
            


            

        }
    }
}
