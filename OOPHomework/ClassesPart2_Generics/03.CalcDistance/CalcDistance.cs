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
            Point3D firstPoint= new Point3D(1, 1, 1);
            Point3D secondPoint = new Point3D(3, 3, 3);
            Console.WriteLine(Distance.DistanceBetween2Points(firstPoint, secondPoint));
        }
    }

    static class Distance
    {
        public static double DistanceBetween2Points(Point3D a, Point3D b)
        {
            double dist = Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2) + Math.Pow(a.z - b.z, 2));

            return dist;
        }
    }

    struct Point3D
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

        private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

        static public Point3D GetZeroPoint
        {
            get
            {
                return zeroPoint;
            }
        }

        public Point3D(int x, int y, int z)
            : this()
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
