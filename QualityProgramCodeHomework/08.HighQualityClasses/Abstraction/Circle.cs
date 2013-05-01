using System;

namespace Abstraction
{
    class Circle : Figure
    {
        double radius;

        public Circle(double radius)
            : base(radius, radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("radius", "Radius cannot be negative or zero");
                }
                this.radius = value;
            }
        }

        public override double Width
        {
            get
            {
                return Radius * 2;
            }
        }

        public override double Height
        {
            get
            {
                return Radius * 2;
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
    }
}
