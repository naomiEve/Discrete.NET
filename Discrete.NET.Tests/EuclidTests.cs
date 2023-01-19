
namespace Discrete.NET.Tests
{
    [TestClass]
    public class EuclidTests
    {
        [TestMethod]
        public void TestSimpleEuclidAlgorithmGoodData()
        {
            var value = Euclid.EuclidGCD(12121212, 21212121);
            Assert.IsTrue(value.HasValue);

            Assert.AreEqual(value!.Value, 3030303);
        }

        [TestMethod]
        public void TestExtendedEuclidAlgorithmGoodData()
        {
            var value = Euclid.ExtendedEuclidGCD(14259, 3521);

            Assert.IsTrue(value.HasValue);

            Assert.AreEqual(value!.Value.GCD, 7);
            Assert.AreEqual(value!.Value.S, 161);
            Assert.AreEqual(value!.Value.T, -652);
        }

        [TestMethod]
        public void TestSimpleEuclidAlgorithmBadData()
        {
            var value = Euclid.EuclidGCD(0, 0);

            Assert.IsFalse(value.HasValue);
        }

        [TestMethod]
        public void TestExtendedEuclidAlgorithmBadData()
        {
            var value = Euclid.ExtendedEuclidGCD(0, 0);

            Assert.IsFalse(value.HasValue);
        }
    }
}