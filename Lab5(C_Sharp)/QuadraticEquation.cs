using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_C_Sharp_ {
    public class QuadraticEquation : TEquation {
        protected override int NumOfCoefficients => 3;
        protected int a;
        protected int b;
        protected int c;
        protected double D;
        public QuadraticEquation(params int[] Coefficients) : base(Coefficients) {
            a = Coefficients[0];
            b = Coefficients[1];
            c = Coefficients[2];
            D = Math.Pow(b, 2) - 4 * a * c;
            SetEquation();
        }

        protected override void SetEquation() {
            if (b < 0 && c < 0) Equation = $"{a}x^2 - {Math.Abs(b)}x - {Math.Abs(c)} = 0";
            else if (b >= 0 && c < 0) Equation = $"{a}x^2 + {b}x - {Math.Abs(c)} = 0";
            else if (b < 0 && c >= 0) Equation = $"{a}x^2 - {Math.Abs(b)}x + {c} = 0";
            else Equation = $"{a}x^2 + {b}x + {c} = 0";
        }

        public override bool HaveAnyRoots() {
            if (D >= 0) return true;
            else return false;
        }

        public override bool IsRoot(double numToCheck) {
            if (!HaveAnyRoots()) return false;
            double sum = a * Math.Pow(numToCheck, 2) + b * numToCheck + c;
            return (int)sum == 0;
        }
        public override IEnumerable<double> FindRoot() {
            if (D == 0) {
                double root = (double)-b / 2 * a;
                yield return root;
            }
            else {
                double root1 = (double)(-b + Math.Sqrt(D)) / (2 * a);
                double root2 = (double)(-b - Math.Sqrt(D)) / (2 * a);
                yield return root1;
                yield return root2;
            }
        }
    }
}
