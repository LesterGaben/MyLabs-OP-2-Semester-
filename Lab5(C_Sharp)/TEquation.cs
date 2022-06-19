using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_C_Sharp_ {

    public abstract class TEquation {
        protected string Equation { get; set; }
        protected abstract int NumOfCoefficients { get; }
        protected int[] Coefficients { get; set; }
        public TEquation(params int[] Coefficients) {
            if (Coefficients.Length == NumOfCoefficients) {
                this.Coefficients = Coefficients;
                return;
            }
            else {
                throw new ArgumentException("Incorrect number of coefficients");
            }
            
        }

        public abstract bool HaveAnyRoots();
        protected abstract void SetEquation();

        //Не робив метод віртуальним бо у цьому немає сенсу
        public abstract bool IsRoot(double numToCheck);

        //Не робив метод віртуальним бо у цьому немає сенсу
        public abstract IEnumerable<double> FindRoot();
        public override string ToString() {
            return Equation;
        }
    }
}
