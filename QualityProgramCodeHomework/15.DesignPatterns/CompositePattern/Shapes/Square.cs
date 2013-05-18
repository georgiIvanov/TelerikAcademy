using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern.Shapes
{
    class Square : IGraphic
    {
        public void Print()
        {
            Console.WriteLine("Square");
        }
    }
}
