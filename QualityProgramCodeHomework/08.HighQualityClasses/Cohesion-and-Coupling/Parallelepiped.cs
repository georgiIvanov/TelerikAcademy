using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_and_Coupling
{
    class Parallelepiped
    {
        double width, height, depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("width", "Width cannot be negative or zero");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("height", "Width cannot be negative or zero");
                }
                this.height = value;
            }
        }

        public double Depth 
        {
            get
            {
                return this.depth;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("depth", "Width cannot be negative or zero");
                }
                this.depth = value;
            }
        }
    }
}
