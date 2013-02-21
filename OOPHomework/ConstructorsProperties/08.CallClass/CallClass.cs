using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CallClass
{
    static void Main(string[] args)
    {
        GSM phone = new GSM("lala", "sumsAng", "batman", 10000.99);

        phone.MakeCall(DateTime.Now, "0899999999", 3.44);

        Console.WriteLine(phone.ShowCall().ToString());
    }
}

class GSM
{
    public Battery battery { get; set; }
    public Display display { get; set; }
    private Call phoneCall;

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

    public void MakeCall(DateTime dateCallIsMade, string dialedNumber, double duration)
    {
        phoneCall =new Call(dateCallIsMade, dialedNumber, duration);
    }

    public Call ShowCall()
    {
        return phoneCall;
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

class Call
{
    DateTime date;
    string dialedPhone;
    double duration;

    public Call(DateTime dateCallIsMade, string dialedNumber, double duration)
    {
        this.date = dateCallIsMade;
        this.dialedPhone = dialedNumber;
        this.duration = duration;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Date: {0}.{1}.{2}\n", date.Day, date.Month, date.Year);
        sb.AppendFormat("Time: {0}\n", date.TimeOfDay);
        sb.AppendFormat("Duration: {0}\n", duration);
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