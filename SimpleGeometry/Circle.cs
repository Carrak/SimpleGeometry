namespace SimpleGeometry
{
    public class Circle : Shape
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

        protected override double ComputeArea() => Math.PI * Math.Pow(Radius, 2);
    }
}
