namespace SimpleGeometry
{
    public struct Triangle : IShape
    {
        public double[] Sides { get; }
        public bool IsRight { get; }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Все стороны треугольника должны быть больше 0.");

            Sides = new double[] { a, b, c };
            for (int i = 1; i < Sides.Length; i++)
                if (Sides[i - 1] > Sides[i])
                {
                    var temp = Sides[i];
                    Sides[i] = Sides[i - 1];
                    Sides[i - 1] = temp;
                }

            if (Sides[0] + Sides[1] <= Sides[2])
                throw new ArgumentException("Любые две стороны треугольника всегда должны быть больше третьей.");
            
            IsRight = Math.Pow(Sides[0], 2) + Math.Pow(Sides[1], 2) == Math.Pow(Sides[2], 2);
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
