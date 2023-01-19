namespace Discrete.NET.Congruences
{
    /// <summary>
    /// Thrown when the modulo isn't the same while performing an arithmetic operation.
    /// </summary>
    public sealed class NotSameModuloException : Exception
    {
        /// <summary>
        /// Constructs a new exception for when the modulo isn't the same while performing an arithmetic operation.
        /// </summary>
        /// <param name="left">The first congruence.</param>
        /// <param name="right">The second congruence.</param>
        public NotSameModuloException(Congruence left, Congruence right)
            : base($"Expected the same modulo while performing arithmetic operation. Instead got {left.N} and {right.N}.")
        { 
        
        }
    }
}
