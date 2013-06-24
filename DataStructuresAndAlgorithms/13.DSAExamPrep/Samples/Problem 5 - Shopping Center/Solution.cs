using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using System.Threading;
using System.Globalization;
using System.IO;

class Program
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        ShoppingCenter center = new ShoppingCenter();

        StringBuilder answer = new StringBuilder();

        int commands = int.Parse(Console.ReadLine());
        for (int i = 1; i <= commands; i++)
        {
            string command = Console.ReadLine();
            string commandResult = center.ProcessCommand(command);
            answer.AppendLine(commandResult);
        }

        Console.Write(answer);
    }
}

public class Product : IComparable<Product>
{
    private string name;
    private decimal price;
    private string producer;

    public Product(string name, string price, string producer)
    {
        this.name = name;
        this.price = decimal.Parse(price);
        this.producer = producer;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
        }
    }

    public string Producer
    {
        get
        {
            return producer;
        }
        set
        {
            producer = value;
        }
    }

    public string GetNameAndProducerKey()
    {
        string key = name + ";" + producer;
        return key;
    }

    public int CompareTo(Product other)
    {
        int resultOfCompare = name.CompareTo(other.name);
        if (resultOfCompare == 0)
        {
            resultOfCompare = producer.CompareTo(other.producer);
        }
        if (resultOfCompare == 0)
        {
            resultOfCompare = price.CompareTo(other.price);
        }
        return resultOfCompare;
    }

    public override string ToString()
    {
        string toString = "{" + name + ";" + producer + ";" + price.ToString("0.00") + "}";
        return toString;
    }

}

public class ShoppingCenter
{
    private const string PRODUCT_ADDED = "Product added";
    private const string X_PRODUCTS_DELETED = " products deleted";
    private const string NO_PRODUCTS_FOUND = "No products found";
    private const string INCORRECT_COMMAND = "Incorrect command";

    private readonly MultiDictionary<string, Product> productsByName;
    private readonly MultiDictionary<string, Product> nameAndProducer;
    private readonly OrderedMultiDictionary<decimal, Product> productsByPrice;
    private readonly MultiDictionary<string, Product> productsByProducer;

    public ShoppingCenter()
    {
        productsByName = new MultiDictionary<string, Product>(true);
        nameAndProducer = new MultiDictionary<string, Product>(true);
        productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
        productsByProducer = new MultiDictionary<string, Product>(true);
    }

    private string AddProduct(string name, string price, string producer)
    {
        Product product = new Product(name, price, producer);
        productsByName.Add(name, product);
        string nameAndProducerKey = product.GetNameAndProducerKey();
        nameAndProducer.Add(nameAndProducerKey, product);
        productsByPrice.Add(product.Price, product);
        productsByProducer.Add(producer, product);
        return PRODUCT_ADDED;
    }

    private string DeleteProducts(string name, string producer)
    {
        string nameAndProducerKey = name + ";" + producer;
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
            int countOfRemovedProducts = nameAndProducer[nameAndProducerKey].Count;
            nameAndProducer.Remove(nameAndProducerKey);
            string countMessage = countOfRemovedProducts + X_PRODUCTS_DELETED;
            return countMessage;
        }
    }

    private string DeleteProducts(string producer)
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
                string nameAndProducerKey = product.GetNameAndProducerKey();
                nameAndProducer.Remove(nameAndProducerKey, product);
                productsByPrice.Remove(product.Price, product);
            }
            int countOfRemovedProducts = productsByProducer[producer].Count;
            productsByProducer.Remove(producer);
            string countMessage = countOfRemovedProducts + X_PRODUCTS_DELETED;
            return countMessage;
        }
    }

    private string FindProductsByName(string name)
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

    private string FindProductsByPriceRange(string from, string to)
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

    private string FindProductsByProducer(string producer)
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
        StringBuilder builder = new StringBuilder();
        foreach (var product in sortedProducts)
        {
            builder.AppendLine(product.ToString());
        }
        string formattedProducts = builder.ToString().TrimEnd();
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
                    break;
                }
            case "FindProductsByName":
                {
                    commandResult = FindProductsByName(parameters[0]);
                    break;
                }

            case "FindProductsByPriceRange":
                {
                    commandResult = FindProductsByPriceRange(parameters[0], parameters[1]);
                    break;
                }
            case "FindProductsByProducer":
                {
                    commandResult = FindProductsByProducer(parameters[0]);
                    break;
                }
            default:
                {
                    commandResult = INCORRECT_COMMAND;
                    break;
                }
        }
        return commandResult;
    }
}
