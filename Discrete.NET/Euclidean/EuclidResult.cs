namespace Discrete.NET.Euclidean
{
    /// <summary>
    /// The result of the extended euclidean algorithm.
    /// </summary>
    public readonly struct EuclidResult
    {
        /// <summary>
        /// The greatest common divisor.
        /// </summary>
        public int GCD { get; init; }

        /// <summary>
        /// The S parameter.
        /// </summary>
        public int S { get; init; }

        /// <summary>
        /// The T parameter.
        /// </summary>
        public int T { get; init; }

        /// <summary>
        /// Constructs a new extended euclidean algorithm result.
        /// </summary>
        /// <param name="GCD">The resulting greatest common divisor.</param>
        /// <param name="S">The S parameter.</param>
        /// <param name="T">The T parameter.</param>
        public EuclidResult(int GCD, int S, int T)
        {
            this.GCD = GCD;
            this.S = S;
            this.T = T;
        }
    }
}
