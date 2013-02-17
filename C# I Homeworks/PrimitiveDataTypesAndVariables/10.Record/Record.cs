using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.Record
{
    class Record
    {
        static void Main(string[] args)
        {
            string firstName, familyName;
            byte age;
            bool isMale;
            int ID, eID;

            firstName = Console.ReadLine();
            familyName= Console.ReadLine();
            int.TryParse(Console.ReadLine(), out ID);

            do
            {
                bool.TryParse(Console.ReadLine(), out isMale);
            } while (!(isMale == true || isMale == false));

            do
            {
                int.TryParse(Console.ReadLine(), out eID);
            }
            while (!(ID >= 27560000 && ID <= 27569999));


        }
    }
}
