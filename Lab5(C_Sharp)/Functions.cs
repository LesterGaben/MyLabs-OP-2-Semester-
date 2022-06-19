using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_C_Sharp_ {
    public class Functions {

        public static void TaskWithLinearEquations(int n) {
            List<LinearEquation> linearEquations = new List<LinearEquation>();
            Random random = new Random(((int)DateTime.Now.Ticks));

            Console.WriteLine("\nLinear Equations:");
            for (int i = 0; i < n; i++) {
                int a = random.Next(-100, 100);
                int b = random.Next(-100, 100);
                LinearEquation linearEquation = new LinearEquation(a, b);
                linearEquations.Add(linearEquation);
                Console.WriteLine(linearEquation + "   " +  (linearEquation.HaveAnyRoots() ? "Have root" : "No root"));
            }

            List<double> linearEquationsRoots = FillArrayOfRoots(linearEquations);
            Console.WriteLine("\nSum of linear equation's(that have roots) roots: " + linearEquationsRoots.Sum());
            Console.Write("\nInput num of linear equation to check: "); int iOfLinearEquation = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Input num to check: "); double numToCheckInLinearEquation = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Num is a root: " + linearEquations[iOfLinearEquation].IsRoot(numToCheckInLinearEquation));
        }

        public static void TaskWithQuadraticEquations(int m) {
            Random random = new Random(((int)DateTime.Now.Ticks));

            List<QuadraticEquation> quadraticEquations = new List<QuadraticEquation>();
            
            Console.WriteLine("\nQuadratic equations:");
            for (int i = 0; i < m; i++) {
                int a = random.Next(-100, 100);
                int b = random.Next(-100, 100);
                int c = random.Next(-100, 100);
                QuadraticEquation quadraticEquation = new QuadraticEquation(a, b, c);
                quadraticEquations.Add(quadraticEquation);
                Console.WriteLine(quadraticEquation + "   " + (quadraticEquation.HaveAnyRoots() ? "Have root or roots" : "No roots"));
            }

            List<double> quadraticEquationsRoots = FillArrayOfRoots(quadraticEquations);
            Console.WriteLine("\nSum of quadratic equation's(that have roots) roots: " + quadraticEquationsRoots.Sum());
            Console.Write("\nInput num of quadratic equation to check: "); int iOfQuadraticEquation = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Input num to check: "); double numToCheckInQuadratiEquation = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Num is a root: " + quadraticEquations[iOfQuadraticEquation].IsRoot(numToCheckInQuadratiEquation));
        }



        public static List<double> FillArrayOfRoots(List<LinearEquation> equations) {
            List<double> equationsRoots = new List<double>();
            foreach (var equation in equations.Where(x => x.HaveAnyRoots())) {
                var roots = equation.FindRoot();
                equationsRoots.AddRange(roots);
            }
            return equationsRoots;
        }

        public static List<double> FillArrayOfRoots(List<QuadraticEquation> equations) {
            List<double> equationsRoots = new List<double>();
            foreach (var equation in equations.Where(x => x.HaveAnyRoots())) {
                var roots = equation.FindRoot();
                equationsRoots.AddRange(roots);
            }
            return equationsRoots;
        }
    }
}
