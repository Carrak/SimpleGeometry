using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGeometry;
using System;

namespace SimpleGeometryTests
{
    [TestClass]
    public class TriangleTests
    { 
        [TestMethod]
        [DataRow(3, 4, 5, 30, 0)]
        [DataRow(3, 10, 8, 9.92157, 0.00001)]
        [DataRow(10, 10, 10, 43.30127, 0.00001)]
        [DataRow(19, 11, 10, 42.4, 0.1)]
        public void TestTriangleArea(double a, double b, double c, double expectedArea, double delta)
        {
            var triangle = new Triangle(a, b, c);
            Assert.AreEqual(expectedArea, triangle.Area(), delta);
        }

        [TestMethod]
        [DataRow(10, 10, 10, false)]
        [DataRow(3, 4, 5, true)]
        [DataRow(5, 12, 13, true)]
        [DataRow(5.5, 12.1, 13.29135, true)]
        [DataRow(5.5, 12.1, 13.3, false)]
        [DataRow(3.3333333333333333, 4.4444444444444444, 5.5555555555555555, true)]
        [DataRow(3.1415926535897931, 2.7182818284590451, 4.154354402313313, true)]
        [DataRow(3.1415926535897931, 2.7182818284590451, 4.15435, true)]
        [DataRow(3.1415926535897931, 2.7182818284590451, 4.1544, false)]
        [DataRow(3.14159, 2.71828, 4.154354402313313, true)]
        public void TestTriangleIsRight(double a, double b, double c, bool expectedIsRight)
        {
            var triangle = new Triangle(a, b, c);
            Assert.AreEqual(expectedIsRight, triangle.IsRight);
        }

        [TestMethod]
        [DataRow(2, 3, 5)]
        [DataRow(1, 2, 10000)]
        [DataRow(0, 0, 0)]
        [DataRow(2, 2, 0)]
        [DataRow(-12, 5, 13)]
        [DataRow(3, -4, -5)]
        [DataRow(double.NaN, double.PositiveInfinity, double.NegativeInfinity)]
        [DataRow(double.NaN, 12, 13)]
        [DataRow(12, double.PositiveInfinity, 13)]
        [DataRow(12, 13, double.NegativeInfinity)]
        public void TestTriangleInvalidInput(double a, double b, double c)
        {
            Assert.ThrowsException<ArgumentException>(() => { var triangle = new Triangle(a, b, c); });
        }
    }
}