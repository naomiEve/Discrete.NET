namespace Discrete.NET.Extensions
{
    /// <summary>
    /// Extensions for the built in integer type.
    /// </summary>
    internal static class IntExtensions
    {
        /// <summary>
        /// Proper modulo for negative numbers.
        /// </summary>
        /// <param name="x">The number.</param>
        /// <param name="m">The modulo.</param>
        /// <returns>The modulo result.</returns>
        public static int Modulo(this int x, int m)
        {
            return (x % m + m) % m;
        }
    }
}
