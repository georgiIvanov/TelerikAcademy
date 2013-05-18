using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Shapes
{
    class Circle : IGraphic
    {
        public void Print()
        {
            Console.WriteLine("Circle");
        }
    }
}
