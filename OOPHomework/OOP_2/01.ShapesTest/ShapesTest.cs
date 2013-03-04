using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace _01.ShapesTest
{
    [TestClass]
    public class ShapesTest
    {
        [TestMethod]
        public void TriangleAreaTest()
        {
            Triangle[] triangles = new Triangle[5];
            triangles[0] = new Triangle(2, 2);
            triangles[1] = new Triangle(4, 2);
            triangles[2] = new Triangle(1, 3);
            triangles[3] = new Triangle(2, 3);
            triangles[4] = new Triangle(1, 1);

            Assert.AreEqual(2, triangles[0].CalculateSurface());
            Assert.AreEqual(4, triangles[1].CalculateSurface());
            Assert.AreEqual(1.5, triangles[2].CalculateSurface());
            Assert.AreEqual(3, triangles[3].CalculateSurface());
            Assert.AreEqual(0.5, triangles[4].CalculateSurface());
        }

        [TestMethod]
        public void RectangleAreaTest()
        {
            Rectangle[] rects = new Rectangle[3];
            rects[0] = new Rectangle(2, 3);
            rects[1] = new Rectangle(1.22, 3.21);
            rects[2] = new Rectangle(4.21, 2);

            Assert.AreEqual(6, rects[0].CalculateSurface());
            Assert.AreEqual(3.9162, rects[1].CalculateSurface());
            Assert.AreEqual(8.42, rects[2].CalculateSurface());
        }

        [TestMethod]
        public void CircleAreaTest()
        {
            Circle[] circles = new Circle[3];
            circles[0] = new Circle(4);
            circles[1] = new Circle(6);
            circles[2] = new Circle(1.23);

            Assert.AreEqual(4*4*Math.PI, circles[0].CalculateSurface());
            Assert.AreEqual(6*6*Math.PI, circles[1].CalculateSurface());
            Assert.AreEqual(1.23*1.23*Math.PI, circles[2].CalculateSurface());
        }
    }
}
