using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_C_Sharp_ {
    internal class Program {
        static void Main(string[] args) {

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string file_name = "file.bin";
            Functions.input_in_file(file_name);
            Functions.output_from_file(file_name);

            string new_file_name = "new_file.bin";
            Functions.input_in_new_file(file_name, new_file_name);
            Functions.output_from_file(new_file_name);
            Functions.output_free_time(Functions.create_free_time_list(file_name));

            Console.ReadKey();
        }
    }
}
