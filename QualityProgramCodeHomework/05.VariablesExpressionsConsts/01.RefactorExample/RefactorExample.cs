using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.RefactorExample
{
    public class RefactorExample
    {
        private static void Main(string[] args)
        {
        }

        public static Size GetRotatedSize(Size size, double rotationAngle)
        {
            double sizeWidth = Math.Abs(Math.Cos(rotationAngle)) * size.Width;
            sizeWidth += Math.Abs(Math.Sin(rotationAngle)) * size.Height;

            double sizeHeight = Math.Abs(Math.Sin(rotationAngle)) * size.Width;
            sizeHeight += Math.Abs(Math.Cos(rotationAngle)) * size.Height;

            return new Size(sizeWidth, sizeHeight);
        }
    }
}
