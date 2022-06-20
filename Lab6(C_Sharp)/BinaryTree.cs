using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_C_Sharp_ {
    public class BinaryTree {
        private int height;
        private int width;
        private int k;
        public Node top { get; set; }
        public BinaryTree(int n) {
            top = new Node(n);
            top.left = Create(n - 1, 0);
            top.right = Create(n - 1, 0);
        }

        public Node Create(int n, int a) {
            Node node = new Node(n - a);
            if (a == n - 1) {
                node.left = null;
                node.right = null;
            }
            else {
                node.left = Create(n, a + 1);
                node.right = Create(n, a + 1);
            }
            return node;
        }

        public void PrintLevelOrder(Node node, int height) {
            this.height = height;
            this.width = (int)Math.Pow(2, this.height);
            int fullWidth = (2 * width - 1) / 2;
            bool flag = false;
            for (int i = 0; i < this.height; i++) {
                flag = true;
                PrintCurrentLevel(node, i, fullWidth, ref flag, i);
                fullWidth /= 2;
                Console.WriteLine("\n");
            }
        }

        private void PrintCurrentLevel(Node node, int level, int width, ref bool flag, int height) {
            if (node == null) {
                PrintSpaces(2 * width + 1);
                if (level != 0) flag = false;
                if (!Convert.ToBoolean(k)) k = width;
                return;
            }
            if (level == 0) {
                if (!flag) {
                    PrintSpaces(height * k - height * 3 / 2);
                    Console.Write(node.num);
                    flag = true;
                }
                else {
                    PrintSpaces(width);
                    Console.Write(node.num);
                    PrintSpaces(width);
                }
            }
            else if (level > 0) {
                PrintCurrentLevel(node.left, level - 1, width, ref flag, height);
                PrintSpaces(1);
                PrintCurrentLevel(node.right, level - 1, width, ref flag, height);
            }
        }

        private void PrintSpaces(int count) {
            for (int i = 0; i < count; i++) {
                Console.Write(" ");
            }
        }
    }
}
