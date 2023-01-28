using System.Numerics;
using Discrete.NET.Euclidean;
using Discrete.NET.Prime;

namespace Discrete.NET.Cryptography.RSA
{
    public static class KeyPairGenerator
    {
        /// <summary>
        /// Generates a keypair for the RSA algorithm.
        /// </summary>
        /// <returns>The keypair.</returns>
        public static (PrivateKey, PublicKey) GenerateKeypair()
        {
            BigInteger p = PrimeGenerator.GenerateLongPrimeNumber();
            BigInteger q = PrimeGenerator.GenerateLongPrimeNumber(); 

            var n = p * q;
            var pq = (p - 1) * (q - 1);

            BigInteger e;
            do
            {
                e = PrimeGenerator.GeneratePrimeNumber();
            } while (Euclid.EuclidGCD(e, pq)!.Value != 1 || e >= n);

            var eEuclid = Euclid.ExtendedEuclidGCD(e, pq);
            var d = eEuclid!.Value.S + pq;

            return (new PrivateKey(d, e), new PublicKey(n, e));
        }
    }
}
