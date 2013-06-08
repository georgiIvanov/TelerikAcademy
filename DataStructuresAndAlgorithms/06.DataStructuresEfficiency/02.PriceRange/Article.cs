using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PriceRange
{
    struct Article : IComparable<Article>
    {
        int barcode;
        double price;
        string vendor;
        string title;

        public Article(int barcode, double price, string vendor, string title)
        {
            this.barcode = barcode;
            this.price = price;
            this.vendor = vendor;
            this.title = title;
        }

        public int CompareTo(Article other)
        {
            return this.price.CompareTo(other.price);
        }

        public int Barcode
        {
            get
            {
                return this.barcode;
            }
            set
            {
                this.barcode = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public string Vendor
        {
            get
            {
                return this.vendor;
            }
            set
            {
                this.vendor = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }
    }
}
