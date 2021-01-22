using System.Collections.ObjectModel;
using System.Windows.Input;
using ClassLibraryTestCosoluce;

namespace TestCosoluceWPF.ViewModels {
    public enum NumeroType {
        siren,
        siret
    }

    public class UserControl1ViewModel {
        #region Champs privés
        private ICommand _checkValidityCommand;
        private NumeroType _numeroType = NumeroType.siren;
        private ObservableCollection<string> _ValidationResult;
        #endregion

        #region propriétés publiques
        public ICommand CheckValidityCommand {
            get => this._checkValidityCommand;
        }
        public NumeroType MyNumeroType {
            get => this._numeroType;
            set => this._numeroType = value;
        }
        public ObservableCollection<string> ValidationResult {
            get => this._ValidationResult;
            set => this._ValidationResult = value;
        }
        #endregion
        
        public UserControl1ViewModel() {
            this._checkValidityCommand = new RelayCommand(this.IsValid);
            this._ValidationResult = new ObservableCollection<string>();            
        }

        #region Méthodes privées
        private void IsValid(object param) {
            ValidityChecker checker;
            switch (this._numeroType) {
                case NumeroType.siren:
                    checker = new ValidityChecker(new NumeroSiren(param as string));
                    break;
                case NumeroType.siret:
                    checker = new ValidityChecker(new NumeroSiret(param as string));
                    break;
                default:
                    throw new System.Exception();
            }

            bool isValid = checker.CheckValidity();
            if (isValid) {
                this._ValidationResult.Add(string.Format("{0} is a valid {1}", param, NumeroTypeToString(this._numeroType)));
            }
            else {
                this._ValidationResult.Add(string.Format("{0} is not a valid {1}", param, NumeroTypeToString(this._numeroType)));
            }
        }

        private static string NumeroTypeToString(NumeroType numeroType) {
            switch (numeroType) {
                case NumeroType.siren:
                    return "SIREN";
                case NumeroType.siret:
                    return "SIRET";
                default:
                    throw new System.Exception();
            }
        }
        #endregion
    }
}
