using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RefactorStatements
{
    public class RefactorStatements
    {
        private static void Main(string[] args)
        {
            // ---=== First Example ===---
            Potato potato;

            // ... 
            if (potato != null)
            {
                if (potato.HasBeenPeeled && potato.IsEdible)
                {
                    Cook(potato);
                }
            }

            // ---=== Second Example ===---
            if (IsInRange(x, Min_X, Max_X) && IsInRange(y, Min_Y, Max_Y) && shouldVisitCell)
            {
                VisitCell();
            }
        }

        private static bool IsInRange(int variable, int minRange, int maxRange)
        {
            if (variable >= minRange && variable <= maxRange)
            {
                return true;
            }

            return false;
        }
    }
}
