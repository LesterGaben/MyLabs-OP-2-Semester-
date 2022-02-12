def input_text_in_file(file_name):
    with open(file_name, "w") as my_file:
        print("Enter text (to stop typing, press ctrl + Z on a new line and confirm with enter):")
        try:
            while(True): 
                my_file.write(input() + "\n")
        except EOFError:
            pass
    pass

def output_text_from_file(file_name):
    print("\nFile contents " + file_name + ":")
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

symbol = input("Enter the desired letter: ")
words_with_symbol = find_words_with_symbol(file_name, symbol)
print("\nWords that begin with a given letter:\n" + words_with_symbol + "\n")

new_file_name = "new_file.txt"
input_words_in_new_file(new_file_name, words_with_symbol)
output_text_from_file(new_file_name)
