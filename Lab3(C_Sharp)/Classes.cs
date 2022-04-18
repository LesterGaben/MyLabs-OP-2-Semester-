using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_C_Sharp_ {
    public class FullName {

        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
    }

    public class Adress {
        public string city { get; set; }
        public string street { get; set; }
        public int num_of_house { get; set; }

    }
    public class Subscriber {
        public Subscriber() {
            fullname = new FullName();
            adress = new Adress();
        }
        public FullName fullname { get; set; }
        public Adress adress { get; set; }
        public string phone_number { get; set; }

        public void Print_information_about_subscriber() {
            Console.WriteLine("ПІБ абонента : " + fullname.surname + " " + fullname.name + " " + fullname.patronymic);
            Console.WriteLine("Адрес абонента: " + adress.city + " вул." + adress.street + " " + adress.num_of_house);
            Console.WriteLine("Номер абонента: " + phone_number);
        }
    }
}
