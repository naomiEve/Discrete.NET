using System.Diagnostics;
using System.Numerics;

namespace Discrete.NET.Cryptography.RSA
{
    /// <summary>
    /// The public key for the RSA algorithm.
    /// </summary>
    public class PublicKey
    {
        /// <summary>
        /// The N part of the public key.
        /// </summary>
        public BigInteger N { get; init; }

        /// <summary>
        /// The E part of the public key.
        /// </summary>
        public BigInteger E { get; init; }

        public PublicKey(BigInteger n, BigInteger e)
        {
            N = n;
            E = e;
        }

        /// <summary>
        /// Encrypt a message with the public key.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The encrypted message.</returns>
        public BigInteger Encrypt(BigInteger message)
        {
            Debug.Assert(message < N);
            var encMessage = BigInteger.ModPow(message, E, N);
            return encMessage;
        }
    }
}
