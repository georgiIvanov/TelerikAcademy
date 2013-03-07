using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RangeException
{
    class Program
    {
        static void Main(string[] args)
        {
            AddSomething(1, 22);
            //AddSomething(1, 122);

            DateTime a = DateTime.Parse("1.1.1980");
            DateTime b = DateTime.Parse("30.12.2013");
            //DateTime b = DateTime.Parse("30.12.2018");

            TimeDifference(a, b);
        }

        static void AddSomething(int a, int b)
        {
            if (a < 0 || a > 100)
            {
                throw new InvalidRangeException<int>(a);
            }
            else if (b < 0 || b > 100)
            {
                throw new InvalidRangeException<int>(b);
            }

            Console.WriteLine(a+b);
        }

        static void TimeDifference(DateTime a, DateTime b)
        {
            if (a < DateTime.Parse("1.1.1980") || a > DateTime.Parse("31.12.2013"))
            {
                throw new InvalidRangeException<DateTime>(a);
            }
            else if (b < DateTime.Parse("1.1.1980") ||
                b > DateTime.Parse("31.12.2013"))
            {
                throw new InvalidRangeException<DateTime>(b);
            }

            Console.WriteLine(b-a);
        }
    }

    public class InvalidRangeException<T> : ApplicationException
    {
        string msg;

        public InvalidRangeException(T variable)
        {
            msg = SetErrorMessage(variable);
        }

        string SetErrorMessage(T variable)
        {
            string msg;
            if (typeof(T).Name == "Int32")
            {
                msg = variable + " is outside the range [0..100]";
            }
            else if (typeof(T).Name == "DateTime")
            {
                msg = variable + " is outside the date range [1.1.1980..31.12.2013]";
            }
            else
            {
                msg = "unknown type";
            }

            return msg;
        }


        public override string Message
        {
            get
            {
                return msg;
            }
        }
    }
}
