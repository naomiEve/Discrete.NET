using Discrete.NET.Congruences;

namespace Discrete.NET.Residue
{
    /// <summary>
    /// A single int existing in a residue number system world.
    /// </summary>
    public partial class ResidueInt
    {
        /// <summary>
        /// The congruences this int has.
        /// </summary>
        private readonly List<Congruence> _congruences;

        /// <summary>
        /// The world we've been constructed in.
        /// </summary>
        private readonly ResidueNumberSystemWorld _world;

        /// <summary>
        /// Constructs a new residue int from the world and the value it should parse.
        /// </summary>
        /// <param name="world">The world for this residue int.</param>
        /// <param name="value">Its value.</param>
        internal ResidueInt(ResidueNumberSystemWorld world, string value)
        {
            // Pre-alloc the required amount of congruences.
            _congruences = new(world.CongruenceCount);

            _world = world;
            Parse(value);
        }

        /// <summary>
        /// Clones a residue int from another residue int and applies a lambda onto it.
        /// </summary>
        /// <param name="other">The other residue int.</param>
        private ResidueInt(ResidueInt other)
        {
            _world = other._world;
            _congruences = new List<Congruence>(other._congruences);
        }

        /// <summary>
        /// Checks whether two residue ints are in the same world.
        /// </summary>
        /// <param name="other">The other residue int.</param>
        /// <returns>Whether they are in the same world.</returns>
        public bool IsInSameWorld(ResidueInt other)
        {
            return _world == other._world;
        }
    }
}
