using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTestCosoluce {
    public class ValidityChecker {
        private NumeroBase _numero;

        public ValidityChecker(NumeroBase numero) {
            this._numero = numero;
        }

        private bool IsValid() {
            int sum = this._numero.NumeroDigitSum;

            return sum % 10 == 0;
        }

        public bool CheckValidity() {
            // 1 - Test si tous les éléments du numéro sont des chiffres
            if (!this._numero.HasOnlyNumbers()) {
                return false;
            }
            // 2 - Test que le nombre d'éléments du numéro est correct
            if (!this._numero.HasCorrectLength()) {
                return false;
            }
            // 3 - Test de la validité des chiffres composant le numéro
            return this.IsValid();
        }
    }
}
