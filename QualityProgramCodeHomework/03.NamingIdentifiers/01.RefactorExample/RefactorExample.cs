using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RefactorExample
{
    class RefactorExample
    {
        static void Main(string[] args)
        {
            ConsoleOutput.WriteBoolToConsole(false);
        }
    }

    class ConsoleOutput
    {
        const int MAX_COUNT = 6;

        class WriteConsoleOutput
        {
            public void BoolToConsole(bool variable)
            {
                Console.WriteLine(variable.ToString());
            }
        }

        public static void WriteBoolToConsole(bool variable)
        {
            ConsoleOutput.WriteConsoleOutput writeToConsole =
              new ConsoleOutput.WriteConsoleOutput();
            writeToConsole.BoolToConsole(variable);
        }
    }
}
