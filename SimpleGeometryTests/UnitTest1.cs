using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGeometry;
using System;

namespace SimpleGeometryTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTriangle()
        {
            var t1 = new Triangle(3, 4, 5);
            Assert.IsTrue(t1.IsOrthogonal);
            Assert.AreEqual(t1.Area(), 30);
            Assert.AreEqual(t1.Perimeter(), 12);

            var t2 = new Triangle(5, 12, 13);
            Assert.IsTrue(t2.IsOrthogonal);
            Assert.AreEqual(t2.Area(), 390);
            Assert.AreEqual(t2.Perimeter(), 30);

            var t3 = new Triangle(5, 5, 5);
            Assert.IsFalse(t3.IsOrthogonal);
            Assert.AreEqual(t3.Angles[0], t3.Angles[2]);
            Assert.AreEqual(Math.Round(t3.Area(), 3), 10.825d);

            Assert.ThrowsException<ArgumentException>(() => { var triangle = new Triangle(0, 1, 1); });
            Assert.ThrowsException<ArgumentException>(() => { var triangle = new Triangle(2, 3, 5); });
        }

        [TestMethod]
        public void TestCircle()
        {
            var c1 = new Circle(3);
            Assert.AreEqual(c1.Area(), 9 * Math.PI);
            Assert.AreEqual(c1.Perimeter(), 6 * Math.PI);

            Assert.ThrowsException<ArgumentException>(() => { var circle = new Circle(0); });
        }
    }
}