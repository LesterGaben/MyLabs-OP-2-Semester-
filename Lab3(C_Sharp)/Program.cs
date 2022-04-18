using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_C_Sharp_ {
    internal class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            List<Subscriber> subscribers = Functions.Create_array_of_subscribers();
            Functions.Output_array_of_subscribers(subscribers);
            int max_sum_of_phone_number = 0;
            int i_of_subscriber_of_max_num = Functions.Find_i_of_subscriber_of_max_num(subscribers, ref max_sum_of_phone_number);
            Functions.Output_info_about_subscriber_wtih_max_sum(subscribers, max_sum_of_phone_number, i_of_subscriber_of_max_num);


            Console.ReadKey();
        }
    }
}
