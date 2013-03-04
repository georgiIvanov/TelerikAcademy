using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shapes
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

    abstract class Shape
    {
        protected double width, height;

        public abstract double CalculateSurface();
    }

    class Triangle : Shape
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

    class Rectangle : Shape
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

    class Circle : Shape
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
