using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab1_C_Sharp_ {
    internal class Lab1 {
        static void Main(string[] args) {

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            string file_name = "file_1.txt";
            input_text_in_file(file_name);
            output_text_from_file(file_name);

            Console.Write("Введіть будь ласка літеру: ");
            char symbol = Convert.ToChar(Console.ReadLine());

            string words_with_symbols = find_words_with_symbol(file_name, symbol);
            Console.WriteLine("\nСлова, що починаються на задану літеру:");
            Console.WriteLine(words_with_symbols);

            string new_file_name = "new_file_1.txt";
            input_text_words_in_new_file(new_file_name, words_with_symbols);
            output_text_from_file(new_file_name);

            Console.ReadKey();
        }


        static void input_text_in_file(string file_name) {
            string text = "", line = "";
            Console.WriteLine("Введіть текст(щоб зупинити введення, зажміть у новому рядку ctrl + Z і підтвердіть клавішою enter):");
            while (true) {
                line = Console.ReadLine();
                if (line != "" && (int)line[0] == 26) break;
                text += line + "\n";
            }
            File.WriteAllText(file_name, text);
        }

        static void output_text_from_file(string file_name) {
            Console.WriteLine("\nВміст файлу " + file_name + ":\n" + File.ReadAllText(file_name));
        }

        static string find_words_with_symbol(string file_name, char symbol) {
            string words_with_symbols = "";
            string[] words;
            foreach (string line in File.ReadAllLines(file_name)) {
                words = line.Split();
                foreach (string word in words) {
                    if (word[0] == symbol) {
                        words_with_symbols += word + " ";
                    }
                }
            }
            return words_with_symbols;
        }

        static void input_text_words_in_new_file(string file_name, string words_with_symbols) {
            File.WriteAllText(file_name, words_with_symbols);
        }
    }
}
