using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.NumberOfWorkdays
{
    class NumberOfWorkdays
    {
        static void Main(string[] args)
        {
            DateTime[] holidays = new DateTime[5];
            
            Console.WriteLine("Write first date in format YYYY.MM.DD: ");
            string input = Console.ReadLine();
            string[] dateArgs = input.Split('.');
            DateTime firstDay = new DateTime(int.Parse(dateArgs[0]), int.Parse(dateArgs[1]), int.Parse(dateArgs[1]));

            holidays[0] = new DateTime(firstDay.Year, 12, 25);
            holidays[1] = new DateTime(firstDay.Year, 12, 31);
            holidays[2] = new DateTime(firstDay.Year, 1, 31);
            holidays[3] = new DateTime(firstDay.Year, 3, 3);
            holidays[4] = new DateTime(firstDay.Year, 3, 15);


            Console.WriteLine("Write second date in format YYYY.MM.DD: ");
            input = Console.ReadLine();
            dateArgs = input.Split('.');
            DateTime secondDay = new DateTime(int.Parse(dateArgs[0]), int.Parse(dateArgs[1]), int.Parse(dateArgs[1]));
            bool isWorkingDay;
            int workingDays = 0;

            while (!firstDay.Equals(secondDay))
            {
                isWorkingDay = true;
                if (firstDay.DayOfWeek != DayOfWeek.Saturday && firstDay.DayOfWeek != DayOfWeek.Sunday)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (holidays[i].Equals(firstDay))
                        {
                            isWorkingDay = false;
                            break;
                        }
                    }
                    if (isWorkingDay)
                    {
                        workingDays++;
                    }
                }

                firstDay = firstDay.AddDays(1);
            }

            Console.WriteLine("Working days: {0}", workingDays);

        }
    }
}
