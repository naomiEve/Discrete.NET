using System.Numerics;

namespace Discrete.NET.Cryptography.RSA
{
    /// <summary>
    /// The private key for the RSA algorithm.
    /// </summary>
    public class PrivateKey
    {
        /// <summary>
        /// The D part of the private key.
        /// </summary>
        public BigInteger D { get; init; }

        /// <summary>
        /// The E part of the private key (it must be the same as the public key's).
        /// </summary>
        public BigInteger E { get; init; }

        public PrivateKey(BigInteger D, BigInteger E)
        {
            this.D = D;
            this.E = E;
        }

        /// <summary>
        /// Decrypts an RSA encrypted message with this private key (and the corresponding public key).
        /// </summary>
        /// <param name="message">The encrypted message.</param>
        /// <param name="pubKey">The public key.</param>
        /// <returns>The decrypted message.</returns>
        public BigInteger Decrypt(BigInteger message, PublicKey pubKey)
        {
            var decMessage = BigInteger.ModPow(message, D, pubKey.N);
            return decMessage;
        }
    }
}
