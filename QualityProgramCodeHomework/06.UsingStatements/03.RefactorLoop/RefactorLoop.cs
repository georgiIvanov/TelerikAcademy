using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RefactorLoop
{
    public class RefactorLoop
    {
        private static void Main(string[] args)
        {
            int anticipatedNumber = 0;

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0 && array[i] == expectedValue)
                {
                    anticipatedNumber = 666;
                }

                Console.WriteLine(array[i]);
            }

            // More code here
            if (anticipatedNumber == 666)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
