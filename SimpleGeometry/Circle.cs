namespace SimpleGeometry
{
    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (!double.IsFinite(radius))
                throw new ArgumentException($"Радиус не является числом. ({radius})");
             
            if (radius <= 0)
                throw new ArgumentException($"Радиус окружности должен быть больше 0. ({radius})");
            
            Radius = radius;
        }

        protected override double ComputeArea() => Math.PI * Math.Pow(Radius, 2);
    }
}
