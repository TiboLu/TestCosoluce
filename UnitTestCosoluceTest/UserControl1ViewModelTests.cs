using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;
using TestCosoluceWPF.ViewModels;

namespace UnitTestCosoluceTest {
    [TestClass]
    public class UserControl1ViewModelTests {

        [TestMethod]
        public void TestNumeroTypeChange() {
            UserControl1ViewModel viewModel = new UserControl1ViewModel();
            
            Assert.IsTrue(viewModel.MyNumeroType == NumeroType.siren, "Check siren is the initialized value");
            
            viewModel.MyNumeroType = NumeroType.siret;
            Assert.IsTrue(viewModel.MyNumeroType == NumeroType.siret, "Check siret is the affect value");
        }

        [TestMethod]
        public void TestCheckValidityCommand() {
            UserControl1ViewModel viewModel = new UserControl1ViewModel();
            ICommand command = viewModel.CheckValidityCommand;

            command.Execute("800403222");
            Assert.IsTrue(viewModel.ValidationResult.Count == 1);
            Assert.IsTrue(viewModel.ValidationResult[0] == "800403222 is a valid SIREN");
            command.Execute("80040322200");
            Assert.IsTrue(viewModel.ValidationResult.Count == 2);
            Assert.IsTrue(viewModel.ValidationResult[1] == "80040322200 is not a valid SIREN");
            viewModel.MyNumeroType = NumeroType.siret;
            command.Execute("80040322200");
            Assert.IsTrue(viewModel.ValidationResult.Count == 3);
            Assert.IsTrue(viewModel.ValidationResult[2] == "80040322200 is not a valid SIRET");
            command.Execute("80040322200014");
            Assert.IsTrue(viewModel.ValidationResult.Count == 4);
            Assert.IsTrue(viewModel.ValidationResult[3] == "80040322200014 is a valid SIRET");
        }
    }
}
