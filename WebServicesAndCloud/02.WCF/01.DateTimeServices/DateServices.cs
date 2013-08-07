using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace _01.DateTimeServicesLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DateService : IDateService
    {

        public string GetDayOfWeek(DateTime date)
        {
            CultureInfo bg = new CultureInfo("bg-BG");
            string sunday = bg.DateTimeFormat.DayNames[(int)date.DayOfWeek];

            return sunday;
        }
    }
}
