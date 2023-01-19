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
        public static EuclidResult? ExtendedEuclidGCD(int m, int n)
        {
            if (m + n <= 0)
                return null;

            var d = m;
            var d_old = n;

            var s = 1; var s_old = 0;
            var t = 0; var t_old = 1;

            while (d_old != 0)
            {
                var q = d / d_old;
                (d, d_old) = (d_old, d - q * d_old);
                (s, s_old) = (s_old, s - q * s_old);
                (t, t_old) = (t_old, t - q * t_old);
            }

            return new EuclidResult(d, s, t);
        }

        /// <summary>
        /// Computes the greatest common divisor of two numbers using the simple euclidean algorithm.
        /// </summary>
        /// <param name="n">The n parameter.</param>
        /// <param name="m">The m parameter.</param>
        /// <returns>The GCD, or null if the parameters are wrong.</returns>
        public static int? EuclidGCD(int n, int m)
        {
            if (m + n <= 0)
                return null;

            while (n != 0)
                (m, n) = (n, m % n);

            return m;
        }
    }
}
