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
        public void Area(double a, double b, double c, double expectedArea, double delta)
        {
            var triangle = new Triangle(a, b, c);
            Assert.AreEqual(expectedArea, triangle.Area, delta);
        }

        [TestMethod]
        [DataRow(3, 4, 5)]
        [DataRow(3, 10, 8)]
        [DataRow(10, 10, 10)]
        [DataRow(19, 11, 10)]
        public void CachedArea(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);
            var area = triangle.Area;
            Assert.AreEqual(area, triangle.Area);
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
        public void IsRight(double a, double b, double c, bool expectedIsRight)
        {
            var triangle = new Triangle(a, b, c);
            Assert.AreEqual(expectedIsRight, triangle.IsRight);
        }

        [TestMethod]
        [DataRow(2, 3, 5, DisplayName = "Две стороны равны третьей")]
        [DataRow(1, 2, 10000, DisplayName = "Две стороны меньше третьей")]
        [DataRow(-12, 5, 13, DisplayName = "Первая сторона меньше нуля")]
        [DataRow(12, -5, 13, DisplayName = "Вторая сторона меньше нуля")]
        [DataRow(12, -5, -13, DisplayName = "Третья сторона меньше нуля")]
        [DataRow(0, 5, 13, DisplayName = "Первая сторона равна нулю")]
        [DataRow(12, 0, 13, DisplayName = "Вторая сторона равна нулю")]
        [DataRow(12, -5, 0, DisplayName = "Третья сторона равна нулю")]
        [DataRow(double.NaN, 12, 13, DisplayName = "Первая сторона не численный (NaN)")]
        [DataRow(12, double.PositiveInfinity, 13, DisplayName = "Вторая сторона не численный (Плюс бесконечность)")]
        [DataRow(12, 13, double.NegativeInfinity, DisplayName = "Третья сторона не численный (Минус бесконечность)")]
        public void InvalidInput(double a, double b, double c)
        {
            Assert.ThrowsException<ArgumentException>(() => { var triangle = new Triangle(a, b, c); });
        }
    }
}