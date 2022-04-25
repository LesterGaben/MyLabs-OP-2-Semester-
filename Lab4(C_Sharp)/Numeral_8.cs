using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_C_Sharp_ {
    public class Numeral_8 {
        public int num { get; private set; }
        public Numeral_8() {
            num = 0;
        }
        public Numeral_8(int num) {

            this.num = num;
        }

        public Numeral_8(Numeral_8 obj) {
            num = obj.num;
        }

        public static Numeral_8 operator +(Numeral_8 obj1, int number) {
            int temp = obj1.NumInDec() + ConvertToDec(number);
            obj1.num = ConvertToOct(temp);
            return obj1;
        }

        public static Numeral_8 operator +(Numeral_8 obj1, Numeral_8 obj2) {
            int temp = obj1.NumInDec() + obj2.NumInDec();
            return new Numeral_8(ConvertToOct(temp));
        }

        public static Numeral_8 operator ++(Numeral_8 obj1) {
            int temp = obj1.NumInDec() + 1;
            obj1.num = ConvertToOct(temp);
            return obj1;
        }

        public int NumInDec() {
            int dec = 0, temp = num, tmp = 0;

            while (temp != 0) {
                dec += (temp % 10) * (int)Math.Pow(8, tmp);
                tmp++;
                temp /= 10;
            }
            return dec;
        }

        private static int ConvertToOct(int dec) {
            int oct = 0, tmp = 0;
            while (dec != 0) {
                oct += (dec % 8) * (int)Math.Pow(10, tmp);
                tmp++;
                dec /= 8;
            }
            return oct;
        }

        private static int ConvertToDec(int oct) {
            int dec = 0, tmp = 0;

            while (oct != 0) {
                dec += (oct % 10) * (int)Math.Pow(8, tmp);
                tmp++;
                oct /= 10;
            }
            return dec;
        }

        public static bool Is_num_oct(int num) {
            if (num >= -7 && num <= 7) {
                return true;
            }
            bool flag = false;
            while (num != 0) {
                if (Math.Abs(num) % 10 > 7) {
                    return false;
                }
                else flag = true;
                num /= 10;
            }
            return flag;
        }

        public override string ToString() {
            return $"{num}";
        }
    }
}
