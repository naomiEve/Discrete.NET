namespace Discrete.NET.Tests
{
    [TestClass]
    public class CongruenceTests
    {
        [TestMethod]
        public void TestCongruenceSimpleReduction()
        {
            var congruence = new Congruence(2, 3, 5);
            congruence.Reduce();

            Assert.IsTrue(congruence.Reduced);

            Assert.AreEqual(congruence.A, 1);
            Assert.AreEqual(congruence.B, 4);
            Assert.AreEqual(congruence.N, 5);
        }

        [TestMethod]
        public void TestCongruenceNotReduced()
        {
            var congruence = new Congruence(6, 12, 15);
            congruence.Reduce();

            Assert.IsFalse(congruence.Reduced);
        }

        [TestMethod]
        public void TestCongruenceAdditionSameModulo()
        {
            var congruence = new Congruence(2, 3, 5);
            var congruence2 = new Congruence(4, 1, 5);

            try
            {
                var congruence3 = congruence + congruence2;
                Assert.AreEqual(congruence3.A, congruence.A + congruence2.A);
                Assert.AreEqual(congruence3.B, congruence.B + congruence2.B);
                Assert.AreEqual(congruence3.N, congruence.N);
            }
            catch (NotSameModuloException e)
            {
                Assert.Fail($"Caught a modulo error: {e}");
            }
        }

        [TestMethod]
        public void TestCongruenceMultiplicationSameModulo()
        {
            var congruence = new Congruence(2, 3, 5);
            var congruence2 = new Congruence(4, 1, 5);

            try
            {
                var congruence3 = congruence * congruence2;
                Assert.AreEqual(congruence3.A, congruence.A * congruence2.A);
                Assert.AreEqual(congruence3.B, congruence.B * congruence2.B);
                Assert.AreEqual(congruence3.N, congruence.N);
            }
            catch (NotSameModuloException e)
            {
                Assert.Fail($"Caught a modulo error: {e}");
            }
        }

        [TestMethod]
        public void TestCongruenceSubtractionSameModulo()
        {
            var congruence = new Congruence(2, 3, 5);
            var congruence2 = new Congruence(4, 1, 5);

            try
            {
                var congruence3 = congruence - congruence2;
                Assert.AreEqual(congruence3.A, congruence.A - congruence2.A);
                Assert.AreEqual(congruence3.B, congruence.B - congruence2.B);
                Assert.AreEqual(congruence3.N, congruence.N);
            }
            catch (NotSameModuloException e)
            {
                Assert.Fail($"Caught a modulo error: {e}");
            }
        }

        [TestMethod]
        public void TestCongruenceAdditionDifferentModulo()
        {
            var congruence = new Congruence(2, 3, 5);
            var congruence2 = new Congruence(4, 1, 6);

            try
            {
                var congruence3 = congruence + congruence2;
                Assert.Fail("Operation succeeded despite different moduli.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is NotSameModuloException, "Exception thrown but it wasn't the modulo exception.");
            }
        }

        [TestMethod]
        public void TestCongruenceMultiplicationDifferentModulo()
        {
            var congruence = new Congruence(2, 3, 5);
            var congruence2 = new Congruence(4, 1, 6);

            try
            {
                var congruence3 = congruence * congruence2;
                Assert.Fail("Operation succeeded despite different moduli.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is NotSameModuloException, "Exception thrown but it wasn't the modulo exception.");
            }
        }

        [TestMethod]
        public void TestCongruenceSubtractionDifferentModulo()
        {
            var congruence = new Congruence(2, 3, 5);
            var congruence2 = new Congruence(4, 1, 6);

            try
            {
                var congruence3 = congruence - congruence2;
                Assert.Fail("Operation succeeded despite different moduli.");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is NotSameModuloException, "Exception thrown but it wasn't the modulo exception.");
            }
        }
    }
}
