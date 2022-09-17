namespace SimpleGeometry
{
    public struct Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Радиус окружности должен быть больше 0.");

            Radius = radius;
        }

        public double Area() => Math.PI * Math.Pow(Radius, 2);
    }
}
