namespace CalendarManager.Infrastructure.Doubles
{
    public static class DoubleExtensions
    {
        public static bool IsZero(this double value)
        {
            return value == 0;
        }

        public static bool IsNotZero(this double value)
        {
            return !IsZero(value);
        }
    }
}