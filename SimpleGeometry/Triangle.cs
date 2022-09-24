namespace SimpleGeometry
{
    public struct Triangle : IShape
    {
        // предпочёл бы PRECISION_TOLERANCE, ибо читающему сразу понятно, что это константа,
        // но документация не согласна со мной
        private const double PrecisionTolerance = 1E-5;

        public IReadOnlyList<double> Sides { get; }
        public bool IsRight { get; }

        public Triangle(double a, double b, double c)
        {
            if (!double.IsFinite(a))
                throw new ArgumentException($"Параметр '{nameof(a)}' не является числом.");
            if (!double.IsFinite(b))
                throw new ArgumentException($"Параметр '{nameof(b)}' не является числом.");
            if (!double.IsFinite(c))
                throw new ArgumentException($"Параметр '{nameof(c)}' не является числом.");
            
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Все стороны треугольника должны быть больше 0.");

            var sides = new double[] { a, b, c };
            for (int i = 1; i < sides.Length; i++)
                if (sides[i - 1] > sides[i])
                {
                    var temp = sides[i];
                    sides[i] = sides[i - 1];
                    sides[i - 1] = temp;
                }
            
            if (sides[0] + sides[1] <= sides[2])
                throw new ArgumentException("Любые две стороны треугольника всегда должны быть больше третьей.");
            
            Sides = Array.AsReadOnly(sides);
            IsRight = TolerantEquals(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2), Math.Pow(sides[2], 2), PrecisionTolerance);
        }

        private static bool TolerantEquals(double x, double y, double tolerance)
        {
            double epsilon = Math.Max(Math.Abs(x), Math.Abs(y)) * tolerance;
            return Math.Abs(x - y) <= epsilon;
        }

        public double Area()
        {
            if (IsRight)
                return Sides[0] * Sides[1] * Sides[2] / 2;

            double p = (Sides[0] + Sides[1] + Sides[2]) / 2;
            return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
        }
    }
}
