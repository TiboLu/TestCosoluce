using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryTestCosoluce {
    public class NumeroSiren : NumeroBase {
        public NumeroSiren(string numero) : base(numero) {
        }

        protected override int GetNumeroDigitSum() {
            return this.LuhnAlgorithm(this._numero);
        }

        public override bool HasCorrectLength() {
            return InternalHasCorrectLength(this._numero, 9);
        }
    }
}
