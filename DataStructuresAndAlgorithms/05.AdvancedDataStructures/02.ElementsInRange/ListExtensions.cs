using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ElementsInRange
{
    static class ListExtensions
    {
        public static string GetProductsToString(this List<Product> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("{0}: {1}\n", item.Name, item.Price);
            }
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
