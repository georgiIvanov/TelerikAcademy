using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Point3D
{
    class Point3DProgram
    {
        static void Main(string[] args)
        {
            Point3D point = new Point3D(1, 2, 3);

            Console.WriteLine(point.ToString());

        }
    }

    struct Point3D
    {
        int x { get; set; }
        int y { get; set; }
        int z { get; set; }

        public Point3D(int x, int y, int z) : this()
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override string ToString()
        {
            return x.ToString() + " " + y.ToString() + " " + z.ToString();
        }
    }
}
