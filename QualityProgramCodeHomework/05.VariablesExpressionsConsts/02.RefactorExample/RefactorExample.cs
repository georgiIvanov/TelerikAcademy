using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RefactorExample
{
    public class RefactorExample
    {
        private static void Main(string[] args)
        {
        }

        public void PrintStatistics(double[] queriedElements, int range)
        {
            double max = double.MinValue;
            for (int i = 0; i < range; i++)
            {
                if (queriedElements[i] > max)
                {
                    max = queriedElements[i];
                }
            }

            PrintMax(max);

            double min = double.MaxValue;
            for (int i = 0; i < range; i++)
            {
                if (queriedElements[i] < min)
                {
                    min = queriedElements[i];
                }
            }

            PrintMin(min);

            double average = 0;
            for (int i = 0; i < range; i++)
            {
                average += queriedElements[i];
            }

            average /= range;

            PrintAvg(average);
        }
    }
}
