namespace SimpleGeometry
{
    public abstract class Shape : IShape
    {
        private double area = -1;
        public double Area { get { return area == -1 ? area = ComputeArea() : area; } } 

        protected abstract double ComputeArea();
    }
}
