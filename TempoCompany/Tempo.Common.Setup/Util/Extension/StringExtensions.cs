namespace Tempo.Common.Setup.Util.Extension
{
    public static class StringExtensions
    {

        /// <summary>
        /// responsible for truncating/trimming a string to a specified maximum length.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
