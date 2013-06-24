using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.IO;
using Wintellect.PowerCollections;

namespace _05.ShoppingCenter
{
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            ShoppingCenter center = new ShoppingCenter();
            StringBuilder answer = new StringBuilder();

            int commands = int.Parse(Console.ReadLine());
            for (int i = 0; i < commands; i++)
            {
                string command = Console.ReadLine();
                string commandResult = center.ProcessCommand(command);
                answer.AppendLine(commandResult);
            }
            Console.WriteLine(answer);

        }
    }

    class Product : IComparable<Product>
    {
        public string Name;
        public decimal Price;
        public string Producer;

        public Product(string name, string price, string producer)
        {
            this.Name = name;
            this.Price = decimal.Parse(price);
            this.Producer = producer;
        }

        public string GetNameAndProducer()
        {
            string key = string.Format("{0};{1}", Name, Producer);
            return key;
        }

        public int CompareTo(Product other)
        {
            int resultOfCompare = Name.CompareTo(other.Name);
            if (resultOfCompare == 0)
            {
                resultOfCompare = Producer.CompareTo(other.Producer);
            }
            if (resultOfCompare == 0)
            {
                resultOfCompare = Price.CompareTo(other.Price);
            }

            return resultOfCompare;
        }

        public override string ToString()
        {
            string result = string.Format("{0}{1};{2};{3:F2}{4}", "{", Name, Producer, Price, "}");
            return result;
        }
    }

    public class ShoppingCenter
    {
        private const string PRODUCT_ADDED = "Product added";
        private const string X_PRODUCTS_DELETED = " products deleted";
        private const string NO_PRODUCTS_FOUND = "No products found";
        private const string INCORRECT_COMMAND = "Incorrect command";

        MultiDictionary<string, Product> productsByName;
        MultiDictionary<string, Product> nameAndProducer;
        OrderedMultiDictionary<decimal, Product> productsByPrice;
        MultiDictionary<string, Product> productsByProducer;

        public ShoppingCenter()
        {
            productsByName = new MultiDictionary<string, Product>(true);
            nameAndProducer = new MultiDictionary<string, Product>(true);
            productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
            productsByProducer = new MultiDictionary<string, Product>(true);
        }

        string AddProduct(string name, string price, string producer)
        {
            Product product = new Product(name, price, producer);
            productsByName.Add(name, product);
            string nameAndProducerKey = product.GetNameAndProducer();
            nameAndProducer.Add(nameAndProducerKey, product);
            productsByPrice.Add(product.Price, product);
            productsByProducer.Add(producer, product);

            return PRODUCT_ADDED;
        }

        string DeleteProducts(string name, string producer)
        {
            string nameAndProducerKey = string.Format("{0};{1}", name, producer);
            if (!nameAndProducer.ContainsKey(nameAndProducerKey))
            {
                return NO_PRODUCTS_FOUND;
            }
            else
            {
                var productsToBeRemoved = nameAndProducer[nameAndProducerKey];
                foreach (var product in productsToBeRemoved)
                {
                    productsByName.Remove(name, product);
                    productsByProducer.Remove(producer, product);
                    productsByPrice.Remove(product.Price, product);
                }
                int countOfRemoved = nameAndProducer[nameAndProducerKey].Count;
                nameAndProducer.Remove(nameAndProducerKey);
                string countMessage = countOfRemoved + X_PRODUCTS_DELETED;

                return countMessage;
            }
        }

        string DeleteProducts(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                return NO_PRODUCTS_FOUND;
            }
            else
            {
                var productsToBeRemoved = productsByProducer[producer];
                foreach (var product in productsToBeRemoved)
                {
                    productsByName.Remove(product.Name, product);
                    string nameAndProducerKey = product.GetNameAndProducer();
                    nameAndProducer.Remove(nameAndProducerKey, product);
                    productsByPrice.Remove(product.Price, product);
                }
                int countOfRemoved = productsByProducer[producer].Count;
                productsByProducer.Remove(producer);
                string countMessage = countOfRemoved + X_PRODUCTS_DELETED;

                return countMessage;
            }
        }

        string FindProductsByName(string name)
        {
            if (!productsByName.ContainsKey(name))
            {
                return NO_PRODUCTS_FOUND;
            }
            else
            {
                var productsFound = productsByName[name];
                string formattedProducts = FormatProductForPrint(productsFound);
                return formattedProducts;
            }
        }

        string FindProductsByPriceRange(string from, string to)
        {
            decimal rangeStart = decimal.Parse(from);
            decimal rangeEnd = decimal.Parse(to);
            var productsFound = productsByPrice.Range(rangeStart, true, rangeEnd, true).Values;
            if (productsFound.Count == 0)
            {
                return NO_PRODUCTS_FOUND;
            }
            else
            {
                string formattedProducts = FormatProductForPrint(productsFound);
                return formattedProducts;
            }
        }

        string FindProductsByProducer(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                return NO_PRODUCTS_FOUND;
            }
            else
            {
                var productsFound = productsByProducer[producer];
                string formattedProducts = FormatProductForPrint(productsFound);
                return formattedProducts;
            }
        }

        private string FormatProductForPrint(ICollection<Product> products)
        {
            List<Product> sortedProducts = new List<Product>(products);
            sortedProducts.Sort();

            StringBuilder sb = new StringBuilder();
            foreach (var product in sortedProducts)
            {
                sb.AppendLine(product.ToString());
            }
            string formattedProducts = sb.ToString().TrimEnd();
            return formattedProducts;
        }

        public string ProcessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parameterValues = command.Substring(indexOfFirstSpace + 1);
            string[] parameters = parameterValues.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string commandResult;
            switch (method)
            {
                case "AddProduct":
                    {
                        commandResult = AddProduct(parameters[0], parameters[1], parameters[2]);
                        break;
                    }
                case "DeleteProducts":
                    {
                        if (parameters.Length == 1)
                        {
                            commandResult = DeleteProducts(parameters[0]);
                        }
                        else
                        {
                            commandResult = DeleteProducts(parameters[0], parameters[1]);
                        }
                    }
                    break;
                case "FindProductsByName":
                    {
                        commandResult = FindProductsByName(parameters[0]);
                    }
                    break;
                case "FindProductsByPriceRange":
                    {
                        commandResult = FindProductsByPriceRange(parameters[0], parameters[1]);
                    }
                    break;
                case "FindProductsByProducer":
                    {
                        commandResult = FindProductsByProducer(parameters[0]);
                    }
                    break;
                default:
                    {
                        commandResult = INCORRECT_COMMAND;
                    }
                    break;
            }

            return commandResult;
        }
    }
}
