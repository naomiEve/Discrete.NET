using Discrete.NET.Euclidean;
using Discrete.NET.Extensions;

namespace Discrete.NET.Congruences
{
    /// <inheritdoc/>
    public partial class Congruence
    {
        /// <summary>
        /// Simplifies the congruence into its most basic form.
        /// </summary>
        public void Simplify()
        {
            if (Simplified)
                return;

            var maybeEuclid = Euclid.ExtendedEuclidGCD(A, N);
            if (maybeEuclid == null)
                return;

            var euclid = maybeEuclid.Value;

            // First, check if the GCD is 1. If it is, we can proceed to reduce the congruence
            // to the form 'x ≅ b (mod n)'.
            if (euclid.GCD == 1)
            {
                Reduce(euclid);
            }
            // Otherwise, if the GCD divides B, we can try to simplify the congruence and then reduce it.
            else if ((B % euclid.GCD) == 0)
            {
                // Divide everything by the GCD.
                A /= euclid.GCD;
                B /= euclid.GCD;
                N /= euclid.GCD;

                // Attempt to simplify again, in order to (maybe) reduce the congruence to the simplest form possible.
                Simplify();
            }

            Simplified = true;

        }

        /// <summary>
        /// Reduces the into the form x ≅ b (mod n).
        /// </summary>
        private void Reduce(EuclidResult euclid)
        {
            if (Reduced)
                return;

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
