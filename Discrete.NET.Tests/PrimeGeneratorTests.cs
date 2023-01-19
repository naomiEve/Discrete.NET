using Discrete.NET.Prime;

namespace Discrete.NET.Tests
{
    [TestClass]
    public class PrimeGeneratorTests
    {
        [TestMethod]
        public void TestMillerRabinPrimes()
        {
            Assert.IsTrue(PrimeGenerator.PrimalityCheck(2));
            Assert.IsTrue(PrimeGenerator.PrimalityCheck(3));
            Assert.IsTrue(PrimeGenerator.PrimalityCheck(11));
            Assert.IsTrue(PrimeGenerator.PrimalityCheck(13));
            Assert.IsTrue(PrimeGenerator.PrimalityCheck(2147483647));
        }

        [TestMethod]
        public void TestMillerRabinNonPrimes()
        {
            Assert.IsFalse(PrimeGenerator.PrimalityCheck(6));
            Assert.IsFalse(PrimeGenerator.PrimalityCheck(22));
            Assert.IsFalse(PrimeGenerator.PrimalityCheck(81));
            Assert.IsFalse(PrimeGenerator.PrimalityCheck(129140163));
            Assert.IsFalse(PrimeGenerator.PrimalityCheck(454573464));
        }

        [TestMethod]
        public void TestGeneratePrime()
        {
            var prime = PrimeGenerator.GeneratePrimeNumber();
            Assert.IsTrue(PrimeGenerator.PrimalityCheck(prime));
        }

        [TestMethod]
        public void TestGenerateTenPrimes()
        {
            var primes = PrimeGenerator.GenerateNPrimes(10);
            foreach (var prime in primes)
                Assert.IsTrue(PrimeGenerator.PrimalityCheck(prime));
        }
    }
}
