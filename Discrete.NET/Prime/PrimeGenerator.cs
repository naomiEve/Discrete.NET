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
        public static int GeneratePrimeNumber()
        {
            var p = 4;
            while (!PrimalityCheck(p))
                p = GeneratePrimeCandidate();

            return p;
        }

        /// <summary>
        /// Generates a prime candidate.
        /// </summary>
        /// <param name="length">The length in bits of the candidate.</param>
        /// <returns>The prime candidate.</returns>
        private static int GeneratePrimeCandidate()
        {
            var p = _rng.Next(0, 500000);

            // Set the LSB (to ensure the number is actually odd).
            p |= 1;
            return p;
        }
    }
}
