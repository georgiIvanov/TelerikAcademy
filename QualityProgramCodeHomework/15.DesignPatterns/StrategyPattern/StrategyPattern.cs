using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class StrategyPattern
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            int resultA = context.ExecuteStrategy(3, 4);

            int resultB = context.ExecuteStrategy(4, 4);

            int resultC = context.ExecuteStrategy(6, 4);

            Console.WriteLine(resultA);
            Console.WriteLine(resultB);
            Console.WriteLine(resultC);
        }
    }
}
