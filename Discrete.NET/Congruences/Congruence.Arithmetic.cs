namespace Discrete.NET.Congruences
{
    /// <inheritdoc/>
    public partial class Congruence
    {
        /// <summary>
        /// Adds two congruences together.
        /// </summary>
        /// <param name="left">The first congruence.</param>
        /// <param name="right">The second congruence.</param>
        /// <returns>The newly created congruence.</returns>
        /// <exception cref="NotSameModuloException">Throws when the modulo for both congruences isn't the same.</exception>
        public static Congruence operator +(Congruence left, Congruence right)
        {
            if (!left.IsSameModulo(right))
                throw new NotSameModuloException(left, right);

            var congruence = new Congruence(left.A + right.A, left.B + right.B, left.N);
            return congruence;
        }

        /// <summary>
        /// Subtracts two congruences together.
        /// </summary>
        /// <param name="left">The first congruence.</param>
        /// <param name="right">The second congruence.</param>
        /// <returns>The newly created congruence.</returns>
        /// <exception cref="NotSameModuloException">Throws when the modulo for both congruences isn't the same.</exception>
        public static Congruence operator -(Congruence left, Congruence right)
        {
            if (!left.IsSameModulo(right))
                throw new NotSameModuloException(left, right);

            var congruence = new Congruence(left.A - right.A, left.B - right.B, left.N);
            return congruence;
        }

        /// <summary>
        /// Multiplies two congruences together.
        /// </summary>
        /// <param name="left">The first congruence.</param>
        /// <param name="right">The second congruence.</param>
        /// <returns>The newly created congruence.</returns>
        /// <exception cref="NotSameModuloException">Throws when the modulo for both congruences isn't the same.</exception>
        public static Congruence operator *(Congruence left, Congruence right)
        {
            if (!left.IsSameModulo(right))
                throw new NotSameModuloException(left, right);

            var congruence = new Congruence(left.A * right.A, left.B * right.B, left.N);
            return congruence;
        }

        /// <summary>
        /// Raises this congruence to a power.
        /// </summary>
        /// <param name="n">The power.</param>
        public void Pow(int n)
        {
            A = (int)Math.Pow(A, n);
            B = (int)Math.Pow(B, n);
        }
    }
}
