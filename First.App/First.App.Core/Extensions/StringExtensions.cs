namespace First.App.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool NullCheck(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }
            return false;
        }
    }
}
