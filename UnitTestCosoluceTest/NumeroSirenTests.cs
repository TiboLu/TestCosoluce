using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibraryTestCosoluce;

namespace UnitTestCosoluceTest {
    [TestClass]
    public class NumeroSirenTests {
        [TestMethod]
        public void HasOnlyNumbersTest() {
            NumeroSiren numeroSiren = new NumeroSiren("800403222");

            Assert.IsTrue(numeroSiren.HasOnlyNumbers());

            numeroSiren = new NumeroSiren("8O0403222");
            Assert.IsFalse(numeroSiren.HasOnlyNumbers());
        }

        [TestMethod]
        public void HasCorrectLengthTest() {
            NumeroSiren numeroSiren = new NumeroSiren("800403222");

            Assert.IsTrue(numeroSiren.HasCorrectLength());

            numeroSiren = new NumeroSiren("8004032221");
            Assert.IsFalse(numeroSiren.HasCorrectLength());
        }
    }
}
