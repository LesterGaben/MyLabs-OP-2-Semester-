using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2_C_Sharp_ {
    internal class Functions {
        public static void input_in_file(string file_name) {
            Console.WriteLine("Вводіть, будь ласка, справи у порядку зростання часу початку\n");
            string answer = "Так";
            using (BinaryWriter writer = new BinaryWriter(new FileStream(file_name, FileMode.OpenOrCreate))) {
                while (answer != "Ні") {
                    Task task = new Task();
                    Console.Write("Введіть назву справи: "); task.name = Console.ReadLine();
                    Console.Write("Введіть час початку (години:хвилини): "); task.start_time = Console.ReadLine();
                    Console.Write("Введіть тривалість у хвилинах: "); task.duration = Console.ReadLine();
                    Console.Write("Продовжити введення? (Будь-яке інше введення/ Ні): "); answer = Console.ReadLine();
                    Console.WriteLine("=======================");
                    writer.Write(task.name + "   " + task.start_time + "   " + task.duration);
                }
            }
        }

        public static void output_from_file(string file_name) {
            Console.WriteLine("\nВміст файлу " + file_name + ":");
            using (BinaryReader reader = new BinaryReader(new FileStream(file_name, FileMode.Open))) {
                while (reader.PeekChar() > -1) {
                    Console.Write(reader.ReadString() + "\n");
                }
            }
            Console.WriteLine();
        }

        public static void input_in_new_file(string file_name, string new_file_name) {
            string[] line;
            using (BinaryReader reader = new BinaryReader(new FileStream(file_name, FileMode.Open))) {
                using (BinaryWriter writer = new BinaryWriter(new FileStream(new_file_name, FileMode.OpenOrCreate))) {
                    while (reader.PeekChar() > -1) {
                        line = reader.ReadString().Split(new string[] { "   " }, StringSplitOptions.None);
                        Time start_time = new Time() {
                            hours = Convert.ToInt32(line[1].Substring(0, (line[1].Length - 1) / 2)),
                            minutes = Convert.ToInt32(line[1].Substring(line[1].Length - 2, 2))
                        };
                        var time = calculate_time(line[1], line[2]);
                        Time end_time = new Time() {
                            hours = time.Item1,
                            minutes = time.Item2,
                        };
                        if (((start_time.hours == 12 && start_time.minutes >= 45) || start_time.hours > 12) && (end_time.hours < 17 || (end_time.hours == 17 && end_time.minutes <= 30))) {
                            writer.Write(line[0] + "   " + line[1] + "   " + line[2]);
                        }
                    }
                }
            }
        }

        public static (int, int) calculate_time(string time, string duration) {
            int hours = Convert.ToInt32(time.Substring(0, (time.Length - 1) / 2));
            int minutes = Convert.ToInt32(time.Substring(time.Length - 2, 2));
            minutes += Convert.ToInt32(duration);
            if (minutes >= 60) {
                hours += minutes / 60;
                if (hours >= 24) hours -= 24;
                while (minutes >= 60) minutes -= 60;
            }
            return (hours, minutes);
        }


        public static List<Time_Period> create_free_time_list(string file_name) {
            List<Time_Period> time_list = new List<Time_Period>();
            using (BinaryReader reader = new BinaryReader(new FileStream(file_name, FileMode.Open))) {
                while (reader.PeekChar() > -1) {
                    string[] line = reader.ReadString().Split(new string[] { "   " }, StringSplitOptions.None);
                    Time_Period time_period = new Time_Period();
                    time_period.start.hours = Convert.ToInt32(line[1].Substring(0, (line[1].Length - 1) / 2));
                    time_period.start.minutes = Convert.ToInt32(line[1].Substring(line[1].Length - 2, 2));
                    var time = calculate_time(line[1], line[2]);
                    time_period.end.hours = time.Item1;
                    time_period.end.minutes = time.Item2;
                    time_list.Add(time_period);
                }
            }
            List<Time_Period> free_time_list = new List<Time_Period>();
            for (int i = 1; i < time_list.Count; i++) {
                if ((time_list[i - 1].end.hours < time_list[i].start.hours) || (time_list[i - 1].end.hours == time_list[i].start.hours &&
                    time_list[i - 1].end.minutes < time_list[i].start.minutes)) {
                    Time_Period time_period = new Time_Period();
                    time_period.start.hours = time_list[i - 1].end.hours;
                    time_period.start.minutes = time_list[i - 1].end.minutes;
                    time_period.end.hours = time_list[i].start.hours;
                    time_period.end.minutes = time_list[i].start.minutes;
                    free_time_list.Add(time_period);
                }
            }
            return free_time_list;
        }

        public static void output_free_time(List<Time_Period> free_time_list) {
            int duration;
            Console.WriteLine("\nВільний час:");
            for (int i = 0; i < free_time_list.Count; i++) {
                if (free_time_list[i].start.hours < free_time_list[i].end.hours) {
                    duration = free_time_list[i].end.minutes + ((free_time_list[i].end.hours - free_time_list[i].start.hours) * 60 - free_time_list[i].start.minutes);
                }
                else {
                    duration = free_time_list[i].end.minutes - free_time_list[i].start.minutes;
                }
                string start_time, end_time, start_minutes, end_minutes;
                start_minutes = (free_time_list[i].start.minutes < 10) ? "0" + Convert.ToString(free_time_list[i].start.minutes) : Convert.ToString(free_time_list[i].start.minutes);
                end_minutes = (free_time_list[i].end.minutes < 10) ? "0" + Convert.ToString(free_time_list[i].end.minutes) : Convert.ToString(free_time_list[i].end.minutes);
                start_time = Convert.ToString(free_time_list[i].start.hours) + ":" + start_minutes;
                end_time = Convert.ToString(free_time_list[i].end.hours) + ":" + end_minutes;
                Console.WriteLine("Часовий проміжок: {0}-{1}    Тривалість: {2} хвилин", start_time, end_time, duration);
            }
        }
    }
}
