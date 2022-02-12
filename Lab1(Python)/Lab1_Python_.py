# -*- coding: cp1251 -*-
def input_text_in_file(file_name):
    with open(file_name, "w") as my_file:
        print("Введіть текст(щоб зупинити введення, зажміть у новому рядку ctrl + Z і підтвердіть клавішою enter):")
        try:
            while(True): 
                my_file.write(input() + "\n")
        except EOFError:
            pass
    pass

def output_text_from_file(file_name):
    print("\nВміст файлу " + file_name + ":")
    with open(file_name, "r") as my_file:
        print(my_file.read())
    pass

def find_words_with_symbol(file_name, symbol):
    with open(file_name, "r") as my_file:
        words_with_symbol = ""
        for x in my_file:
            words = x.split()
            for word in words:
                if (word[0] == symbol):
                    words_with_symbol += word + " "
    return words_with_symbol

def input_words_in_new_file(new_file_name, words_with_symbol):
    with open(new_file_name, "w") as new_file:
        new_file.write(words_with_symbol)
    pass


file_name = "file.txt"
input_text_in_file(file_name)
output_text_from_file(file_name)

symbol = input("Введіть бажану літеру: ")
words_with_symbol = find_words_with_symbol(file_name, symbol)
print("\nСлова, що починаються на задану літеру:\n" + words_with_symbol + "\n")

new_file_name = "new_file.txt"
input_words_in_new_file(new_file_name, words_with_symbol)
output_text_from_file(new_file_name)
