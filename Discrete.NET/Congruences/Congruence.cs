using Discrete.NET.Euclidean;

namespace Discrete.NET.Congruences
{
    /// <summary>
    /// A single congruence.
    /// </summary>
    public partial class Congruence
    {
        /// <summary>
        /// The a part of the congruence.
        /// </summary>
        public int A { get; private set; }

        /// <summary>
        /// The b part of the congruence.
        /// </summary>
        public int B { get; private set; }

        /// <summary>
        /// The n part of the congruence.
        /// </summary>
        public int N { get; private set; }

        /// <summary>
        /// Was this congruence reduced?
        /// </summary>
        public bool Reduced { get; private set; }

        /// <summary>
        /// Constructs a new congruence with the given parameters.
        /// </summary>
        /// <param name="a">The A parameter.</param>
        /// <param name="b">The B parameter.</param>
        /// <param name="n">The modulo.</param>
        public Congruence(int a, int b, int n)
        {
            A = a;
            B = b;
            N = n;
        }

        /// <summary>
        /// Are two congruences pairwise coprime?
        /// </summary>
        /// <param name="other">The other congruence.</param>
        /// <returns>True for when they are. False otherwise.</returns>
        public bool IsPairwiseCoprime(Congruence other)
        {
            var euclid = Euclid.ExtendedEuclidGCD(N, other.N);

            return euclid.HasValue && 
                euclid.Value.GCD == 1;
        }

        /// <summary>
        /// Returns whether both congruences have the same modulo.
        /// </summary>
        /// <param name="other">The other congruence.</param>
        /// <returns>Whether the modulo is the same.</returns>
        public bool IsSameModulo(Congruence other)
        {
            return N == other.N;
        }

        /// <summary>
        /// Returns the value of this congruence for the given whole number k.
        /// </summary>
        /// <param name="k">The number.</param>
        /// <returns>The value.</returns>
        public int ValueFor(int k)
        {
            if (!Reduced)
                Reduce();

            return B + (k * N);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (A == 1)
                return $"x ~ {B} (mod {N})";
            return $"{A}x ~ {B} (mod {N})";
        }
    }
}
