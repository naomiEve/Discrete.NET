namespace Discrete.NET.Residue
{
    /// <summary>
    /// Thrown when we try to perform arithmetic on two residue numbers with mismatching worlds.
    /// </summary>
    public class WorldMismatchException : Exception
    {
        /// <summary>
        /// Creates a new WorldMismatchException.
        /// </summary>
        public WorldMismatchException()
            : base("Mismatched worlds detected while trying to perform arithmetic on residue ints.")
        { 
        
        }
    }
}
