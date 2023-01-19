using Discrete.NET.Euclidean;
using Discrete.NET.Extensions;

namespace Discrete.NET.Congruences
{
    /// <inheritdoc/>
    public partial class Congruence
    {        /// <summary>
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

            A = A.Modulo(N);
            B = B.Modulo(N);

            Reduced = true;
        }
    }
}
