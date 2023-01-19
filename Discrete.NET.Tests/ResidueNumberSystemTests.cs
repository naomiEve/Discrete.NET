using System.Numerics;

namespace Discrete.NET.Tests
{
    [TestClass]
    public class ResidueNumberSystemTests
    {
        [TestMethod]
        public void TestCanCreateResidueNumberSystemWorld()
        {
            _ = new ResidueNumberSystemWorld(2);
        }

        [TestMethod]
        public void TestCanCreateGoodResidueInt()
        {
            var world = new ResidueNumberSystemWorld(1);
            try
            {
                _ = world.CreateInt("123");
            }
            catch
            {
                Assert.Fail("Exception thrown when creating residue integer.");
            }
        }

        [TestMethod]
        public void TestFailsCreatingBadResidueInt()
        {
            var world = new ResidueNumberSystemWorld(1);
            try
            {
                _ = world.CreateInt("ABCD");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException, "Exception thrown when creating residue integer, but it wasn't the ArgumentException.");
            }
        }

        [TestMethod]
        public void TestBigIntConversionForSmallResidueInt()
        {
            var world = new ResidueNumberSystemWorld(5);
            var i = world.CreateInt("12345");

            Assert.AreEqual(new BigInteger(12345), i.ToBigInteger());
        }

        [TestMethod]
        public void TestBigIntConversionForBigResidueInt()
        {
            var world = new ResidueNumberSystemWorld(20);
            var i = world.CreateInt("47326489234723743284274023842348623948237498");

            Assert.AreEqual(BigInteger.Parse("47326489234723743284274023842348623948237498"), i.ToBigInteger());
        }

        [TestMethod]
        public void TestAdditionForSmallResidueInt()
        {
            var world = new ResidueNumberSystemWorld(5);
            var i = world.CreateInt("12345");
            var i2 = world.CreateInt("54321");

            var i3 = i + i2;

            Assert.AreEqual(new BigInteger(66666), i3.ToBigInteger());
        }

        [TestMethod]
        public void TestSubtractionForSmallResidueInt()
        {
            var world = new ResidueNumberSystemWorld(1);
            var i = world.CreateInt("15");
            var i2 = world.CreateInt("5");

            var i3 = i - i2;

            Assert.AreEqual(new BigInteger(10), i3.ToBigInteger());
        }

        [TestMethod]
        public void TestMultiplicationForSmallResidueInt()
        {
            var world = new ResidueNumberSystemWorld(1);
            var i = world.CreateInt("10");
            var i2 = world.CreateInt("5");

            var i3 = i * i2;

            Assert.AreEqual(new BigInteger(50), i3.ToBigInteger());
        }

        [TestMethod]
        public void TestAdditionForBigResidueInt()
        {
            var world = new ResidueNumberSystemWorld(20);
            var i = world.CreateInt("47326489234723743284274023842348623948237498");
            var i2 = world.CreateInt("34738947329847346234938247324");

            var i3 = i + i2;

            Assert.AreEqual(BigInteger.Parse("47326489234723778023221353689694858886484822"), i3.ToBigInteger());
        }

        [TestMethod]
        public void TestResidueIntArithmeticFailsWhenDifferentWorlds()
        {
            var world = new ResidueNumberSystemWorld(1);
            var world2 = new ResidueNumberSystemWorld(1);
            
            var i = world.CreateInt("12345");
            var i2 = world2.CreateInt("54321");

            try
            {
                var i3 = i + i2;
                Assert.Fail("Arithmetic operation succeeded despite different worlds.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is WorldMismatchException, "Exception was thrown but it wasn't the WorldMismatchException");
            }
        }
    }
}
