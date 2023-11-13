namespace SimpleGeometry
{
    public class Triangle : IShape
    {
        // Пользователь может изменить точность при надобности
        public static double RightTrianglePrecision { get; set; } = 1E-4;

        public IReadOnlyList<double> Sides { get; }
        public bool IsRightAngled { get; }

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
            IsRightAngled = IsTriangleRightAngled(sides);
        }

        public double Area()
        {
            // Катеты - две меньшие стороны (Sides отсортирован)
            if (IsRightAngled)
                return Sides[0] * Sides[1] / 2;

            double p = (Sides[0] + Sides[1] + Sides[2]) / 2;
            return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
        }

        private static double[] GetSortedSides(double a, double b, double c)
        {
            if (a > c)
                (a, c) = (c, a);

            if (a > b) 
                (a, b) = (b, a);

            if (b > c)
                (b, c) = (c, b);

            return new double[] { a, b, c };
        }

        private static bool IsTriangleRightAngled(double[] s)
        {
            double legs = s[0] * s[0] + s[1] * s[1];
            double hypotenuse = s[2] * s[2];
            return legs.TolerantEquals(hypotenuse, RightTrianglePrecision);
        }
    }
}
