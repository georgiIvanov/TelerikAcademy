using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _02.ComparePerformance
{
    class ComparePerformance
    {
        static Stopwatch stopwatch = new Stopwatch();
        const int loopLimit = 1000000;
        const int addsubValue = 99;
        const int divMultValue = 3;
        static void Main(string[] args)
        {
            
            Console.WriteLine("\tadd\tsubtract\tincrement\tmultiply\tdivide");

            unchecked
            {
                PrintIntegerValues();
                PrintLongValues();
                PrintFloatValues();
                PrintDoubleValues();
                PrintDecimalValues();
            }

        }

        private static void PrintDecimalValues()
        {
            decimal decimalNum = 1;
            stopwatch.Start();
            for (int i = 0; i < loopLimit; i++)
            {
                decimalNum += addsubValue;
            }
            stopwatch.Stop();
            Console.Write("decimal\t{0:F3}", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                decimalNum -= addsubValue;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                decimalNum++;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            decimalNum = 1;

            stopwatch.Restart();
            try
            {
                for (int i = 0; i < loopLimit; i++)
                {
                    decimalNum *= divMultValue;
                }
                Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
            }
            catch (OverflowException)
            {

            }
            finally
            {
                Console.Write("\toverflow");
            }
            
            
            stopwatch.Stop();

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                decimalNum /= divMultValue;
            }
            stopwatch.Stop();
            Console.WriteLine("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void PrintDoubleValues()
        {
            double doubleNum = 1;
            stopwatch.Start();
            for (int i = 0; i < loopLimit; i++)
            {
                doubleNum += addsubValue;
            }
            stopwatch.Stop();
            Console.Write("double\t{0:F3}", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                doubleNum -= addsubValue;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                doubleNum++;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                doubleNum *= divMultValue;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                doubleNum /= divMultValue;
            }
            stopwatch.Stop();
            Console.WriteLine("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void PrintFloatValues()
        {
            float floatNum = 1;
            stopwatch.Start();
            for (int i = 0; i < loopLimit; i++)
            {
                floatNum += addsubValue;
            }
            stopwatch.Stop();
            Console.Write("float\t{0:F3}", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                floatNum -= addsubValue;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                floatNum++;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                floatNum *= divMultValue;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                floatNum /= divMultValue;
            }
            stopwatch.Stop();
            Console.WriteLine("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void PrintLongValues()
        {
            long longinteger = 1;
            stopwatch.Start();
            for (int i = 0; i < loopLimit; i++)
            {
                longinteger += addsubValue;
            }
            stopwatch.Stop();
            Console.Write("long\t{0:F3}", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                longinteger -= addsubValue;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                longinteger++;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                longinteger *= divMultValue;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                longinteger /= divMultValue;
            }
            stopwatch.Stop();
            Console.WriteLine("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
        }

        private static void PrintIntegerValues()
        {
            int integer = 1;
            stopwatch.Start();
            for (int i = 0; i < loopLimit; i++)
            {
                integer += addsubValue;
            }
            stopwatch.Stop();
            Console.Write("int\t{0:F3}", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                integer -= addsubValue;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                integer++;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                integer *= divMultValue;
            }
            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                integer /= divMultValue;
            }
            stopwatch.Stop();
            Console.WriteLine("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
        }
    }
}
