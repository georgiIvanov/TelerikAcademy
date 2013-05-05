using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CompareFunctionsPerf
{
    class CompareFunctionsPerf
    {
        static Stopwatch stopwatch = new Stopwatch();
        const int loopLimit = 1000000;
        const double power = 2;
        const int addsubValue = 99;
        const int divMultValue = 3;

        static void Main(string[] args)
        {
            Console.WriteLine("\tsqrt\tnaturalLog\tsin");

            unchecked
            {
                PrintFloatValue();
                PrintDoubleValue();
                PrintDecimalValue();
            }
        }

        static void PrintFloatValue()
        {
            float floatNum = float.MaxValue;
            stopwatch.Start();
            for (int i = 0; i < loopLimit; i++)
            {
                floatNum = (float)Math.Sqrt(floatNum);
            }
            stopwatch.Stop();
            Console.Write("float\t{0:F3}", stopwatch.Elapsed.TotalMilliseconds);

            floatNum = float.MaxValue;

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                floatNum = (float)Math.Log(floatNum);
            }

            floatNum = float.MaxValue;


            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                floatNum = (float)Math.Sin(floatNum);
            }
            stopwatch.Stop();
            Console.WriteLine("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
        }

        static void PrintDoubleValue()
        {
            double doubleNum = double.MaxValue;
            stopwatch.Start();
            for (int i = 0; i < loopLimit; i++)
            {
                doubleNum = Math.Sqrt(doubleNum);
            }
            stopwatch.Stop();
            Console.Write("double\t{0:F3}", stopwatch.Elapsed.TotalMilliseconds);

            doubleNum = double.MaxValue;

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                doubleNum = Math.Log(doubleNum);
            }

            doubleNum = double.MaxValue;

            stopwatch.Stop();
            Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < loopLimit; i++)
            {
                doubleNum = Math.Sin(doubleNum);
            }
            stopwatch.Stop();
            Console.WriteLine("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
        }

        static void PrintDecimalValue()
        {
            bool testNotFinished = false;
            decimal decimalNum = decimal.MaxValue;
            stopwatch.Start();
            for (int i = 0; i < loopLimit; i++)
            {
                decimalNum = (decimal)Math.Sqrt((double)decimalNum);
            }
            stopwatch.Stop();
            Console.Write("decimal\t{0:F3}", stopwatch.Elapsed.TotalMilliseconds);

            decimalNum = decimal.MaxValue;

            stopwatch.Restart();
            try
            {
                for (int i = 0; i < loopLimit; i++)
                {
                    decimalNum = (decimal)Math.Log((double)decimalNum);
                }
            }
            catch (OverflowException)
            {
                testNotFinished = true;
            }
            finally
            {
                if (testNotFinished)
                {
                    stopwatch.Stop();
                    Console.Write("\toverflow");
                }
                else
                {
                    stopwatch.Stop();
                    Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
                }
            }

            testNotFinished = false;
            decimalNum = decimal.MaxValue;
            stopwatch.Restart();
            try
            {
                for (int i = 0; i < loopLimit; i++)
                {
                    decimalNum = (decimal)Math.Sin((double)decimalNum);
                }
            }
            catch (OverflowException)
            {
                testNotFinished = true;
            }
            finally
            {
                if (testNotFinished)
                {
                    stopwatch.Stop();
                    Console.Write("\toverflow\t");
                }
                else
                {
                    stopwatch.Stop();
                    Console.Write("\t{0:F3}\t", stopwatch.Elapsed.TotalMilliseconds);
                }
            }
        }
    }
}
