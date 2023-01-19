using Discrete.NET.Congruences;

namespace Discrete.NET.Residue
{
    /// <inheritdoc/>
    public partial class ResidueInt
    {
        /// <summary>
        /// Performs arithmetic on the congruence list of this residue int and a different residue int.
        /// </summary>
        /// <param name="other">The other residue int (must be from the same world!)</param>
        /// <param name="function">The function to apply on them.</param>
        /// <exception cref="WorldMismatchException">Thrown when one of the residue ints is from a different world.</exception>
        private void ReduceWithOperatorAndOtherInt(ResidueInt other, Func<Congruence, Congruence, Congruence> function)
        {
            if (!IsInSameWorld(other))
                throw new WorldMismatchException();

            for (var i = 0; i < _congruences.Count; i++)
                _congruences[i] = function(_congruences[i], other._congruences[i]);
        }

        /// <summary>
        /// Adds two residue ints together.
        /// </summary>
        /// <param name="left">The first residue int.</param>
        /// <param name="right">The second residue int.</param>
        /// <returns>The added ints.</returns>
        /// <exception cref="WorldMismatchException">Thrown when the residue ints come from differing worlds.</exception>
        public static ResidueInt operator +(ResidueInt left, ResidueInt right)
        {
            if (!left.IsInSameWorld(right))
                throw new WorldMismatchException();

            var residueInt = new ResidueInt(left);
            residueInt.ReduceWithOperatorAndOtherInt(right, (left, right) => left + right);

            return residueInt;
        }

        /// <summary>
        /// Subtracts two residue ints together.
        /// </summary>
        /// <param name="left">The first residue int.</param>
        /// <param name="right">The second residue int.</param>
        /// <returns>The subtracted ints.</returns>
        /// <exception cref="WorldMismatchException">Thrown when the residue ints come from differing worlds.</exception>
        public static ResidueInt operator -(ResidueInt left, ResidueInt right)
        {
            if (!left.IsInSameWorld(right))
                throw new WorldMismatchException();

            var residueInt = new ResidueInt(left);
            residueInt.ReduceWithOperatorAndOtherInt(right, (left, right) => left - right);

            return residueInt;
        }

        /// <summary>
        /// Multiplies two residue ints together.
        /// </summary>
        /// <param name="left">The first residue int.</param>
        /// <param name="right">The second residue int.</param>
        /// <returns>The multiplied ints.</returns>
        /// <exception cref="WorldMismatchException">Thrown when the residue ints come from differing worlds.</exception>
        public static ResidueInt operator *(ResidueInt left, ResidueInt right)
        {
            if (!left.IsInSameWorld(right))
                throw new WorldMismatchException();

            var residueInt = new ResidueInt(left);
            residueInt.ReduceWithOperatorAndOtherInt(right, (left, right) => left * right);

            return residueInt;
        }
    }
}
