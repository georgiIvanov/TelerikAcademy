using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.Text;


namespace _02.PointInTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            //3d vectors are necessary, because crossproduct creates a 
            //perpendicular vector, which doesnt exist in 2d space
            Vector3 a = new Vector3(1f, 1f, 0f);
            Vector3 b = new Vector3(3f, 1f, 0f);
            Vector3 c = new Vector3(2f, 3f, 0f);

            Vector3 x = new Vector3(2f, 2f, 0f);

            bool result = PointInTriangle(x, a, b, c);

            if (result)
            {
                Console.WriteLine("{0}is in triangle", x.ToString());
            }
            else
            {
                Console.WriteLine("{0}is NOT in triangle", x.ToString());
            }
        }

        static bool PointInTriangle(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
        {
            if (SameSide(p, a, b, c) && SameSide(p, b, a, c) && SameSide(p, c, a, b))
            {
                return true;
            }

            return false;
        }

        static bool SameSide(Vector3 p1, Vector3 p2, Vector3 a, Vector3 b)
        {
            Vector3 cp1 = Vector3.Cross(Vector3.Subtract(b, a), Vector3.Subtract(p1, a));
            Vector3 cp2 = Vector3.Cross(Vector3.Subtract(b, a), Vector3.Subtract(p2, a));

            if (Vector3.Dot(cp1, cp2) >= 0)
            {
                return true;
            }

            return false;
        }
    }
}
