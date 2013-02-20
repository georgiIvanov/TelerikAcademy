using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MobilePhoneClass
{
    class AddStaticProperty
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GSM.iPhone4SInfo);
        }
    }

    class GSM
    {
        public Battery battery { get; set; }
        public Display display { get; set; }

        public static string iPhone4SInfo = "iPhone information \nManufacturer: Apple\nDisplay: Bad\nBattery: 3 hrs in standby\nUtility: Useless";

        public string model { get; set; }
        public string manufacturer { get; set; }
        public string owner { get; set; }
        public double? price { get; set; }

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
        public string model { get; set; }
        public int hoursIdle { get; set; }
        public int hoursTalk { get; set; }

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
        public double sizeInches { get; set; }
        public int numberOfColors { get; set; }

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
