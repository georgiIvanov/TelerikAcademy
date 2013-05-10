using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorMatrix;

namespace WalkInMatrixTests
{

    [TestClass]
    public class WalkTests
    {
        [TestMethod]
        public void CreateMatrix()
        {
            WalkInMatrix walk = new WalkInMatrix(3);
            Assert.IsNotNull(walk);
        }

        [TestMethod]
        public void ToStringSize3()
        {
            WalkInMatrix walk = new WalkInMatrix(3);
            walk.FillMatrix();
            string expected = "  1  7  8\r\n" +
                              "  6  2  9\r\n" +
                              "  5  4  3\r\n";
            string actual = walk.ToString();
            Assert.AreEqual(expected, walk.ToString());
        }

        [TestMethod]
        public void ToStringSize6()
        {
            WalkInMatrix walk = new WalkInMatrix(6);
            walk.FillMatrix();
            string expected = "  1 16 17 18 19 20\r\n" +
                              " 15  2 27 28 29 21\r\n" +
                              " 14 31  3 26 30 22\r\n" +
                              " 13 36 32  4 25 23\r\n" +
                              " 12 35 34 33  5 24\r\n" + 
                              " 11 10  9  8  7  6\r\n";
            string actual = walk.ToString();
            Assert.AreEqual(expected, walk.ToString());
        }

        [TestMethod]
        public void GetMatrix()
        {
            WalkInMatrix walk = new WalkInMatrix(3);
            walk.FillMatrix();
            int[,] expected = new int[,]{ {1,  7,  8},
                                          {6,  2,  9},
                                          {5,  4,  3},
                                        };
            int[,] actual = walk.GetMatrix;
            bool areEqual = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (expected[i, j] != actual[i, j])
                    {
                        areEqual = false;
                    }
                }
            }

            Assert.AreEqual(true, areEqual);
        }

          
    }
}
