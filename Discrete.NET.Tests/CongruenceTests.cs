namespace Discrete.NET.Tests
{
    [TestClass]
    public class CongruenceTests
    {
        [TestMethod]
        public void TestCongruenceSimpleReduction()
        {
            var congruence = new Congruence(2, 3, 5);
            congruence.Simplify();

            Assert.IsTrue(congruence.Reduced);

            Assert.AreEqual(1, congruence.A);
            Assert.AreEqual(4, congruence.B);
            Assert.AreEqual(5, congruence.N);
        }

        [TestMethod]
        public void TestCongruenceSimplifiedAndReduced()
        {
            var congruence = new Congruence(6, 12, 15);
            congruence.Simplify();

            Assert.IsTrue(congruence.Simplified);
            Assert.IsTrue(congruence.Reduced);
        }

        [TestMethod]
        public void TestCongruenceIrreducible()
        {
            var congruence = new Congruence(6, 8, 36);
            congruence.Simplify();

            Assert.IsTrue(congruence.Simplified);
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
                Assert.AreEqual(congruence.A + congruence2.A, congruence3.A);
                Assert.AreEqual(congruence.B + congruence2.B, congruence3.B);
                Assert.AreEqual(congruence.N, congruence3.N);
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
                Assert.AreEqual(congruence.A * congruence2.A, congruence3.A);
                Assert.AreEqual(congruence.B * congruence2.B, congruence3.B);
                Assert.AreEqual(congruence.N, congruence3.N);
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
                Assert.AreEqual(congruence.A - congruence2.A, congruence3.A);
                Assert.AreEqual(congruence.B - congruence2.B, congruence3.B);
                Assert.AreEqual(congruence.N, congruence3.N);
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
