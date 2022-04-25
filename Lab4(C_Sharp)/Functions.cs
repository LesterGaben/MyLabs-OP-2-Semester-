using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_C_Sharp_ {
    public class Functions {
        public static void Arithmetic_operations_with_oct_nums() {

            Console.Write("Введіть вісімкове число N1: ");
            int oct_N1 = Convert.ToInt32(Console.ReadLine());
            while (!Numeral_8.Is_num_oct(oct_N1)) {
                Console.Write("Вісімкове число містить цифри в діапазоні 0 - 7! Введіть правильне вісімкове число: ");
                oct_N1 = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Введіть вісімкове число(oct_temp), яке буде додано до вісімкового числа N2: ");
            int oct_temp = Convert.ToInt32(Console.ReadLine());
            while (!Numeral_8.Is_num_oct(oct_temp)) {
                Console.Write("Вісімкове число містить цифри в діапазоні 0 - 7! Введіть правильне вісімкове число: ");
                oct_temp = Convert.ToInt32(Console.ReadLine());
            }

            Numeral_8 N1 = new Numeral_8(oct_N1);
            Numeral_8 N2 = new Numeral_8(N1);
            Numeral_8 N3 = new Numeral_8();
            Console.WriteLine("\nN1 = " + N1 + "\nN2 = " + N2 + "\nN3 = " + N3 + "\noct_temp = " + oct_temp);

            Console.WriteLine("\n++N1 = " + ++N1);
            N2 = N2 + oct_temp;
            Console.WriteLine("N2 += oct_temp = " + N2);
            N3 = N1 + N2;
            Console.WriteLine("N3 = N1 + N2 = " + N3);
            Console.WriteLine("N3 in dec: " + N3.NumInDec());
        }
    }
}
