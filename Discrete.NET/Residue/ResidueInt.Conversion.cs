using System.Numerics;
using Discrete.NET.Congruences;

namespace Discrete.NET.Residue
{
    /// <inheritdoc/>
    public partial class ResidueInt
    {
        /// <summary>
        /// Parses an integer into a list of congruences.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <exception cref="ArgumentException">Thrown when we couldn't parse the string into a big integer.</exception>
        private void Parse(string value)
        {
            if (!BigInteger.TryParse(value, out BigInteger bigint))
                throw new ArgumentException(value, nameof(value));

            foreach (var prime in _world.GetPrimes())
            {
                // Add this to the list of congruences.
                var mod = bigint % prime;
                _congruences.Add(new Congruence(1, (int)mod, prime));
            }
        }

        /// <summary>
        /// Converts this residue integer into a BigInteger using the Chinese Remainder Theorem.
        /// </summary>
        /// <returns>The resulting big integer.</returns>
        public BigInteger ToBigInteger()
        {
            // Calculate the product of all the moduli.
            // So: n1 * n2 * ... * nk
            var product = BigInteger.One;
            foreach (var congruence in _congruences)
                product *= congruence.N;

            var sm = BigInteger.Zero;
            foreach (var congruence in _congruences)
            {
                var n = congruence.N;
                var p = product / n;

                // Considering that the modulo will always be prime here, we can use Fermat's little theorem
                // to get the multiplicative inverse.
                var inv = BigInteger.ModPow(p, n - 2, n);
                sm += congruence.B * inv * p;
            }

            return sm % product;
        }
    }
}
