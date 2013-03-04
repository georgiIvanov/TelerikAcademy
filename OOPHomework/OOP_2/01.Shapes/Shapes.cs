using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tr = new Triangle(1, 3);
            Rectangle rect = new Rectangle(2, 2);
            Circle circle = new Circle(3);

            Console.WriteLine(tr.CalculateSurface());
            Console.WriteLine(rect.CalculateSurface());
            Console.WriteLine(circle.CalculateSurface());
        }
    }

    public abstract class Shape
    {
        protected double width, height;

        public abstract double CalculateSurface();
    }

    public class Triangle : Shape
    {

        public Triangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateSurface()
        {
            return height * width / 2;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateSurface()
        {
            return width * height;
        }
    }

    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.width = radius;
            this.height = radius;
        }

        public override double CalculateSurface()
        {
            return Math.PI * width * width;
        }
    }
}
