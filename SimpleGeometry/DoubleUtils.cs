namespace SimpleGeometry
{
    public static class DoubleUtils
    {
        // Эта функция ранее находилась в классе Triangle,
        // что нарушало single responsibility principle

        public static bool TolerantEquals(this double x, double y, double tolerance)
        {
            //double epsilon = Math.Max(Math.Abs(x), Math.Abs(y)) * tolerance;

            // Сравнение с абсолютным значением более понятно
            // и выигрывает по производительности
            return Math.Abs(x - y) <= tolerance;
        }
    }
}