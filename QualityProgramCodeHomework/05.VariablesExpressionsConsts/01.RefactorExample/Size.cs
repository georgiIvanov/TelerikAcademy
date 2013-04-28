using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RefactorExample
{
    public class Size
    {
        private double width, height;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width
        {
            get { return this.width; }
        }

        public double Height
        {
            get { return this.height; }
        }
    }
}
