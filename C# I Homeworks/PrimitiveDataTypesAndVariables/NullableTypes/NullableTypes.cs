using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NullableTypes
{
    class NullableTypes
    {
        static void Main(string[] args)
        {
            int? nullableInt = null;
            double? nullableDouble = null;

            Console.WriteLine(nullableInt + " " + nullableDouble);

            nullableInt += 5; nullableDouble += 6.78;
            Console.WriteLine(nullableInt + " " + nullableDouble);

            nullableInt = 5; nullableDouble = 6.78;
            Console.WriteLine(nullableInt + " " + nullableDouble);
        }
    }
}
