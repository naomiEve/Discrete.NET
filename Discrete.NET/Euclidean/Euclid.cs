using System.Numerics;

namespace Discrete.NET.Euclidean
{
    /// <summary>
    /// Euclidean algorithm container class.
    /// </summary>
    public static class Euclid
    {
        /// <summary>
        /// Computes the greatest common divisor using the extended euclidean algorithm.
        /// </summary>
        /// <param name="m">The m parameter.</param>
        /// <param name="n">The n parameter.</param>
        /// <returns>The euclidean result, or null if the parameters are wrong.</returns>
        public static EuclidResult<TNumber>? ExtendedEuclidGCD<TNumber>(TNumber m, TNumber n)
            where TNumber: ISignedNumber<TNumber>, IComparable<TNumber>
        {
            if ((m + n).CompareTo(TNumber.Zero) <= 0)
                return null;

            var d = m;
            var d_old = n;

            var s = TNumber.One;  var s_old = TNumber.Zero;
            var t = TNumber.Zero; var t_old = TNumber.One;

            while (d_old != TNumber.Zero)
            {
                var q = d / d_old;
                (d, d_old) = (d_old, d - q * d_old);
                (s, s_old) = (s_old, s - q * s_old);
                (t, t_old) = (t_old, t - q * t_old);
            }

            return new EuclidResult<TNumber>(d, s, t);
        }

        /// <summary>
        /// Computes the greatest common divisor of two numbers using the simple euclidean algorithm.
        /// </summary>
        /// <param name="n">The n parameter.</param>
        /// <param name="m">The m parameter.</param>
        /// <returns>The GCD, or null if the parameters are wrong.</returns>
        public static TNumber? EuclidGCD<TNumber>(TNumber n, TNumber m)
            where TNumber : struct, ISignedNumber<TNumber>, IComparable<TNumber>, IModulusOperators<TNumber, TNumber, TNumber>
        {
            if ((m + n).CompareTo(TNumber.Zero) <= 0)
                return null;

            while (n != TNumber.Zero)
                (m, n) = (n, m % n);

            return m;
        }
    }
}
