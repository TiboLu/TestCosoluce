using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTestCosoluce {
    public class NumeroSiret : NumeroBase {
        public NumeroSiret(string numero) : base(numero) {
        }

        protected override int GetNumeroDigitSum() {
            // on applique l'algo de Luhn sur les caractères de la chaine sauf le premier
            int sum = this.LuhnAlgorithm(this._numero.Substring(1));

            // Calcul pour le premier caractère
            int firstPositionValue = (int)Char.GetNumericValue(this.Numero[0]);
            firstPositionValue = firstPositionValue * 2;
            // Ajout de la décomposition à la somme calculé par l'algo de Luhn
            sum = sum + (int)Char.GetNumericValue(firstPositionValue.ToString(), 0) + (int)Char.GetNumericValue(firstPositionValue.ToString(), 1);

            return sum;
        }

        public override bool HasCorrectLength() {
            return InternalHasCorrectLength(this._numero, 14);
        }
    }
}
