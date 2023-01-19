
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

            Assert.AreEqual(3030303, value!.Value);
        }

        [TestMethod]
        public void TestExtendedEuclidAlgorithmGoodData()
        {
            var value = Euclid.ExtendedEuclidGCD(14259, 3521);

            Assert.IsTrue(value.HasValue);

            Assert.AreEqual(7, value!.Value.GCD);
            Assert.AreEqual(161, value!.Value.S);
            Assert.AreEqual(-652, value!.Value.T);
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