namespace SimpleGeometry
{
    public class Triangle : Shape
    {
        private const double PrecisionTolerance = 1E-5;

        public IReadOnlyList<double> Sides { get; }
        public bool IsRight { get; }

        public Triangle(double a, double b, double c)
        {
            if (!double.IsFinite(a) || !double.IsFinite(b) || !double.IsFinite(c))
                throw new ArgumentException($"Все стороны треугольника должны быть численными значениями. ({a}, {b}, {c})");

            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException($"Все стороны треугольника должны быть больше 0. ({a}, {b}, {c})");

            var sides = GetSortedSides(a, b, c);
            
            if (sides[0] + sides[1] <= sides[2])
                throw new ArgumentException($"Любые две стороны треугольника всегда должны быть больше третьей. ({a}, {b}, {c})");
            
            Sides = Array.AsReadOnly(sides);
            IsRight = TolerantEquals(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2), Math.Pow(sides[2], 2), PrecisionTolerance);
        }

        private static double[] GetSortedSides(double a, double b, double c)
        {
            var sides = new double[] { a, b, c };

            for(int i = 0; i < sides.Length - 1; i++)
                for (int j = 1; j < sides.Length - i; j++)
                    if (sides[j - 1] > sides[j])
                    {
                        var temp = sides[j];
                        sides[j] = sides[j - 1];
                        sides[j - 1] = temp;
                    }

            return sides;
        }

        private static bool TolerantEquals(double x, double y, double tolerance)
        {
            double epsilon = Math.Max(Math.Abs(x), Math.Abs(y)) * tolerance;
            return Math.Abs(x - y) <= epsilon;
        }

        protected override double ComputeArea()
        {
            if (IsRight)
                return Sides[0] * Sides[1] / 2;

            double p = (Sides[0] + Sides[1] + Sides[2]) / 2;
            return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
        }
    }
}
