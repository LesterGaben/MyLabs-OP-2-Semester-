using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_C_Sharp_ {
    public class Functions {

        public static void TaskWithTree() {
            Console.Write("Input an integer num(num > 0): "); int num = Convert.ToInt32(Console.ReadLine());
            while(num <= 1) {
                Console.WriteLine("Incorrect input!");
                Console.Write("Input num: "); num = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("\nBinary tree:");
            BinaryTree binaryTree = new BinaryTree(num);
            binaryTree.PrintLevelOrder(binaryTree.top, num);
        }
    }
}
