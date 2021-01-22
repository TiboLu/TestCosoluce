using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibraryTestCosoluce;

namespace UnitTestCosoluceTest {
    [TestClass]
    public class NumeroSiretTests {
        [TestMethod]
        public void HasOnlyNumbersTest() {
            NumeroSiret numeroSiret = new NumeroSiret("80040322200014");
            Assert.IsTrue(numeroSiret.HasOnlyNumbers());

            numeroSiret = new NumeroSiret("8O040322200014");
            Assert.IsFalse(numeroSiret.HasOnlyNumbers());
        }

        [TestMethod]
        public void HasCorrectLengthTest() {
            NumeroSiret numeroSiret = new NumeroSiret("80040322200014");

            Assert.IsTrue(numeroSiret.HasCorrectLength());

            numeroSiret = new NumeroSiret("800403222000141");
            Assert.IsFalse(numeroSiret.HasCorrectLength());
        }
    }
}
