namespace SimpleGeometry
{
    public struct Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (!double.IsFinite(radius))
                throw new ArgumentException($"Параметр '{nameof(radius)}' не является числом.");

            if (radius <= 0)
                throw new ArgumentException("Радиус окружности должен быть больше 0.");

            Radius = radius;
        }

        public double Area() => Math.PI * Math.Pow(Radius, 2);
    }
}
