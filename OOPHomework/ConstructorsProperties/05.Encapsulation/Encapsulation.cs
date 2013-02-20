using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MobilePhoneClass
{
    class MobilePhoneClass
    {
        static void Main(string[] args)
        {
            GSM phone = new GSM("lala", "sumsAng", "batman", 10000.99);
            GSM secondPhone = new GSM("lol", "krusha", "suparMan", 9999,
                new Battery("tuhla", 2, 1), new Display(5.5, 3));

            Console.WriteLine(phone.ToString());
            Console.WriteLine(secondPhone.ToString());
        }
    }

    class GSM
    {
        private Battery battery { get; set; }
        private Display display { get; set; }

        private string model { get; set; }
        private string manufacturer { get; set; }
        private string owner { get; set; }
        private double? price { get; set; }

        public GSM(string model, string manuf, string owner, double price)
        {
            this.model = model;
            this.manufacturer = manuf;
            this.owner = owner;
            this.price = price;
        }

        public GSM(string model, string manuf, string owner, double price, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manuf;
            this.owner = owner;
            this.price = price;
            this.battery = battery;
            this.display = display;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Model: {0}\n", model);
            sb.AppendFormat("Manufacturer: {0}\n", manufacturer);

            if (owner != null)
                sb.AppendFormat("Owner: {0}\n", owner);
            if (price != null)
                sb.AppendFormat("Price: {0}\n", price);

            if (battery != null)
            {
                sb.Append(battery.ToString());
            }
            if (display != null)
            {
                sb.Append(display.ToString());
            }
            return sb.ToString();
        }

    }

    class Battery
    {
        private string model { get; set; }
        private int hoursIdle { get; set; }
        private int hoursTalk { get; set; }

        public Battery(string model, int hoursIdle, int hoursTalk)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Battery model: {0}\n", model);
            sb.AppendFormat("Battery hours idle: {0}\n", hoursIdle);
            sb.AppendFormat("Battery hours talk: {0}\n", hoursTalk);
            return sb.ToString();
        }
    }

    class Display
    {
        private double sizeInches { get; set; }
        private int numberOfColors { get; set; }

        public Display(double sizeInches, int numberOfColors)
        {
            this.sizeInches = sizeInches;
            this.numberOfColors = numberOfColors;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Display size in inches: {0}\n", sizeInches);
            sb.AppendFormat("Display number of colors: {0}\n", numberOfColors);
            return sb.ToString();
        }
    }
}
