namespace Nircbot.Common.Extensions
{
    /// <summary>
    /// The string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Formats the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The formatted string.</returns>
        public static string FormatWith(this string value, params object[] args)
        {
            return string.Format(value, args);
        }
    }
}