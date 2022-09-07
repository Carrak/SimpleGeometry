namespace SimpleGeometry
{
    public struct Triangle : IShape
    {
        public double[] Sides { get; }
        public double[] Angles { get; }
        public bool IsOrthogonal { get; }

        public Triangle(double s1, double s2, double s3)
        {
            if (s1 <= 0 || s2 <= 0 || s3 <= 0)
                throw new ArgumentException("Все стороны треугольника должны быть больше 0.");

            if (s1 + s2 <= s3 || s1 + s3 <= s2 || s2 + s3 <= s1)
                throw new ArgumentException("Любые две стороны треугольника всегда должны быть больше третьей.");

            Sides = new[] { s1, s2, s3 };
            Angles = new double[3];
            IsOrthogonal = false;

            Angles[0] = GetAngle(s1, s2, s3);
            Angles[1] = GetAngle(s2, s1, s3);
            Angles[2] = GetAngle(s3, s1, s2);

            foreach (var angle in Angles)
                if (angle == Math.PI / 2)
                {
                    IsOrthogonal = true;
                    break;
                }
        }

        public double Area()
        {
            if (IsOrthogonal)
                return Sides[0] * Sides[1] * Sides[2] / 2;

            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
        }

        public double Perimeter() => Sides.Sum();

        private static double GetAngle(double primarySide, double side1, double side2) => Math.Acos((Math.Pow(side1, 2) + Math.Pow(side2, 2) - Math.Pow(primarySide, 2)) / 2 * side1 * side2);
    }
}
