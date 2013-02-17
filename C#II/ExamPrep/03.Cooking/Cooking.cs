using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace _03.Cooking
{
    class Cooking
    {

        static List<string> recipeProducts = new List<string>();
        static List<decimal> recipeAmount = new List<decimal>();
        static List<string> originalUnit = new List<string>();

        static void Main(string[] args)
        {
            int recipeProductsCount = int.Parse(Console.ReadLine());
            

            for (int p = 0; p < recipeProductsCount; p++)
            {
                string recipeLine = Console.ReadLine();
                string[] tokens = recipeLine.Split(':');
                decimal amount = decimal.Parse(tokens[0], CultureInfo.InvariantCulture);
                string unit = tokens[1];
                string product = tokens[2];
                AddProduct(product, amount, unit);

            }

        }

        private static void AddProduct(string product, decimal amount, string unit)
        {
            decimal amountMililiters = ConvertToMililiters(unit, amount);
            for (int p = 0; p < recipeProducts.Count; p++)
            {
                if (string.Compare(recipeProducts[p], product, true) == 0)
                {
                    recipeAmount[p] += amountMililiters;
                    return;
                }
            }
            recipeProducts.Add(product);
            recipeAmount.Add(amountMililiters);
            originalUnit.Add(unit);
        }

        private static decimal ConvertToMililiters(string unit, decimal amount)
        {
            switch (unit)
            {
                case "mls": return amount * 1000; 
                case "ls": return amount * 1000; 
                case "tbsps": return amount * 15; 
                case "fl ozs": return amount * 30; 
                case "tsps": return amount * 5; 
                case "gals": return amount * 3840; 
                case "pts": return amount * 480; 
                case "qts": return amount * 960; 
                case "cups": return amount * 240; 
                default:
                    throw new ArgumentException("Invalid unit");
            }
        }

        private static decimal ConvertToUnit(string unit, decimal amount)
        {
            switch (unit)
            {
                case "mls": return amount / 1000;
                case "ls": return amount / 1000;
                case "tbsps": return amount / 15;
                case "fl ozs": return amount / 30;
                case "tsps": return amount / 5;
                case "gals": return amount / 3840;
                case "pts": return amount / 480;
                case "qts": return amount / 960;
                case "cups": return amount / 240;
                default:
                    throw new ArgumentException("Invalid unit");
            }
        }
    }
}
