using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_C_Sharp_ {
    public class Node {
        public int num { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node(int num) {
            this.num = num;
            left = new Node();
            right = new Node();
        }
        public Node() {
        }
    }
}
