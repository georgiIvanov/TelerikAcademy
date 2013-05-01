using System;

namespace Abstraction
{
    abstract class Figure
    {
        double width, heigth;
        private Figure()
        {
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.heigth;
            }
            set
            {
                this.heigth = value;
            }
        }
    }
}
