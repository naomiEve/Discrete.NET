using Discrete.NET.Euclidean;

namespace Discrete.NET.Congruences
{
    /// <inheritdoc/>
    public partial class Congruence
    {
        /// <summary>
        /// Proper modulo for negative numbers.
        /// </summary>
        /// <param name="x">The number.</param>
        /// <param name="m">The modulo.</param>
        /// <returns>The modulo result.</returns>
        private static int Modulo(int x, int m)
        {
            return (x % m + m) % m;
        }

        /// <summary>
        /// Reduces the congruence to its most simple form.
        /// </summary>
        public void Reduce()
        {
            if (Reduced)
                return;

            var maybeEuclid = Euclid.ExtendedEuclidGCD(A, N);
            if (maybeEuclid == null)
                return;

            var euclid = maybeEuclid.Value;

            // If the GCD isn't 1, we cannot reduce this any further.
            // We don't have an invertible element.
            if (euclid.GCD != 1)
                return;

            A *= euclid.S;
            B *= euclid.S;

            A = Modulo(A, N);
            B = Modulo(B, N);

            Reduced = true;
        }
    }
}
