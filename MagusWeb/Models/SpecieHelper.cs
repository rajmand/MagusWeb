namespace MagusWeb.Models
{
    public static class SpecieHelper
    {
        public static int LimitToMax(
            this int value, short? inclusiveMaximum)
        {
            if (inclusiveMaximum == null) return value;
            if (value > inclusiveMaximum) return (int)inclusiveMaximum;

            return value;
        }
    }
}