using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _07.Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer.TimerDel timerHandler = DoImportantThings;
            Timer.sw.Start();

            while (true)
            {
                Timer.DoStuffEveryTTicks(1200000, timerHandler);
            }

        }

        public static void DoImportantThings()
        {
            Console.WriteLine("Lalala");
        }
        
    }

    static class Timer
    {
        public static Stopwatch sw = new Stopwatch();
        
        public static void DoStuffEveryTTicks(int t, TimerDel importantMethod)
        {
            if (sw.ElapsedTicks > t)
            {
                importantMethod();
                sw.Restart();
            }
        }
        public delegate void TimerDel();
    }
}
