using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_C_Sharp_ {
    public class LinearEquation : TEquation {
        protected override int NumOfCoefficients => 2;

        protected int a;
        protected int b;
        public LinearEquation(params int[] Coefficients) : base(Coefficients) {
            a = Coefficients[0];
            b = Coefficients[1];
            SetEquation();
        }

        public override bool HaveAnyRoots() {
            if (a == 0 && b == 0) return true;
            else if (a == 0 && b != 0) return false;
            else return true;
        }
        protected override void SetEquation() {
            if (b < 0) Equation = $"{a}x - {Math.Abs(b)} = 0";
            else Equation = $"{a}x + {b} = 0";
        }

        public override bool IsRoot(double numToCheck) {
            if (!HaveAnyRoots()) return false;
            double sum = a * numToCheck + b;
            return (int)sum == 0;
        }

        public override IEnumerable<double> FindRoot() {
            double root;
            root = (double)-b / a;
            yield return root;
        }

    }
}
