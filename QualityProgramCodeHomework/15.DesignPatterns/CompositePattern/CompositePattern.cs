using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositePattern.Shapes;

namespace CompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositeGraphic allShapes = new CompositeGraphic();
            CompositeGraphic triangles = new CompositeGraphic();
            CompositeGraphic squares = new CompositeGraphic();
            CompositeGraphic circles = new CompositeGraphic();

            triangles.Add(new Triangle());

            circles.AddRange(new Circle(), new Circle(), new Circle());

            squares.AddRange(new Square(),new Square(), circles);

            

            allShapes.AddRange(new Triangle(),
                triangles,
                squares);

            allShapes.Print();

            Console.WriteLine("\n\nPrint only squares leaf: ");
            squares.Print();
        }
    }

    
    
    

    
}