using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGeometry;
using System;

namespace SimpleGeometryTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        [DataRow(1, 3.141, 0.01)]
        [DataRow(3, 28.274, 0.001)]
        [DataRow(4, 50.265, 0.001)]
        [DataRow(10, 314.159, 0.001)]
        public void TestArea(double r, double expectedArea, double delta)
        {
            var circle = new Circle(r);
            Assert.AreEqual(expectedArea, circle.Area(), delta);
        }

        [TestMethod]
        [DataRow(double.NaN)]
        [DataRow(double.PositiveInfinity)]
        [DataRow(double.NegativeInfinity)]
        [DataRow(0)]
        [DataRow(-10)]
        public void TestCircleInvalidInput(double r)
        {
            Assert.ThrowsException<ArgumentException>(() => { var circle = new Circle(r); });
        }
    }
}
