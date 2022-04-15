from Functions import*

file_name = "file.bin"
input_in_file(file_name)
output_text_from_file(file_name)
new_file_name = "new_file.bin"
input_in_new_file(file_name, new_file_name)
output_text_from_file(new_file_name)
output_free_time(create_free_time_list(file_name))
