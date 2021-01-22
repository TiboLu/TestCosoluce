using System;
using System.Linq;

namespace ClassLibraryTestCosoluce {
    public abstract class NumeroBase {
        #region Champs privés
        protected string _numero;
        #endregion

        protected NumeroBase(string numero) {
            this._numero = numero;
        }

        #region propriétés publiques
        public string Numero {
            get => this._numero;
        }

        public int NumeroDigitSum {
            get {
                return GetNumeroDigitSum();
            }
        }
        #endregion

        #region Méthodes protégées
        protected abstract int GetNumeroDigitSum();

        protected Func<string, int, bool> InternalHasCorrectLength = (string numero , int expectedLength) =>  numero.Length == expectedLength;

        protected int LuhnAlgorithm(string numero) {
            // Expression lambda déterminant si un chiffre est pair ou non
            Func<int, bool> isEven = (int index) => index % 2 == 0;

            int sum = 0;
            // Inversion de la chaine de caractère pour travailler sur de bons index
            string reverseNumero = String.Concat(numero.Reverse());

            for (int i = 0; i < reverseNumero.Length; i++) {
                int numericValue = (int)char.GetNumericValue(numero[i]);
                // la position 0 de la string correspond en fait à la position 1 dans l'algo etc...
                sum = isEven(i + 1) ? sum + (numericValue * 2) : sum + numericValue;
            }

            return sum;
            ;
        }
        #endregion

        #region Méthodes publiques
        public abstract bool HasCorrectLength();

        public bool HasOnlyNumbers() {
            long i;
            return long.TryParse(this._numero, out i);        
        }
        #endregion
    }
}
