using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_C_Sharp_ {
    internal class Program {
        static void Main(string[] args) {

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            Console.Write("Input number of linear equations: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Functions.TaskWithLinearEquations(n);

            Console.Write("\nInput number of quadratic equations: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Functions.TaskWithQuadraticEquations(m);


            Console.ReadKey();
        }
    }
}
