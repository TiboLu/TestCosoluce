using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ClassLibraryTestCosoluce;

namespace UnitTestCosoluceTest {
    [TestClass]
    public class ValidityCheckerTests {
        private struct Data {
            public string numero;
            public bool expectedSirenResult;
            public bool expectedSiretResult;
        }

        private Data[] _datas = new Data[5] {
                                    new Data(){ numero = "800403222", expectedSirenResult = true, expectedSiretResult = false },
                                    new Data(){ numero = "80040322200014", expectedSirenResult = false, expectedSiretResult = true },
                                    new Data(){ numero = "217103746", expectedSirenResult = true, expectedSiretResult = false },
                                    new Data(){ numero = "800403223", expectedSirenResult = false, expectedSiretResult = false },
                                    new Data(){ numero = "80040322200015", expectedSirenResult = false, expectedSiretResult = false } 
                                    };

        [TestMethod]
        public void TestSirenCheckValidity() {
            foreach (Data data in _datas) {
                ValidityChecker checkSiren = new ValidityChecker(new NumeroSiren(data.numero));

                Assert.IsTrue(data.expectedSirenResult == checkSiren.CheckValidity(), string.Format("{0} must return {1}", data.numero, data.expectedSirenResult.ToString()));
            }
        }

        [TestMethod]
        public void TestSiretCheckValidity() {
            foreach (Data data in _datas) {
                ValidityChecker checkSiret = new ValidityChecker(new NumeroSiret(data.numero));

                Assert.IsTrue(data.expectedSiretResult == checkSiret.CheckValidity(), string.Format("{0} must return {1}", data.numero, data.expectedSirenResult.ToString()));
            }
        }
    }
}
