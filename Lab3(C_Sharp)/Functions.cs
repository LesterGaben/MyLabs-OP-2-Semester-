using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_C_Sharp_ {
    public class Functions {

        public static List<Subscriber> Create_array_of_subscribers() {
            List<Subscriber> subscribers = new List<Subscriber>();
            string answer = "Так";
            while (answer != "Ні") {
                Subscriber subscriber = new Subscriber();
                string line;
                Console.Write("Введіть ПІБ абонента через пробіл: "); line = Console.ReadLine();
                string[] temp = line.Split(' ');
                subscriber.fullname.surname = temp[0];
                subscriber.fullname.name = temp[1];
                subscriber.fullname.patronymic = temp[2];
                Console.Write("Введіть адресу абонента через пробіл(місто/назва вулиці/номер дому): "); line = Console.ReadLine();
                temp = line.Split(' ');
                subscriber.adress.city = temp[0];
                subscriber.adress.street = temp[1];
                subscriber.adress.num_of_house = Convert.ToInt32(temp[2]);
                Console.Write("Введіть номер телефону абонента(формат: ХХХ-ХХХ-ХХ-ХХ): "); subscriber.phone_number = Console.ReadLine();
                subscribers.Add(subscriber);
                Console.Write("Бажаєте продовжити введення?(Будь-яке введеня/Ні): "); answer = Console.ReadLine();
                Console.WriteLine("======================================");
            }
            return subscribers;
        }

        public static void Output_array_of_subscribers(List<Subscriber> subscribers) {
            int counter = 0;
            Console.WriteLine();
            foreach (Subscriber temp in subscribers) {
                Console.WriteLine("Абонент номер " + ++counter);
                temp.Print_information_about_subscriber();
                Console.WriteLine("----------------------------------");
            }
        }

        public static int Find_i_of_subscriber_of_max_num(List<Subscriber> subscribers, ref int max_sum_of_phone_number) {
            int i_of_subscriber_of_max_num = 0;
            max_sum_of_phone_number = 0;
            int counter = 0;
            foreach (Subscriber temp in subscribers) {
                int sum = Count_sum_of_phone_number(temp.phone_number);
                if (max_sum_of_phone_number < sum) {
                    max_sum_of_phone_number = sum;
                    i_of_subscriber_of_max_num = counter;
                }
                counter++;

            }
            return i_of_subscriber_of_max_num;
        }

        public static int Count_sum_of_phone_number(string phone_number) {
            long temp_num = Convert.ToInt64(phone_number);
            long sum = 0;
            while (temp_num > 0) {
                sum += temp_num % 10;
                temp_num /= 10;
            }
            return (int)sum;
        }

        public static void Output_info_about_subscriber_wtih_max_sum(List<Subscriber> subscribers, int max_sum_of_phone_number, int i_of_subscriber_of_max_num) {
            Console.WriteLine("\nІнформація про абонента з найбільшою сумою цифр телефону(" + max_sum_of_phone_number + "): ");
            subscribers[i_of_subscriber_of_max_num].Print_information_about_subscriber();
        }
    }
}
