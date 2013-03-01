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
            Timer timer = new Timer();
            TimerListener listener = new TimerListener();

            listener.Subscribe(timer);
            timer.DoStuffEveryTTicks(190000);
        }
    }

    class TimerListener
    {
        public void Subscribe(Timer t)
        {
            t.TimerExpired += new Timer.TimerEventHandler(OnEventMethod);
        }

        void OnEventMethod(object obj, EventArgs e)
        {
            Console.WriteLine("Lalala");
        }
    }
    
    class Timer
    {
        public delegate void TimerEventHandler(object sender, EventArgs e);
        public event TimerEventHandler TimerExpired;
        public static Stopwatch sw = new Stopwatch();

        public void DoStuffEveryTTicks(int t)
        {
            sw.Start();
            while (true)
            {
                if (sw.ElapsedTicks > t && TimerExpired != null)
                {
                    TimerExpired(this, new EventArgs());
                    sw.Restart();
                }
            }
        }
    }
}
