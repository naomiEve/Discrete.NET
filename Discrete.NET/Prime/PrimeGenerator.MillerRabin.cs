using System.Numerics;

namespace Discrete.NET.Prime
{
    /// <inheritdoc/>
    internal static partial class PrimeGenerator
    {
        /// <summary>
        /// Miller-Rabin algorithm for checking for the primality of an integer.
        /// </summary>
        /// <remarks>Adapted from rosetta code: https://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test#C#</remarks>
        /// <param name="n">The number to check.</param>
        /// <param name="checks">The amount of checks.</param>
        /// <returns>Whether this value is a prime.</returns>
        public static bool PrimalityCheck(long n, int k = 128)
        {
            if ((n < 2) || (n % 2 == 0))
                return n == 2;

            var s = n - 1;
            while (s % 2 == 0)
                s >>= 1;

            for (var i = 0; i < k; i++)
            {
                var a = _rng.NextInt64(n - 1) + 1;
                var temp = s;
                var mod = BigInteger.ModPow(a, s, n);

                while (temp != n - 1 &&
                    mod != 1 &&
                    mod != n - 1)
                {
                    mod = (mod * mod) % n;
                    temp *= 2;
                }

                if (mod != n - 1 && temp % 2 == 0)
                    return false;
            }
            return true;
        }
    }
}
