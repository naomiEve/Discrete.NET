using Discrete.NET.Prime;

namespace Discrete.NET.Residue
{
    /// <summary>
    /// The world for the number system (specifying the precision).
    /// </summary>
    public sealed class ResidueNumberSystemWorld
    {
        /// <summary>
        /// The amount of congruences for each integer. (Also its precision).
        /// </summary>
        public int CongruenceCount { get; init; }

        /// <summary>
        /// The primes.
        /// </summary>
        private readonly int[] _primes;

        /// <summary>
        /// Constructs a new world for the residue number system.
        /// </summary>
        /// <param name="congruenceCount">The amount of congruences for each integer.</param>
        public ResidueNumberSystemWorld(int congruenceCount)
        {
            CongruenceCount = congruenceCount;
            _primes = PrimeGenerator.GenerateNPrimes(CongruenceCount);
        }

        /// <summary>
        /// Creates a new integer from within this world.
        /// </summary>
        /// <param name="value">The value (as a string).</param>
        /// <returns>The newly created residue number system integer.</returns>
        public ResidueInt CreateInt(string value)
        {
            return new ResidueInt(this, value);
        }

        /// <summary>
        /// Gets the primes selected for this residue number system.
        /// </summary>
        /// <returns>The primes enumerator.</returns>
        internal IReadOnlyList<int> GetPrimes()
        {
            return _primes;
        }
    }
}
