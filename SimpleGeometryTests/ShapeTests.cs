using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleGeometry;

namespace SimpleGeometryTests
{
    [TestClass]
    public class ShapeTests
    {
        private const double TestArea = 13;

        [TestMethod]
        public void CachedArea()
        {
            var shape = new ShapeMock();
            var area = shape.Area;
            Assert.AreEqual(TestArea, area);
            Assert.AreEqual(area, shape.Area);
        }

        private class ShapeMock : Shape
        {
            protected override double ComputeArea() => TestArea;
        }
    }
}
