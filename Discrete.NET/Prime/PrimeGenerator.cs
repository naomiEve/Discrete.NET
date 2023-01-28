namespace Discrete.NET.Prime
{
    /// <summary>
    /// A prime generator.
    /// </summary>
    internal static partial class PrimeGenerator
    {
        private static readonly Random _rng;

        /// <summary>
        /// The static constructor, generates the random number generator.
        /// </summary>
        static PrimeGenerator()
        {
            _rng = new Random((int)DateTimeOffset.Now.ToUnixTimeSeconds());
        }

        /// <summary>
        /// Generates n primes.
        /// </summary>
        /// <param name="n">The amount of primes to generate.</param>
        /// <returns>The primes.</returns>
        public static int[] GenerateNPrimes(int n)
        {
            var result = Enumerable.Range(0, n)
                                   .Select(_ => GeneratePrimeNumber())
                                   .ToArray();
            return result;
        }

        /// <summary>
        /// Generates a prime number.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int GeneratePrimeNumber(int min = 0, int max = 500000)
        {
            var p = 4;
            while (!PrimalityCheck(p))
                p = (int)GeneratePrimeCandidate(min, max);

            return p;
        }

        /// <summary>
        /// Generates a long prime number.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static long GenerateLongPrimeNumber(long min = int.MaxValue, long max = long.MaxValue - 1)
        {
            var p = 4L;
            while (!PrimalityCheck(p))
                p = GeneratePrimeCandidate(min, max);

            return p;
        }

        /// <summary>
        /// Generates a prime candidate.
        /// </summary>
        /// <param name="length">The length in bits of the candidate.</param>
        /// <returns>The prime candidate.</returns>
        private static long GeneratePrimeCandidate(long min, long max)
        {
            var p = _rng.NextInt64(min, max);

            // Set the LSB (to ensure the number is actually odd).
            p |= 1;
            return p;
        }
    }
}
