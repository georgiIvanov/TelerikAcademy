using System.Linq;
using UsingEntityFrameworkModel;
using System;


class AttachDetachEntities
{
    static void Main()
    {
        var product = GetProduct(1);
        Console.WriteLine(product.ProductName);

        UpdateProduct(product, product.ProductName + " Updated");

        var updatedProduct = GetProduct(1);
        Console.WriteLine(updatedProduct.ProductName);            
    }

    static Product GetProduct(int id)
    {
        using (NorthwindEntities northwindEntities = new NorthwindEntities())
        {
            Product product = northwindEntities.Products.First(p => p.ProductID == id);
            return product;
        }
    }

    static void UpdateProduct(Product product, string newName)
    {
        using (NorthwindEntities northwindEntities = new NorthwindEntities())
        {
            northwindEntities.Products.Attach(product); // This line is required!
            product.ProductName = newName;
            northwindEntities.SaveChanges();
        }
    }
}
